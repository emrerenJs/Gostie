#pragma checksum "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1a165b7c6b9d6f32e35eedec897a80647063010"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ProductDetails), @"mvc.1.0.view", @"/Views/Home/ProductDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1a165b7c6b9d6f32e35eedec897a80647063010", @"/Views/Home/ProductDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Gostie.Models.Home.ProductDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToBasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("action"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:300px; height:300px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("210"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("240"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
  
    ViewData["Title"] = "ProductDetails";
    Layout = "_HomeLayout";
    int price = 0;
    int mainPrice = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"card card-header p-5\">\r\n        <div class=\"container-fliud\">\r\n");
#nullable restore
#line 11 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
             if (Model.Product.Discount > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"p-1 bg-danger text-white\" style=\"width:100px; font-size:12px; border-radius:5px\">\r\n                    İNDİRİMLİ ÜRÜN\r\n                </div>\r\n");
#nullable restore
#line 16 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"wrapper row\">\r\n                <div class=\"details col-md-6 mb-5\">\r\n                    <h3 class=\"product-title\">");
#nullable restore
#line 19 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                         Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                    <div class=""rating"">
                        <div class=""stars"">
                            <span class=""fa fa-star checked""></span>
                            <span class=""fa fa-star checked""></span>
                            <span class=""fa fa-star checked""></span>
                            <span class=""fa fa-star""></span>
                            <span class=""fa fa-star""></span>
                        </div>
");
#nullable restore
#line 28 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                         if (Model.Product.Discount > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span style=\"font-size:14px; color:#808080;\" class=\"review-no\">\r\n                                (indirimsiz fiyat : ");
#nullable restore
#line 31 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                               Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("₺)\r\n");
#nullable restore
#line 32 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                  
                                    mainPrice = Convert.ToInt32(Model.Product.Price - Model.Product.Price * Model.Product.Discount / 100);
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </span><br />\r\n");
#nullable restore
#line 36 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div>\r\n");
#nullable restore
#line 40 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                  
                                    mainPrice = Model.Product.Price;
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n");
#nullable restore
#line 44 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"review-no\">(");
#nullable restore
#line 45 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                            Write(Model.Product.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Adet)</span>\r\n                    </div>\r\n                    <p class=\"product-description\">");
#nullable restore
#line 47 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                              Write(Model.Product.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <h4 class=\"price\">Fiyat : <span>");
#nullable restore
#line 48 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                               Write(mainPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(",00₺</span></h4>\r\n");
#nullable restore
#line 49 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                     if (@Model.Product.Quantity == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"action\">\r\n                            <input type=\"hidden\" name=\"id\"");
            BeginWriteAttribute("value", " value=\"", 2434, "\"", 2466, 1);
