#pragma checksum "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\Shared\_GlobalView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8372635df9e8b0de6bc188da3317a7334ce5fcc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__GlobalView), @"mvc.1.0.view", @"/Views/Shared/_GlobalView.cshtml")]
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
#line 1 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\IranCoding\Projects\ASP Core\Project\AspCoreUnitOfWorkEShop\AspCoreUnitOfWorkEShop\WebUI\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8372635df9e8b0de6bc188da3317a7334ce5fcc0", @"/Views/Shared/_GlobalView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f047802d4e4541034881b5113d6b9a9923968ea3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__GlobalView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<button type=""button"" class=""btn btn-primary"" data-bs-toggle=""modal"" data-bs-target=""#commonModal"" id=""commonModalBtn"" style=""display:none"">
</button>
<div class=""modal fade in"" id=""commonModal"" data-bs-backdrop=""static"" data-bs-keyboard=""false"" style=""direction:rtl!important"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-body"" id=""commonModalBody"">
            </div>
        </div>
    </div>
</div>

<!--ajax-loading-->
<div id=""ajax-loading"" class=""d-none"" style=""z-index: 999; position: fixed; top: 0; left: 0; width: 100%; height: 100vh;"">
    <div class=""message position-fixed bottom-0 left bg-primary rounded-2 px-5 m-5"" style=""left:-30px"">
        <div class=""d-flex align-items-center"">
            <p class=""text-white"">ئر حال پردازش</p>
            <div class=""lds-facebook""><div></div><div></div><div></div></div>
        </div>

    </div>
</div>

<!--input-->
<input type=""hidden"" id=""isAuthenticated"" />
<input type=""hidden""");
            BeginWriteAttribute("name", " name=\"", 1023, "\"", 1030, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""payload"" />

<!--popup-->
<style>
    #popup_container {
        display: none;
        background-color: #fff;
        box-shadow: 0 0 16px rgb(0 0 0 / 14%);
        margin-top: 10px;
        border-radius: 20px;
    }
</style>
<div id=""popup_container"" class=""dir-rtl"">Message!</div>

<!--scrollbars-->
");
            WriteLiteral(@"
<style>
    .lds-facebook {
        display: inline-block;
        position: relative;
        width: 80px;
        height: 80px;
    }

        .lds-facebook div {
            display: inline-block;
            position: absolute;
            left: 8px;
            width: 16px;
            background: #fff;
            animation: lds-facebook 1.2s cubic-bezier(0, 0.5, 0.5, 1) infinite;
        }

            .lds-facebook div:nth-child(1) {
                left: 8px;
                animation-delay: -0.24s;
            }

            .lds-facebook div:nth-child(2) {
                left: 32px;
                animation-delay: -0.12s;
            }

            .lds-facebook div:nth-child(3) {
                left: 56px;
                animation-delay: 0;
            }

    ");
            WriteLiteral("@keyframes lds-facebook {\r\n        0% {\r\n            top: 8px;\r\n            height: 64px;\r\n        }\r\n\r\n        50%, 100% {\r\n            top: 24px;\r\n            height: 32px;\r\n        }\r\n    }\r\n</style>");
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
