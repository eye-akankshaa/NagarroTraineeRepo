#pragma checksum "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "998238ead9c2cc575d2cc912c61a8e27c7a39db6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
using Webgentle.BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"998238ead9c2cc575d2cc912c61a8e27c7a39db6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49a40fdf9b3d05334ce9cccf0d22bf655e310486", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EventModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/book/book1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "bookDetailsRoute", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
   ViewData["Title"] = "Home"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<section class=\"jumbotron text-center\">\r\n    <div class=\"container\">\r\n        <h1>Welcome to Book Reading Events</h1>\r\n    </div>\r\n</section>\r\n\r\n");
#nullable restore
#line 12 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Public events";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n\r\n    <div class=\"col-6\">\r\n        <div class=\"container\">\r\n            <h3 class=\"display-4\">Upcoming Events</h3>\r\n            <div class=\"row\">\r\n\r\n");
#nullable restore
#line 25 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                 if(Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                     foreach (var bookevent in Model)
                    {
                        if (bookevent.eventType == "Public" && bookevent.Date > DateTime.Now)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-4\">\r\n                                <div class=\"card mb-4 shadow-sm\">\r\n\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "998238ead9c2cc575d2cc912c61a8e27c7a39db66097", async() => {
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
            WriteLiteral("\r\n\r\n                                    <div class=\"card-body\">\r\n                                        <h3 class=\"card-title\">");
#nullable restore
#line 37 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                                                          Write(bookevent.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                        <p class=\"card-text\">Description: ");
#nullable restore
#line 38 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                                                                     Write(bookevent.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                                        <div class=\"d-flex justify-content-between align-items-center\">\r\n                                            <div class=\"btn-group\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998238ead9c2cc575d2cc912c61a8e27c7a39db68285", async() => {
                WriteLiteral("View details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                                                                                  WriteLiteral(bookevent.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </div>\r\n\r\n");
            WriteLiteral("\r\n                                        </div>\r\n\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 56 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("               \r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"col-6\">\r\n        <div class=\"container\">\r\n            <h3 class=\"display-4\">Past Events</h3>\r\n            <div class=\"row\">\r\n");
#nullable restore
#line 71 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                 if(Model != null)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                     foreach (var bookevent in Model)
                    {
                        if (bookevent.eventType == "Public" && bookevent.Date < DateTime.Now)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-md-4\">\r\n                                <div class=\"card mb-4 shadow-sm\">\r\n\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "998238ead9c2cc575d2cc912c61a8e27c7a39db612656", async() => {
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
            WriteLiteral("\r\n\r\n                                    <div class=\"card-body\">\r\n                                        <h3 class=\"card-title\">");
#nullable restore
#line 83 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                                                          Write(bookevent.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                                        <p class=\"card-text\">Description: ");
#nullable restore
#line 84 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                                                                     Write(bookevent.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                                        <div class=\"d-flex justify-content-between align-items-center\">\r\n                                            <div class=\"btn-group\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "998238ead9c2cc575d2cc912c61a8e27c7a39db614845", async() => {
                WriteLiteral("View details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 88 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                                                                                  WriteLiteral(bookevent.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </div>\r\n\r\n");
            WriteLiteral("\r\n                                        </div>\r\n\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 102 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 103 "C:\Users\akanshakhandelwal\Desktop\AkanshaMVCBookReadingModified2 - Final\AkanshaMVCBookReadingEvent\Webgentle.BookStore\Views\Home\Index.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("               \r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            //alert(\"document is ready\");\r\n        })\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EventModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
