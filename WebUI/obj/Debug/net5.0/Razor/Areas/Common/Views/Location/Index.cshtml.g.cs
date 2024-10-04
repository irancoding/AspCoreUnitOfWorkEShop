#pragma checksum "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9be09a8b575c39fdcd57e7c72d83a9bf546e0861"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Common_Views_Location_Index), @"mvc.1.0.view", @"/Areas/Common/Views/Location/Index.cshtml")]
namespace AspNetCore
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
#line 1 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml"
using Infrastructure.Utils.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml"
using Domain.Enum;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9be09a8b575c39fdcd57e7c72d83a9bf546e0861", @"/Areas/Common/Views/Location/Index.cshtml")]
    public class Areas_Common_Views_Location_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/areas/baseInfo/bank/script.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml"
  
    ViewData["Title"] = "انواع سند";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml"
Write(Html.RenderAction("_Partials", "Dashboard", new { Area = "User"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""d-flex flex-wrap justify-content-between align-items-center px-5 mt-5"">
    <div class=""right"">
        <div class=""d-flex align-items-center gap-2 dir-rtl"">
            <a class=""nav-link btn btn-primary p-2 rounded-1 h-50px w-50px rounded-pill d-flex align-items-center justify-content-center"" aria-current=""page"" href=""#"" onclick=""_Create()"">
                <svg height=""20px"" width=""20px"" viewBox=""0 0 20 20"" xmlns=""http://www.w3.org/2000/svg"" fill=""none""><g id=""SVGRepo_bgCarrier"" stroke-width=""0""></g><g id=""SVGRepo_tracerCarrier"" stroke-linecap=""round"" stroke-linejoin=""round""></g><g id=""SVGRepo_iconCarrier""> <path fill=""#ffffff"" fill-rule=""evenodd"" d=""M9 17a1 1 0 102 0v-6h6a1 1 0 100-2h-6V3a1 1 0 10-2 0v6H3a1 1 0 000 2h6v6z""></path> </g></svg>
            </a>
            <div class=""m-2 d-flex flex-column gap-1"">
                <h4>مکان</h4>
                <small class=""d-block text-white bg-primary p-1 text-end pe-1 ps-4"">لیست مکان های ثبت شده</small>
            </div>
        <");
            WriteLiteral("/div>\r\n    </div>\r\n    <div class=\"left d-flex align-items-center mb-3\">\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 24 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml"
Write(Html.Partial("~/Areas/Common/Views/Location/Partials/_KendoTemplate.cshtml"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"mx-10\">\r\n    ");
#nullable restore
#line 27 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Areas\Common\Views\Location\Index.cshtml"
Write(Html.RenderAction("_Read", "Location", new { Area = "Common" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9be09a8b575c39fdcd57e7c72d83a9bf546e08615809", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
