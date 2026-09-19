# Security review – Online Admission Eligibility System

| | |
|---|---|
| **Reviewed code** | Graduation project version of October 2022 (ASP.NET Core 3.1 MVC) |
| **Reviewer** | Abdullah Darwish (co-author of the project, now studying cybersecurity) |
| **Date** | September 2026 |
| **Method** | Manual source-code review (assisted by Claude, an AI assistant) of every controller, the data model, the configuration and the repository history, mapped to the OWASP Top 10 (2021) and CWE. No testing against the 2022 live deployment (it is offline). |
| **Result** | 17 security findings (2 critical, 5 high, 4 medium, 4 low, 2 informational) and 12 correctness findings in the admission logic. Both critical findings and 4 of the 5 high findings are fully fixed in the code, the fifth high finding is partly fixed, and 2 findings also need actions outside the code. |

## Why this review

This system handles very sensitive data: national ID card images, high-school certificates, payment receipts, family details, and the decision about who gets a university seat. When we built it in 2022 we focused on making it work. Looking at it again as a security student, I wanted to find what an attacker could do with it, fix what I could, and document the rest honestly.

The main lesson: **most problems came from trusting the browser.** Rules were enforced by what the page showed (hidden fields, filtered lists, hidden buttons), but the server accepted whatever was sent.

## Summary

Status: ✅ fixed in this repository · 🟡 partly fixed · ⚠️ action needed outside the code · ⏳ open (recommendation)

| ID | Finding | Severity | OWASP 2021 / CWE | Status |
|---|---|---|---|---|
| S-01 | Production secrets committed to the repository | Critical | A07 / CWE-798 | ✅ + ⚠️ |
| S-02 | Anyone could create an administrator account | Critical | A01 / CWE-862 | ✅ |
| S-03 | Admin accounts seeded with a password written in the code | High | A07 / CWE-1392 | ✅ + ⚠️ |
| S-04 | Students could change other students' applications (IDOR) | High | A01 / CWE-639 | ✅ |
| S-05 | Grade and wishes could be changed after verification; wish rules only checked in the browser | High | A04 / CWE-602, CWE-472 | ✅ |
| S-06 | Path traversal in file uploads (delete or overwrite files on the server) | High | A01 / CWE-22 | ✅ |
| S-07 | ID documents publicly reachable in `wwwroot/Uploads`; any file type accepted | High | A01 / CWE-552, CWE-434 | 🟡 |
| S-08 | Admin dashboard reachable without login | Medium | A01 / CWE-862 | ✅ |
| S-09 | No protection against password guessing | Medium | A07 / CWE-307 | ✅ |
| S-10 | Employee actions trust the employee id sent by the browser | Medium | A01 / CWE-639 | ✅ |
| S-11 | Unused endpoint let any student create extra student records | Medium | A01 / CWE-285 | ✅ |
| S-12 | Account pages crash for users who are not logged in | Low | CWE-476 | ✅ |
| S-13 | Student e-mail addresses are never verified | Low | A07 / CWE-287 | ⏳ |
| S-14 | Errors are silently ignored or passed to the page | Low | A09 / CWE-390 | ⏳ |
| S-15 | Lock action changes data without an anti-forgery token | Low | A01 / CWE-352 | ⏳ |
| S-16 | Framework out of support since December 2022 | Info | A06 / CWE-1104 | ⏳ |
| S-17 | 100 MB of Visual Studio cache, personal settings and test uploads in Git | Info | – | ✅ |

---

## Findings and fixes

### S-01 – Production secrets committed to the repository (Critical)

**Where:** `appsettings.json` (connection string) and `appsettings.Development.json` (e-mail password, reCAPTCHA secret key).

**What was wrong:** the connection string of the production SQL Server database, including its password, was committed. The server was a shared-hosting SQL Server reachable from the internet. The same password was reused for the project's e-mail account, and the reCAPTCHA secret key was committed as well.

**Impact:** anyone who could read the repository could connect to the production database and read or change every application, including ID card data. With the e-mail account they could send official-looking e-mails to students.

**Fix:** the configuration files now contain only safe defaults (a local LocalDB connection string and empty passwords). Real values come from `dotnet user-secrets` on a developer machine and from environment variables (or an untracked `appsettings.Production.json`) on a server. `.gitignore` blocks the production settings file.

