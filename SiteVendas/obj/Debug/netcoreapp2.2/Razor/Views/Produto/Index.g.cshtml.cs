#pragma checksum "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c15ab1c9cf31e47d6a74070b7855a50e05c694fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produto_Index), @"mvc.1.0.view", @"/Views/Produto/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produto/Index.cshtml", typeof(AspNetCore.Views_Produto_Index))]
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
#line 1 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\_ViewImports.cshtml"
using SiteVendas;

#line default
#line hidden
#line 2 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\_ViewImports.cshtml"
using SiteVendas.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c15ab1c9cf31e47d6a74070b7855a50e05c694fb", @"/Views/Produto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45d61f069ec7065b922cbf1c6ad31423e36da4d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Produto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<business.classes.Produto>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var quantidade = Model.ToList().Count;


#line default
#line hidden
            BeginContext(135, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
            BeginContext(141, 158, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c15ab1c9cf31e47d6a74070b7855a50e05c694fb3783", async() => {
                BeginContext(147, 145, true);
                WriteLiteral("    \r\n    <input style=\"width: 40%;\" id=\"texto\" placeholder=\"Dê me o nome do produto\" type=\"text\" />\r\n    <a href=\"#\" id=\"Entrar\">Acessar</a>\r\n\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(299, 30, true);
            WriteLiteral("\r\n<hr />\r\n<hr />\r\n\r\n<h4>Lista ");
            EndContext();
            BeginContext(330, 14, false);
#line 19 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
     Write(ViewBag.pagina);

#line default
#line hidden
            EndContext();
            BeginContext(344, 93, true);
            WriteLiteral("</h4>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(438, 40, false);
#line 25 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Loja));

#line default
#line hidden
            EndContext();
            BeginContext(478, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(534, 40, false);
#line 28 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(574, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(630, 41, false);
#line 31 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(671, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 37 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(806, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(867, 42, false);
#line 41 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Loja.Id));

#line default
#line hidden
            EndContext();
            BeginContext(909, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(977, 39, false);
#line 44 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1016, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1084, 40, false);
#line 47 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(1124, 111, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a href=\"#\" id=\"acessarPagina2\" data-value=\"");
            EndContext();
            BeginContext(1236, 7, false);
#line 50 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
                                                           Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1243, 98, true);
            WriteLiteral("\" class=\"btn btn-danger btnPagina2\">Acessar pagina</a>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 53 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1352, 1111, true);
            WriteLiteral(@"    </tbody>
</table>

<input type=""number"" id=""numberLista"" style=""width: 50%;"" placeholder=""informe o numero da lista"" />
<a href=""#"" id=""acessarLista"">Acessar lista</a>

<input type=""number"" id=""numberPagina"" style=""width: 50%;"" placeholder=""informe o numero da pagina"" />
<a href=""#"" id=""acessarPagina2"" class=""btn btn-danger btnPagina"" >Acessar pagina</a>

<div class=""modal fade"" id=""myModal"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
           
            <div class=""modal-body"">
                <div id=""conteudoModal"">

                </div>
            </div>
            
        </div>
    </div>
</div>

<div class=""modal fade"" id=""myModal2"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
           
            <div class=""modal-body"">
                <div id=""conteudoModal2"">

           ");
            WriteLiteral("     </div>\r\n            </div>\r\n            \r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2480, 210, true);
                WriteLiteral("    \r\n\r\n    <script type=\"text/javascript\">\r\n        $(document).ready(function () {\r\n\r\n            $(\"#numberLista\").change(function () {\r\n                document.getElementById(\"acessarLista\").href = \"/Loja/");
                EndContext();
                BeginContext(2691, 12, false);
#line 98 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
                                                                 Write(ViewBag.loja);

#line default
#line hidden
                EndContext();
                BeginContext(2703, 229, true);
                WriteLiteral("/\";\r\n                document.getElementById(\"acessarLista\").href += $(this).val();\r\n            });\r\n\r\n            $(\"#acessarPagina\").change(function () {\r\n                document.getElementById(\"acessarPagina\").href = \"/Loja/");
                EndContext();
                BeginContext(2933, 12, false);
#line 103 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
                                                                  Write(ViewBag.loja);

#line default
#line hidden
                EndContext();
                BeginContext(2945, 213, true);
                WriteLiteral("/\";\r\n                document.getElementById(\"acessarPagina\").href += $(this).val();\r\n            });\r\n\r\n            $(\".btnPagina\").click(function () {\r\n                $(\"#conteudoModal\").load(\"/Produto/Details/");
                EndContext();
                BeginContext(3159, 12, false);
#line 108 "C:\Users\leand\Documents\Visual Studio 2017\C#\shopeeleo\shopeeleo\SiteVendas\Views\Produto\Index.cshtml"
                                                      Write(ViewBag.loja);

#line default
#line hidden
                EndContext();
                BeginContext(3171, 456, true);
                WriteLiteral(@"/"" + $(""#numberPagina"").val(), function () {
                    $(""#myModal"").modal(""show"");
                });
            });

            $("".btnPagina2"").click(function () {

                var id = $(this).data(""value"");

                $(""#conteudoModal2"").load(""/Produto/Details2/"" + id, function () {
                    $(""#myModal2"").modal(""show"");
                });
            });            

        });
    </script>

");
                EndContext();
            }
            );
            BeginContext(3630, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<business.classes.Produto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
