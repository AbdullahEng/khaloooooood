#pragma checksum "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58c72344808d8dc476aade744068517d0e7217b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AdmissionSystem.Pages.Employee.Views_Employee_Index_Status_of_student), @"mvc.1.0.view", @"/Views/Employee/Index_Status_of_student.cshtml")]
namespace AdmissionSystem.Pages.Employee
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
#nullable restore
#line 2 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58c72344808d8dc476aade744068517d0e7217b2", @"/Views/Employee/Index_Status_of_student.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"792ef5c687352aadb354ab4da2dda25055305126", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Employee_Index_Status_of_student : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AdmissionSystem.View_Model.Statues_of_Student_EmployeeId>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/aos/aos.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "loak_Syrian", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/aos/aos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
  
    ViewData["Title"] = "Index_Status_of_student";
    Layout = "_EmployeeLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style> 
.ContainerRegForm {
    position: center;
    /* width: 75%;
    height:75%;*/
    margin: 10px auto;
    padding: 10px 20px;
    border-radius: 4px;
    box-sizing: border-box;
    background: #fff;
    box-shadow: 0 5px 20px rgba(0, 0, 0, .4);
}
 </style>
 ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58c72344808d8dc476aade744068517d0e7217b26540", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n <h5>");
#nullable restore
#line 25 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
Write(localizer["Welcom"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 25 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
                     Write(Model.Employee.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n <div class=\"ContainerRegForm\"  data-aos=\"zoom-in-up\">\r\n<h1 class=\"text-center\">Syrian Students</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n               id\r\n            </th>\r\n             <th>\r\n             ");
#nullable restore
#line 37 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
        Write(localizer["Student full name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("  \r\n            </th>\r\n             <th>\r\n              ");
#nullable restore
#line 40 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
         Write(localizer["Country"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n            </th>\r\n            <th>\r\n              ");
#nullable restore
#line 43 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
         Write(localizer["Checking Recipt"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n               ");
#nullable restore
#line 46 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
          Write(localizer["Checking identity"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n              ");
#nullable restore
#line 49 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
         Write(localizer["Checking Certificate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n              ");
#nullable restore
#line 52 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
         Write(localizer["Checking Rate"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 59 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
 foreach (var item in Model.ListaOfStudent) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr cla>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.FK_Student_Info.First_Name_AR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                 ");
#nullable restore
#line 66 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
            Write(Html.DisplayFor(modelItem => item.FK_Student_Info.Nick_Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 69 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.FK_Student_Info.Cirtificate_city.country_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 72 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.Checked_recipet));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 75 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.Checked_Identity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 78 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.Checked_city_certificate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 81 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
           Write(Html.DisplayFor(modelItem => item.Checked_Rate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58c72344808d8dc476aade744068517d0e7217b213945", async() => {
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58c72344808d8dc476aade744068517d0e7217b214224", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 86 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
                                           WriteLiteral(Model.Employee.id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "58c72344808d8dc476aade744068517d0e7217b216833", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 87 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.statusId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
                                                 WriteLiteral(item.id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    <button class=\"btn btn-warning\">");
#nullable restore
#line 88 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
                                               Write(localizer["Checking"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 92 "C:\Users\khale\Desktop\viersion 57\khaloooooood\AdmissionSystem\AdmissionSystem\Views\Employee\Index_Status_of_student.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<hr><hr><hr><hr><hr><hr><hr><hr><hr><hr>\r\n</div>\r\n ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58c72344808d8dc476aade744068517d0e7217b221362", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n <script>\r\n      AOS.init({\r\n      offset: 200,\r\n      duration: 600,\r\n      easing: \'ease-in-sine\',\r\n      delay: 100,\r\n    });\r\n</script>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer localizer { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AdmissionSystem.View_Model.Statues_of_Student_EmployeeId> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591