**⚠️ Action needed:** removing a secret from the latest version does **not** remove it from the Git history. The old values must be treated as public and changed: see [Actions outside the code](#actions-outside-the-code).

### S-02 – Anyone could create an administrator account (Critical)

**Where:** `AccountController.Register_Employee` (GET and POST).

**What was wrong:** the page for creating staff accounts had no `[Authorize]` attribute, and the form has a *Type* field with the values *Employee* and *Admin*. Any visitor could open the page and create an **Admin** account. The confirmation e-mail was sent to the address typed in the form, so the attacker could confirm it too.

**Impact:** full control of the system: change seats and minimum grades, run the algorithm, export all students' data, create more accounts.

**Fix:** both actions now require `[Authorize(Roles = "Admin")]`.

### S-03 – Admin accounts seeded with a password written in the code (High)

**Where:** `MyIdentityDataInitializer.SeedaUsers`.

**What was wrong:** the two default accounts `Admin1` and `Admin2` were created with the same password, written in the source code. Every installation had the same admin password.

**Fix:** the password is read from the setting `SeedAdmin:Password`. If it is not set, the admin accounts are not created and a warning is logged.

**⚠️ Action needed:** any copy of the system that was installed from the old code still has the old password. Change it on every running copy.

### S-04 – Students could change other students' applications (High)

**Where:** `StudenController` and `StudentUnsyrianController` – the POST actions `Edit`, `Details` and `WishesSelection`.

**What was wrong:** the GET actions checked that the application in the URL (`/Studen/Edit/15`) belongs to the logged-in student, but the POST actions did not. A student could send the form with another student's id. This is an *Insecure Direct Object Reference* (IDOR).

**Impact:** any student (and anyone can register as a student) could overwrite another student's personal data and grade, change their wishes, or confirm their request.

**Fix:** a helper `IsOwner(student)` is checked at the start of every POST action. The check uses the record loaded from the database, not values from the form.

### S-05 – Grade and wishes could be changed after verification (High)

**Where:** the same POST actions, plus the hidden fields of the edit and wish pages.

**What was wrong:**

- The edit page is blocked after an employee verified the request, but only when it is **opened**. Sending the form directly still worked, so a verified student could raise their grade. The verification flags stayed "checked", so the algorithm used the new grade.
- The wish page only **lists** departments whose minimum grade fits the student, but the POST accepted any department id. The report (section 2.3.2) says the minimum grade is not compared during allocation "because student can't select a wish that is not suitable with his rate". That was only true in the browser.
- The status code, the old grade, the wishes and the file names were read back from hidden form fields, so they could be changed in the browser.

**Impact:** a student could get a seat in a department they do not qualify for, or take the seat of a better student.

**Fix:** the POST actions repeat every check of the GET actions (request status, round open). Status, old grade, old certificate type, wishes, user name and file names are loaded from the database. The minimum grade and certificate type of every chosen wish are checked on the server (`WishesAreAllowed`).

### S-06 – Path traversal in file uploads (High)

**Where:** file handling in `Create` and `Edit` of both student controllers.

**What was wrong:** the file path was built from values chosen by the user: `Identity_No + the file name sent by the browser`. When a file was replaced, the **old** file name was taken from a hidden form field and deleted with `File.Delete`. Neither value was checked. A crafted name such as `..\..\web.config` points outside the `Uploads` folder.

**Impact:** a student could delete files of the application (for example its configuration, which takes the site down) or write files outside the upload folder.

**Fix:** a new `Services/UploadFiles.cs` helper:

- the server generates the file name: `<identity number>_<random id>.<extension>`, cleaned so it can never contain a folder, a drive letter or `..`,
- the old file to delete comes from the database and is cleaned the same way; only real files are deleted, never folders,
- file streams are closed with `using`. The old code left them open, which is why it needed `GC.Collect()` before deleting a file.

### S-07 – ID documents in a public folder; any file type accepted (High, partly fixed)

**Where:** `wwwroot/Uploads`.

**What was wrong:** everything in `wwwroot` is served to anyone, without login. The uploaded ID cards, certificates and receipts were stored there with predictable names (the student's ID number followed by the original file name). Any file type was accepted, including HTML or SVG files, which the browser would run as part of the site (stored cross-site scripting).

**Fix so far:** file names now contain a random 128-bit id, so they cannot be guessed. Only image types (`.jpg .jpeg .png .gif .bmp .webp`) keep their extension. Any other file gets the extra extension `.blocked`, which the web server refuses to serve.

**Still recommended:** store uploads **outside** `wwwroot` and serve them through a controller action that checks that the user is the owner of the file or an employee. Also limit the file size and check the file content, not only its name.

### S-08 – Admin dashboard reachable without login (Medium)

**Where:** `AdminControl`.

**What was wrong:** unlike the other admin controllers, it had no `[Authorize]` attribute, so the statistics (students per country, accepted and not accepted) were public.

**Fix:** `[Authorize(Roles = "Admin")]` on the controller.

### S-09 – No protection against password guessing (Medium)

**Where:** `AccountController.Login`.

**What was wrong:** `PasswordSignInAsync` was called with `lockoutOnFailure: false`, so passwords could be tried without limit. The login page shows a reCAPTCHA box, but the server-side check was commented out, so the answer was never verified (the report describes reCAPTCHA as a protection).

**Fix:** `lockoutOnFailure: true`. ASP.NET Core Identity now locks an account for 5 minutes after 5 wrong passwords. The reCAPTCHA check runs on the server when `GoogleReCaptcha:Enabled` is `true` and a secret key is configured.

### S-10 – Employee actions trust the employee id from the browser (Medium)

**Where:** `EmployeeController.loak_Syrian`, `loak_UnSyrian` and the POST actions `Edit_Status_of_student` / `Edit_Status_of_Unsyrian_student`.

**What was wrong:** the id of the employee who locks or checks a request was sent in the form. An employee could act in the name of another employee. The audit trail of grade changes (`Tracking_Rate`) could then show the wrong person.

**Fix:** these actions now check that the employee in the form is the logged-in employee. *Still recommended:* also check on POST that the request is locked by this employee.

### S-11 – Unused endpoint let students create extra student records (Medium)

**Where:** `Create` (GET and POST) in both student controllers.

**What was wrong:** no page uses these actions (students register through `Account/Register_Student`), but they were still reachable. Any logged-in student could post to them and create new student rows. Several parts of the code assume that a student, their application, their verification and their result have **the same id**, so extra rows could break these links for every later student.

**Fix:** both actions are marked `[NonAction]`, so they are no longer reachable.

### S-12 – Account pages crash for users who are not logged in (Low)

`ChangePassword` and `EditUser` read the current user without requiring a login, so an anonymous request caused a server error. They now have `[Authorize]`.

### S-13 – Student e-mail addresses are never verified (Low, open)

Student accounts are confirmed automatically at sign-up (the confirmation e-mail code is commented out). A student can register with somebody else's e-mail address, and messages about the application then go to that person. `EditUser` also checks duplicate e-mails only against employees. **Recommendation:** send the confirmation e-mail to students as well, and check duplicates against all users.

### S-14 – Errors are silently ignored or passed to the page (Low, open)

`MailingService.SendEmailAsync` catches every exception and does nothing, so failed e-mails (for example "please fix your application") are lost without any trace. Some actions return `View(e)` with the exception as the page model. **Recommendation:** log errors with `ILogger`, show a friendly error page, and tell the employee when an e-mail could not be sent.

### S-15 – Lock action without an anti-forgery token (Low, open)

`loak_Syrian` and `loak_UnSyrian` change data but accept any HTTP method and do not validate an anti-forgery token, so another website could make an employee's browser lock requests. **Recommendation:** `[HttpPost]` and `[ValidateAntiForgeryToken]` on both actions.

### S-16 – Framework out of support (Info, open)

.NET Core 3.1 and EF Core 3.1 stopped receiving security updates in December 2022. **Recommendation:** upgrade to a supported long-term-support (LTS) version of .NET and update all NuGet packages.

### S-17 – Repository hygiene (Info)

The repository contained the `.vs` folder (about 100 MB of Visual Studio cache), personal `*.user` files, publish history and test images in `wwwroot/Uploads`. They are removed from Git and ignored by the new `.gitignore`.

---

## Correctness findings in the admission logic

These are not security issues, but they decide who gets a seat, so they matter as much.

| ID | Finding | Status |
|---|---|---|
| C-01 | **Syrian algorithm crashed** whenever a student was accepted into their 2nd or 3rd wish: the seat counter used a navigation property that was never loaded (`NullReferenceException`). | ✅ Fixed |
| C-02 | **Non-Syrian algorithm mixed countries:** the country filter used a column that is never filled (`Fk_Cirtificate_cityId`), so it had been commented out, and students from every country competed for the seats of the selected country. It now filters by the certificate country. | ✅ Fixed |
| C-03 | Students who got no seat were never marked "not accepted", so running the algorithm again could keep an old acceptance. | ✅ Fixed |
| C-04 | The algorithm page crashed when the selected country had no seat percentage. It now shows a message. | ✅ Fixed |
| C-05 | Seats are saved per admission round, but the algorithm used `SingleOrDefault` per department, which crashed as soon as a department had seats in two rounds. It now uses the row of the selected round, or another row when that round has none (as before). | ✅ Fixed |
| C-06 | The results page and the Excel export crashed as soon as one registered student had not finished the application form (no certificate country yet). | ✅ Fixed |
| C-07 | The "Student name" column of the results shows the **father's** English name (`Father_Name_EN`). | ⏳ Open – needs a team decision on which name to show |
| C-08 | Students with the same grade are ordered by database order; there is no tie-break rule. | ⏳ Open |
| C-09 | The algorithm does not re-check the minimum grade. Since this update the server checks it when the wishes are chosen, but data saved before the update is not re-checked. | ⏳ Open |
| C-10 | The maximum mark (2,300) is written in the code in two places. | ⏳ Open |
| C-11 | The dashboard count "Syrian, not checked" uses OR instead of AND, so it counts the wrong students. | ⏳ Open |
| C-12 | Every list loads a whole table into memory, and many loops run one query per student. This works for a few thousand students but is slow. | ⏳ Open |

## How the fixes were checked

- Every change was type-checked with the C# compiler: the original code and the fixed code both compile without errors against the ASP.NET Core framework (the third-party NuGet packages were replaced by stubs for this check). The project still needs a normal build and the manual test below in Visual Studio.
- The new file-name helper was tested with traversal names (`..\..\web.config`, `C:evil.dll`, `\\server\share\f.png`, `file.jpg:stream`, `..`, empty and null names). None of them could leave the upload folder.
- The new settings files were loaded with the .NET configuration reader to make sure they are valid.
- Every fix was written to behave exactly like the old code for normal use. It only rejects requests that the pages themselves never send.

### Manual test checklist (run before deploying)

1. Log in as `Admin1` with the password from `SeedAdmin:Password`. The dashboard opens.
2. Log out and open `/AdminControl/Index` and `/Account/Register_Employee`. Both must send you to the login page.
3. As admin, create an employee account (confirm its e-mail), then log in as the employee.
4. Type a wrong password 5 times. The account must be locked for 5 minutes.
5. Sign up two students, A and B. As A, fill the application and upload 4 images. In `wwwroot/Uploads` the files must be named `<ID number>_<random id>.jpg`.
6. As A, change the id in the address bar to B's id. You must see the access error page.
7. As A, choose wishes (only departments that match the grade are listed) and confirm. The edit page must now be blocked.
8. As the employee, lock A's request, verify it, and check that A gets a university ID.
9. As admin, set seats and percentages, run the Syrian algorithm and export the Excel file. Then run it again: the results must be the same.

## Actions outside the code

These cannot be done by changing code. They must be done by the repository owners **before the repository is made public**:

| Action | Why | Status |
|---|---|---|
| Change the password of the production SQL Server database, or delete the database if it is no longer used | Old password is in the Git history (S-01) | ⚠️ To do |
| Change the password of the project e-mail account | Same password, also in the history (S-01) | ⚠️ To do |
| Delete the reCAPTCHA keys in the Google reCAPTCHA admin console and create new ones | Old secret key is in the history (S-01) | ⚠️ To do |
| Change the `Admin1` / `Admin2` passwords on any copy of the system that is still running | Old default password is in the history (S-03) | ⚠️ To do |

Rewriting the Git history to remove the old values is possible, but it changes every commit and would break my partner's copy of the repository. Changing the passwords is safer and makes the old values useless.
