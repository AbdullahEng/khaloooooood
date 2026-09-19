using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace AdmissionSystem.Services
{
    /// <summary>
    /// Safe handling of the files students upload (ID card front/back, certificate, payment receipt).
    ///
    /// Before this helper, upload paths were built from the file name sent by the browser, so a crafted
    /// name such as "..\..\web.config" could write or delete files outside wwwroot/Uploads, and the
    /// FileStream objects were never closed (which is why the old code called GC.Collect()).
    /// </summary>
    public static class UploadFiles
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
        private static readonly char[] ForbiddenCharacters = { ':', '*', '?', '"', '<', '>', '|' };

        /// <summary>Full path of wwwroot/Uploads (created if it does not exist yet).</summary>
        public static string Folder(string webRootPath)
        {
            var folder = Path.Combine(webRootPath, "Uploads");
            Directory.CreateDirectory(folder);
            return folder;
        }

        /// <summary>
        /// Builds a new, unguessable file name: "&lt;identity number&gt;_&lt;random id&gt;&lt;extension&gt;".
        /// Anything that is not an image keeps a ".blocked" suffix, so the static file
        /// middleware will never serve it back to a browser (no HTML/SVG/script uploads).
        /// </summary>
        public static string NewFileName(string identityNo, string originalFileName)
        {
            var extension = Path.GetExtension(CleanName(originalFileName)).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
            {
                extension += ".blocked";
            }

            var prefix = CleanName(identityNo);
            var randomPart = Guid.NewGuid().ToString("N");
            return string.IsNullOrEmpty(prefix) ? randomPart + extension : prefix + "_" + randomPart + extension;
        }

        /// <summary>
        /// Reduces any value to a single, harmless file name (no folders, no drive letters,
        /// no ".." and no characters that Windows does not allow in file names).
        /// </summary>
        public static string CleanName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            // Keep only the last part of the path, whatever separator the browser used.
            var name = fileName.Replace('\\', '/');
            name = name.Substring(name.LastIndexOf('/') + 1);

            foreach (var character in ForbiddenCharacters)
            {
                name = name.Replace(character, '_');
            }

            name = new string(name.Where(character => !char.IsControl(character)).ToArray());
            name = name.Trim().TrimEnd('.');
            return name;
        }

        /// <summary>Saves the upload and always closes the file (no more locked files).</summary>
        public static void Save(IFormFile file, string fullPath)
        {
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        /// <summary>Deletes an old upload if it is really a file (never a folder).</summary>
        public static void DeleteIfExists(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
