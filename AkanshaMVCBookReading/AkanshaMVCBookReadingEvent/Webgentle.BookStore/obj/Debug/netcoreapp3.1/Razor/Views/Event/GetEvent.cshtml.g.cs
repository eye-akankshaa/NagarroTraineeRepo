#pragma checksum "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2dd0430071f102e85c8495c204986366af1f2fb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_GetEvent), @"mvc.1.0.view", @"/Views/Event/GetEvent.cshtml")]
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
#line 1 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\_ViewImports.cshtml"
using Webgentle.BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dd0430071f102e85c8495c204986366af1f2fb8", @"/Views/Event/GetEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49a40fdf9b3d05334ce9cccf0d22bf655e310486", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_GetEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/book/book1.jpg?auto=yes&bg=777&fg=555&text=First slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("First slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/book/book2.jpg?auto=yes&bg=666&fg=444&text=Second slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Second slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/book/book3.jpg?auto=yes&bg=555&fg=333&text=Third slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Third slide"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
  
    ViewData["Title"] = "Book detail " + Model.Title;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container"">
    <h3 class=""display-4"">Event details</h3>
    <div class=""row"">
        <div class=""col-md-6"">
            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                <ol class=""carousel-indicators"">
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""0"" class=""active""></li>
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""1""></li>
                    <li data-target=""#carouselExampleIndicators"" data-slide-to=""2""></li>
                </ol>
                <div class=""carousel-inner"">
                    <div class=""carousel-item active"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2dd0430071f102e85c8495c204986366af1f2fb86690", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                    <div class=\"carousel-item\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2dd0430071f102e85c8495c204986366af1f2fb87988", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </div>\n                    <div class=\"carousel-item\">\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2dd0430071f102e85c8495c204986366af1f2fb89286", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                </div>
                <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <h1>");
#nullable restore
#line 41 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                   Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n                </div>\n            </div>\n\n\n            <div class=\"row\">\n                <div class=\"col-md-12\">\n                    <p class=\"description\">\n                        ");
#nullable restore
#line 49 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                   Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-md-12 text-primary"">
                    <span class=""label label-primary"">Date: </span>
                    <span class=""monospaced"">");
#nullable restore
#line 56 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                                        Write(Model.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                </div>\n            </div>\n            <div class=\"row\">\n                <div class=\"col-md-12 text-primary\">\n                    <span class=\"label label-primary\">Location: </span>\n                    <span class=\"monospaced\">");
#nullable restore
#line 62 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                                        Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                </div>\n            </div>\n            <div class=\"row\">\n                <div class=\"col-md-12 text-primary\">\n                    <span class=\"label label-primary\">StartTime: </span>\n                    <span class=\"monospaced\">");
#nullable restore
#line 68 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                                        Write(Model.startTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                </div>\n            </div>\n            <div class=\"row\">\n                <div class=\"col-md-12 text-primary\">\n                    <span class=\"label label-primary\">Duration: </span>\n                    <span class=\"monospaced\">");
#nullable restore
#line 74 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                                        Write(Model.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                </div>\n            </div>\n\n            <div class=\"row\">\n                <div class=\"col-md-12 text-primary\">\n                    <span class=\"label label-primary\">EventType: </span>\n                    <span class=\"monospaced\">");
#nullable restore
#line 81 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Event\GetEvent.cshtml"
                                        Write(Model.eventType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n                </div>\n            </div>\n\n\n\n            <hr />\n\n\n        </div>\n    </div>\n\n    <hr />\n\n  \n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
