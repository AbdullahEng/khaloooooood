#pragma checksum "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bf7a2eb5503f182324db498280929149ffbe102e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AdmissionSystem.Pages.Statues_Of_Student_control.Views_Statues_Of_Student_control_statusofstudnet), @"mvc.1.0.view", @"/Views/Statues_Of_Student_control/statusofstudnet.cshtml")]
namespace AdmissionSystem.Pages.Statues_Of_Student_control
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\_ViewImports.cshtml"
using AdmissionSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\_ViewImports.cshtml"
using AdmissionSystem.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf7a2eb5503f182324db498280929149ffbe102e", @"/Views/Statues_Of_Student_control/statusofstudnet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792ef5c687352aadb354ab4da2dda25055305126", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Statues_Of_Student_control_statusofstudnet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdmissionSystem.Model.Statues_Of_Student>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "statusofstudnet", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
  

    Layout = "~/Pages/Shared/_Layout_For_Admin_Dashboard.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    .content {\r\n        max-width: 500px;\r\n        margin: auto;\r\n    }\r\n</style>\r\n<h2 class=\"text-center\">Status of Studnet</h2>\r\n<br />\r\n<br />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bf7a2eb5503f182324db498280929149ffbe102e5089", async() => {
                WriteLiteral(@"
    <div class=""input-group"">
        <input type=""search"" class=""form-control bg-light border-0 small"" name=""term"" placeholder=""Student Name...""
               aria-label=""Search"" aria-describedby=""basic-addon2"">
        <div class=""input-group-append"">
            <button class=""btn btn-primary"" type=""submit"">
                <i class=""fas fa-search fa-sm""></i>
            </button>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n<br />\r\n<br />\r\n");
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.Date_of_Acshiving));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.Checked_recipet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.Checked_Identity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.Checked_city_certificate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 55 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.Checked_Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 58 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
           Write(Html.DisplayNameFor(model => model.FK_Student_Info.First_Name_EN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 64 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.Date_of_Acshiving));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 74 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.Checked_recipet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 77 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.Checked_Identity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 80 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.Checked_city_certificate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 83 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.Checked_Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 86 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
               Write(Html.DisplayFor(modelItem => item.FK_Student_Info.First_Name_EN));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
            WriteLiteral("            </tr>\r\n");
#nullable restore
#line 94 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Statues_Of_Student_control\statusofstudnet.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdmissionSystem.Model.Statues_Of_Student>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591