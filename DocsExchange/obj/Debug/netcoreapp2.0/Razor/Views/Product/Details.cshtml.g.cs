#pragma checksum "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8585d5cfc6a0dc613f7cc2e456c1d77b72fb0973"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Product/Details.cshtml", typeof(AspNetCore.Views_Product_Details))]
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
#line 1 "D:\INTITA\InternetStore\DocsExchange\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "D:\INTITA\InternetStore\DocsExchange\Views\_ViewImports.cshtml"
using WebStore;

#line default
#line hidden
#line 3 "D:\INTITA\InternetStore\DocsExchange\Views\_ViewImports.cshtml"
using WebStore.Models;

#line default
#line hidden
#line 4 "D:\INTITA\InternetStore\DocsExchange\Views\_ViewImports.cshtml"
using WebStore.Models.AccountViewModels;

#line default
#line hidden
#line 5 "D:\INTITA\InternetStore\DocsExchange\Views\_ViewImports.cshtml"
using WebStore.Models.ManageViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8585d5cfc6a0dc613f7cc2e456c1d77b72fb0973", @"/Views/Product/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac6d7950fdfc2bb15233d28cba6381732ff3bebd", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebStore.ViewModels.ProductView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/arrow_left1.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
  
    ViewData["Title"] = String.Concat("Товар: ", @Model.Name);

#line default
#line hidden
            BeginContext(111, 57, true);
            WriteLiteral("\r\n<h3>Перегляд Товару</h3>\r\n\r\n<hr />\r\n<div class=\"row\">\r\n");
            EndContext();
#line 10 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
            BeginContext(215, 23, false);
#line 12 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(240, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(248, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a9297dd99124e1cbb7655d1d62820d4", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 13 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(314, 91, true);
            WriteLiteral("\r\n        <table class=\"col-md-6\">\r\n            <tr>\r\n                <td class=\"col-md-2\">");
            EndContext();
            BeginContext(406, 84, false);
#line 16 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(490, 44, true);
            WriteLiteral("</td>\r\n                <td class=\"col-md-4\">");
            EndContext();
            BeginContext(535, 94, false);
#line 17 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.DisplayFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(629, 81, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"col-md-2\">");
            EndContext();
            BeginContext(711, 91, false);
#line 20 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.LabelFor(model => model.ProductType, htmlAttributes: new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(802, 44, true);
            WriteLiteral("</td>\r\n                <td class=\"col-md-4\">");
            EndContext();
            BeginContext(847, 105, false);
#line 21 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.DisplayFor(model => model.ProductTypeName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(952, 81, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"col-md-2\">");
            EndContext();
            BeginContext(1034, 92, false);
#line 24 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.LabelFor(model => model.ProductMetal, htmlAttributes: new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1126, 44, true);
            WriteLiteral("</td>\r\n                <td class=\"col-md-4\">");
            EndContext();
            BeginContext(1171, 106, false);
#line 25 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.DisplayFor(model => model.ProductMetalName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1277, 81, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"col-md-2\">");
            EndContext();
            BeginContext(1359, 92, false);
#line 28 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.LabelFor(model => model.ProductColor, htmlAttributes: new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1451, 44, true);
            WriteLiteral("</td>\r\n                <td class=\"col-md-4\">");
            EndContext();
            BeginContext(1496, 106, false);
#line 29 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.DisplayFor(model => model.ProductColorName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1602, 81, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"col-md-2\">");
            EndContext();
            BeginContext(1684, 86, false);
#line 32 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.LabelFor(model => model.Gender, htmlAttributes: new { @class = "control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1770, 44, true);
            WriteLiteral("</td>\r\n                <td class=\"col-md-4\">");
            EndContext();
            BeginContext(1815, 98, false);
#line 33 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
                                Write(Html.EditorFor(model => model.GenderName, new { htmlAttributes = new { @class = "form-control"} }));

#line default
#line hidden
            EndContext();
            BeginContext(1913, 181, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td class=\"col-md-2\"><hr /></td>\r\n                <td class=\"col-md-4\"><hr /></td>\r\n            </tr>\r\n        </table>\r\n");
            EndContext();
#line 40 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(2101, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
            BeginContext(2111, 36, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "18ffc13b428d4ebe9062d49c48c72eaf", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 43 "D:\INTITA\InternetStore\DocsExchange\Views\Product\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2147, 37, true);
            WriteLiteral("\r\n<div style=\"margin-top: 5px\">\r\n    ");
            EndContext();
            BeginContext(2184, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33a6e7f4b7ba4d18ba2efbc7bec8d3ba", async() => {
                BeginContext(2206, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c499e994401e4d1e8b7be453760b1c44", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2242, 13, true);
                WriteLiteral(" До списку...");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2259, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebStore.ViewModels.ProductView> Html { get; private set; }
    }
}
#pragma warning restore 1591