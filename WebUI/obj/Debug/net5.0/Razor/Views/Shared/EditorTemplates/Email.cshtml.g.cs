#pragma checksum "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Views\Shared\EditorTemplates\Email.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1422f0aec9992e94932fe974e54c9c2923bb09d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_Email), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/Email.cshtml")]
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
#line 1 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1422f0aec9992e94932fe974e54c9c2923bb09d3", @"/Views/Shared/EditorTemplates/Email.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f047802d4e4541034881b5113d6b9a9923968ea3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_Email : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<object>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<span class=\"k-input k-textbox k-input-solid k-input-md k-rounded-md\">\r\n    ");
#nullable restore
#line 4 "D:\IranCoding\Projects\ASP Core\Project\IranCodingCQRS\WebUI\Views\Shared\EditorTemplates\Email.cshtml"
Write(Html.TextBoxFor(model => model, new { @class = "k-input-inner"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</span>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<object> Html { get; private set; }
    }
}
#pragma warning restore 1591
