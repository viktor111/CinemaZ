#pragma checksum "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f51368bac19d63d5633e2c42605d3a9c0c942c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Room_Room), @"mvc.1.0.view", @"/Views/Room/Room.cshtml")]
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
#line 1 "D:\programming\c#\CinemaZ\CinemaZ\Views\_ViewImports.cshtml"
using CinemaZ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml"
using CinemaZ.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f51368bac19d63d5633e2c42605d3a9c0c942c7", @"/Views/Room/Room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b58e39e157da7f128683228ff0bc523b189cc3a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Room_Room : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Room>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml"
 foreach (var seat in Model.Seats)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Room Id: ");
#nullable restore
#line 10 "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml"
           Write(seat.RoomId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Row:");
#nullable restore
#line 11 "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml"
      Write(seat.RowId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p>Col: ");
#nullable restore
#line 12 "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml"
       Write(seat.ColumnId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <hr />\r\n");
#nullable restore
#line 14 "D:\programming\c#\CinemaZ\CinemaZ\Views\Room\Room.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Room> Html { get; private set; }
    }
}
#pragma warning restore 1591