#pragma checksum "C:\Users\Gerard\Documents\Master-FullStack\2_Net_Core\4_NetCore\MiProyectoCore\ProyectoEjecutables\ProyectoEjecutables\Views\Identity\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1a00348b414acbba71c259ec93054f3b120396f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Identity_Login), @"mvc.1.0.view", @"/Views/Identity/Login.cshtml")]
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
#line 1 "C:\Users\Gerard\Documents\Master-FullStack\2_Net_Core\4_NetCore\MiProyectoCore\ProyectoEjecutables\ProyectoEjecutables\Views\_ViewImports.cshtml"
using ProyectoEjecutables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Gerard\Documents\Master-FullStack\2_Net_Core\4_NetCore\MiProyectoCore\ProyectoEjecutables\ProyectoEjecutables\Views\_ViewImports.cshtml"
using ProyectoEjecutables.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a00348b414acbba71c259ec93054f3b120396f1", @"/Views/Identity/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3704ad3a8ee66099663d5425680c7dad23be5552", @"/Views/_ViewImports.cshtml")]
    public class Views_Identity_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"d-flex flex-column align-items-center justify-content-center\" style=\"margin-top: 60px;\">\r\n\r\n");
#nullable restore
#line 3 "C:\Users\Gerard\Documents\Master-FullStack\2_Net_Core\4_NetCore\MiProyectoCore\ProyectoEjecutables\ProyectoEjecutables\Views\Identity\Login.cshtml"
 if (@ViewData["mensaje"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-danger text-center\" alert-dismissible fade show\" role=\"alert\">\r\n        ");
#nullable restore
#line 6 "C:\Users\Gerard\Documents\Master-FullStack\2_Net_Core\4_NetCore\MiProyectoCore\ProyectoEjecutables\ProyectoEjecutables\Views\Identity\Login.cshtml"
   Write(ViewData["mensaje"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">&times;</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 11 "C:\Users\Gerard\Documents\Master-FullStack\2_Net_Core\4_NetCore\MiProyectoCore\ProyectoEjecutables\ProyectoEjecutables\Views\Identity\Login.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"shadow p-3 bg-white rounded\" style=\"width: 23rem;\">\r\n        <h1 class=\"display-4 text-center\" style=\"margin-bottom: 50px;\">\r\n            Log In\r\n        </h1>\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1a00348b414acbba71c259ec93054f3b120396f15204", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <input type=""email"" name=""correo"" class=""form-control rounded-pill""
                       placeholder=""Correo"" required autofocus />
            </div>

            <div class=""form-group"">
                <input type=""password"" name=""password"" class=""form-control rounded-pill""
                       placeholder=""Contraseña"" required />
            </div>

            <button type=""submit"" class=""btn btn-primary btn-block rounded-pill"">
                Iniciar sesión
            </button>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
