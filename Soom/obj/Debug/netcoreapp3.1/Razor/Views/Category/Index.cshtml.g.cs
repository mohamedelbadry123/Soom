#pragma checksum "E:\Work\Soom\Soom\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fe76c6a333df495e89a2e2ca8a7a8a5174075ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category_Index), @"mvc.1.0.view", @"/Views/Category/Index.cshtml")]
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
#line 1 "E:\Work\Soom\Soom\Views\_ViewImports.cshtml"
using Soom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Work\Soom\Soom\Views\_ViewImports.cshtml"
using Soom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fe76c6a333df495e89a2e2ca8a7a8a5174075ba", @"/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5238535008d422c1ab3b04925460e93cdb2be70f", @"/Views/_ViewImports.cshtml")]
    public class Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "E:\Work\Soom\Soom\Views\Category\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">
        <h3 class=""alert-success p-3 text-center"">All Categories</h3>
    </div>
</div>
<br />
<div class=""row"">
    <div class=""container"">
        <div class=""row"">

            <table id=""CategoryDatatable"" class=""table table-striped table-bordered"">
                <thead>
                    <tr>

                        <td>Category Name</td>
                        <td>Description</td>
                        <td>Actions</td>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>


        </div>
    </div>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            var table = $(""#CategoryDatatable"").DataTable({
                ""processing"": true,
                ""serverSide"": true,
                ""filter"": true,
                ""ajax"": {
                    ""url"": ""/categoryApi"",
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },
               
                  ""columns"": [
                    
                      { ""data"": ""name"" },
                      { ""data"": ""desc""  },
                     {
                        data: ""id"",
                        render: function (data) {
                            return ""<a class='btn btn-primary' href='/Category/Update/"" + data + ""'>Edit</a>"";
                        }
                    }
             ]
            });

          
        })

    

    </script>
");
            }
            );
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