#nullable restore
#line 52 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 2442, Model.Product.ProductID, 2442, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <button class=\"add-to-cart btn btn-danger disabled\" type=\"submit\">Stokta ürün yok</button>\r\n                        </div>\r\n");
#nullable restore
#line 55 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1a165b7c6b9d6f32e35eedec897a8064706301011509", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2862, "\"", 2894, 1);
#nullable restore
#line 59 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 2870, Model.Product.ProductID, 2870, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <button class=\"add-to-cart btn btn-default\" type=\"submit\">Sepete ekle</button>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 62 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div class=\"preview col-md-6\">\r\n                    <div class=\"float-right\">\r\n                        <div>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e1a165b7c6b9d6f32e35eedec897a8064706301014387", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3222, "~/images/products/", 3222, 18, true);
#nullable restore
#line 66 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
AddHtmlAttributeValue("", 3240, Model.Product.Picture, 3240, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>

<div class=""container mt-5"">
    <div class=""newestHeader pl-5 pr-5"">
        <div class=""newestText border-bottom text-center"">
            <h1 class=""text-warning"">Benzer Ürünler</h1>
        </div>
    </div>
    <div id=""newestCarouselControls"" class=""carousel slide"" data-ride=""carousel"">
        <div class=""carousel-inner pl-5 pr-5"">
            <!---->
");
#nullable restore
#line 84 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
              
                int rowCount = Model.SimiliarProducts.Count / 4;
                if (rowCount == 0 && Model.SimiliarProducts.Count % 4 != 0)
                    rowCount = 1;
                int columnCount = 0;
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
             for (int i = 0; i < Model.SimiliarProducts.Count; i += 4)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 92 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                 if (i + 4 > Model.SimiliarProducts.Count)
                {
                    columnCount = Model.SimiliarProducts.Count % 4;
                }
                else
                {
                    columnCount = 4;
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 100 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                 if (i == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item active\">\r\n                        <div class=\"row w-100\">\r\n");
#nullable restore
#line 104 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                             for (int j = i; j < i + columnCount; j++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"mt-2 mb-2 col-lg-3 d-flex justify-content-center align-items-center\">\r\n                                    <div class=\"productBox shadow-sm\">\r\n");
#nullable restore
#line 108 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                         if (Model.SimiliarProducts[j].Discount > 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div style=\"position:absolute; padding:2px 6px 2px 6px; border-radius:5px;text-decoration-line:line-through\" class=\"bg-danger text-white\">\r\n                                            ");
#nullable restore
#line 111 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                       Write(Model.SimiliarProducts[j].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(",00₺\r\n");
#nullable restore
#line 112 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                              
                                                price = Convert.ToInt32(Model.SimiliarProducts[j].Price - Model.SimiliarProducts[j].Price * Model.SimiliarProducts[j].Discount / 100);
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n");
#nullable restore
#line 116 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                        }
                                        else
                                        {
                                            price = Model.SimiliarProducts[j].Price;
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"productBox-header\">\r\n                                            <div class=\"productBox-mosaic\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 6012, "\"", 6103, 1);
#nullable restore
#line 123 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 6019, Url.Action("ProductDetails","Home",new {id = @Model.SimiliarProducts[j].ProductID}), 6019, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary text-light\">Detaylar</a>\r\n                                            </div>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e1a165b7c6b9d6f32e35eedec897a8064706301020968", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6260, "~/images/products/", 6260, 18, true);
#nullable restore
#line 125 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
AddHtmlAttributeValue("", 6278, Model.SimiliarProducts[j].Picture, 6278, 34, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
                                        <div class=""dropdown-divider"" style=""margin:0!important""></div>
                                        <div class=""productBox-container"">
                                            <div class=""productBox-name font-weight-bold text-center"" style=""font-size:14px"">
                                                ");
#nullable restore
#line 130 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                           Write(Model.SimiliarProducts[j].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                                            </div>
                                            <div class=""productBox-bottom"">
                                                <div class=""productBox-price"">
                                                    <span class=""productBox-priceINT"">");
#nullable restore
#line 134 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                                                                 Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span><span class=""productBox-priceFLOAT"">,00₺</span>
                                                </div>
                                                <div class=""productBox-quantity text-muted"">
                                                    <i class=""fas fa-box""></i> ");
#nullable restore
#line 137 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                                                          Write(Model.SimiliarProducts[j].Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 143 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 146 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item\">\r\n                        <div class=\"row w-100\">\r\n");
#nullable restore
#line 151 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                             for (int j = i; j < i + columnCount; j++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"mt-2 mb-2 col-lg-3 d-flex justify-content-center align-items-center\">\r\n                                    <div class=\"productBox shadow-sm\">\r\n");
#nullable restore
#line 155 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                         if (Model.SimiliarProducts[j].Discount > 0)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <div style=\"position:absolute; padding:2px 6px 2px 6px; border-radius:5px;text-decoration-line:line-through\" class=\"bg-danger text-white\">\r\n                                                ");
#nullable restore
#line 158 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                           Write(Model.SimiliarProducts[j].Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(",00₺\r\n");
#nullable restore
#line 159 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                                  
                                                    price = Convert.ToInt32(Model.SimiliarProducts[j].Price - Model.SimiliarProducts[j].Price * Model.SimiliarProducts[j].Discount / 100);
                                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </div>\r\n");
#nullable restore
#line 163 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                        }
                                        else
                                        {
                                            price = Model.SimiliarProducts[j].Price;
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <div class=\"productBox-header\">\r\n                                            <div class=\"productBox-mosaic\">\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 9386, "\"", 9477, 1);
#nullable restore
#line 170 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
WriteAttributeValue("", 9393, Url.Action("ProductDetails","Home",new {id = @Model.SimiliarProducts[j].ProductID}), 9393, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary text-light\">Detaylar</a>\r\n                                            </div>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e1a165b7c6b9d6f32e35eedec897a8064706301028498", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 9634, "~/images/products/", 9634, 18, true);
#nullable restore
#line 172 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
AddHtmlAttributeValue("", 9652, Model.SimiliarProducts[j].Picture, 9652, 34, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
                                        <div class=""dropdown-divider"" style=""margin:0!important""></div>
                                        <div class=""productBox-container"">
                                            <div class=""productBox-name font-weight-bold text-center"" style=""font-size:14px"">
                                                ");
#nullable restore
#line 177 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                           Write(Model.SimiliarProducts[j].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
                                            </div>
                                            <div class=""productBox-bottom"">
                                                <div class=""productBox-price"">
                                                    <span class=""productBox-priceINT"">");
#nullable restore
#line 181 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                                                                 Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span><span class=""productBox-priceFLOAT"">,00₺</span>
                                                </div>
                                                <div class=""productBox-quantity text-muted"">
                                                    <i class=""fas fa-box""></i> ");
#nullable restore
#line 184 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                                                                          Write(Model.SimiliarProducts[j].Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 190 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 193 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 193 "C:\Users\fanor\source\repos\Gostie\Gostie\Views\Home\ProductDetails.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <a class=""carousel-control-prev"" href=""#newestCarouselControls"" role=""button"" data-slide=""prev"">
            <i class=""fas fa-angle-left text-warning"" style=""font-size:50px"" aria-hidden=""true""></i>
        </a>
        <a class=""carousel-control-next"" href=""#newestCarouselControls"" role=""button"" data-slide=""next"">
            <i class=""fas fa-angle-right text-warning"" style=""font-size:50px"" aria-hidden=""true""></i>
        </a>
    </div>
</div>


<div class=""container d-flex justify-content-center mt-5"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <h5>Yorumlarını yazın</h5>
        </div>
        <div class=""col-lg-12 mt-3 mb-3"">
            <textarea rows=""4"" placeholder=""Açıklamanız.."" class=""form-control"">

            </textarea>
        </div>
        <div class=""col-lg-12"">
            <button class=""btn btn-warning text-light float-right"">
                Gönder
            </button>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gostie.Models.Home.ProductDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
