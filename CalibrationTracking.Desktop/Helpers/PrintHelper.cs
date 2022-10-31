using ClosedXML.Excel;
using ControlzEx.Standard;
using DocumentFormat.OpenXml.Spreadsheet;
using Spire.Xls;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Workbook = Spire.Xls.Workbook;

public sealed class PrintHelper
{   
    public static void  PrintCalibration(string calibrationSKU,
                                     string employeeId,
                                     string employee,
                                     string department,
                                     string description,
                                     string device,
                                     string frequency,
                                     string from,
                                     DateTime createdAt,
                                     string orderSku)
    {
        string filePath = Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\"), "Resources\\Print.xlsx");
        var fileName = Path.Combine(System.IO.Path.GetFullPath(@$"..\..\..\"), $"Resources\\{DateTime.Now.Millisecond}.xlsx");

        using var wbook = new XLWorkbook(filePath);


        wbook.Worksheet(1).Range("D2:F2").Merge().SetValue(createdAt.ToLocalTime().ToString("d"))
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        wbook.Worksheet(1).Range("D2:F2").Merge()
            .Style.Font.SetFontSize(15);



        wbook.Worksheet(1).Range("B4:C4").Merge().SetValue(employee);   
        wbook.Worksheet(1).Range("G4:H4").Merge().SetValue(department);
        wbook.Worksheet(1).Range("B6:C6").Merge().SetValue(device);
        wbook.Worksheet(1).Range("G6:H6").Merge().SetValue(description);
        wbook.Worksheet(1).Range("A8:E8").Merge()
                            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); ;

        

        wbook.Worksheet(1).Range("A8:E8").Style.Font.FontSize = 30;


        wbook.Worksheet(1).Cell("G9").SetValue(frequency).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        wbook.Worksheet(1).Range("B9:C9").Merge().SetValue(calibrationSKU);


        wbook.Worksheet(1).Cell("B12").SetValue(createdAt.ToLocalTime());
        wbook.Worksheet(1).Range("B24:C24").Merge().SetValue(from);
        wbook.Worksheet(1).Range("E24:F24").Merge().SetValue(employeeId);

        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        Image img = b.Encode(BarcodeLib.TYPE.CODE39, calibrationSKU, Color.Black, Color.White, 330, 50);

        using var ms = new MemoryStream();
        img.Save(ms, ImageFormat.Png);

        wbook.Worksheet(1).AddPicture(ms)
         .MoveTo(wbook.Worksheet(1).Cell(8, 7));
             

        wbook.SaveAs(fileName);

        CreatePdf(fileName);

    
    }

 
    protected static void CreatePdf(string fileName)
    {
        using Workbook workbook = new Spire.Xls.Workbook();

        workbook.LoadFromFile(fileName);

        PrintDialog dialog = new PrintDialog();
        dialog.UserPageRangeEnabled = true;
        PageRange rang = new PageRange(1, 3);
        dialog.PageRange = rang;
        PageRangeSelection seletion = PageRangeSelection.UserPages;
        dialog.PageRangeSelection = seletion;

        workbook.Worksheets[1].PageSetup.IsFitToPage = true;

        PrintWorkbook(fileName, workbook, dialog);
    }

    protected static void PrintWorkbook(string fileName, Workbook workbook, PrintDialog dialog)
    {
        PrintDocument pd = workbook.PrintDocument;

        if (dialog.ShowDialog() == true)
        {
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4Landscape", 827, 1169);
            pd.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            pd.Print();


            File.Delete(fileName);


        }
    }
}