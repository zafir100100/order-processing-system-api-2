using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using ICABAPI.Data;
using ICABAPI.DTOs;
using ICABAPI.Interfaces;
using ICABAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ICABAPI.Controllers
{
    public class MemberPdfController : BaseApiAdminController
    {
        private readonly PdfService _pdfGenerator;
        private readonly IConverter _converter;
        private readonly ModelContext _context;
        
        public MemberPdfController(IConverter converter, PdfService pdfGenerator, ModelContext context)
        {
            
            _context = context;
            _converter = converter;
            _pdfGenerator = pdfGenerator;

        }
        
        [HttpGet]
        public IActionResult CreatePDF()
        {

            var data = _context.Members.ToList();
            // foreach(var i in data.ToList())
            // {
            //     var globalSettings = new GlobalSettings
            // {
            //     ColorMode = ColorMode.Color,
            //     Orientation = Orientation.Portrait,
            //     PaperSize = PaperKind.A4,
            //     Margins = new MarginSettings { Top = 10 },
            //     DocumentTitle = "PDF Report",
            //    // Out = @"D:\PDFCreator\Member_Report.pdf"
            // };
            // var objectSettings = new ObjectSettings
            // {
            //     PagesCount = true,

            //     HtmlContent = _pdfGenerator.GetHtml(i.MemId),

            //     HeaderSettings = { FontName = "Arial", FontSize = 8, Right = "Page [page] of [toPage]", Line = true },
            //     FooterSettings = { FontName = "Arial", FontSize = 8, Line = true, Center = "Report Footer" }
            // };
            // var pdf = new HtmlToPdfDocument()
            // {
            //     GlobalSettings = globalSettings,
            //     Objects = { objectSettings }
            // };
            // var file = _converter.Convert(pdf);
            // return File(file, "application/pdf");
            // }
            // return Ok();

            List<ObjectSettings> objects = new List<ObjectSettings>();
            foreach (var i in data)
            {
                objects.Add(new ObjectSettings()
                {
                    HtmlContent = _pdfGenerator.GetHtml(i.MemId),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    // Page = detailUrl,
                    PagesCount = true,
                    //  WebSettings = { DefaultEncoding = "utf-8"  },
                    FooterSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 },
                });
            }
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings =
                {
                    DocumentTitle = $"Report - {DateTime.Today.Year}",
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Landscape,
                    Out = @"D:\PDFCreator\Member_Report.pdf"
                }
            };
            foreach (var objectSetting in objects)
            {
                doc.Objects.Add(objectSetting);
            }

            //  byte[] pdf = _converter.Convert(doc);

            var file = _converter.Convert(doc);
            // return File(file, "application/pdf");
            //var file = _converter.Convert(pdf);
            return Ok("Successfully Downloaded PDF document.");
        }
    }
}