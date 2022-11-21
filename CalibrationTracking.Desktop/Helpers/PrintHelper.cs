using CalibrationTracking.Desktop.Properties;
using ClosedXML.Excel;
using ControlzEx.Standard;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Workbook = Spire.Xls.Workbook;

public sealed class PrintHelper
{
    public static void PrintCalibration(string calibrationSKU,
                                     string employee,
                                     string department,
                                     string description,
                                     string device,
                                     string frequency,
                                     DateTime createdAt, 
                                     int orderSku)
    {
        string path = System.IO.Path.GetFullPath(@"..\..\..\");
        string printfilePath = Path.Combine(path, "Resources\\Print.xlsx");
        string createdfileName = Path.Combine(path, $"Resources\\{DateTime.Now.Millisecond}.xlsx");

        CreateWorksheet(calibrationSKU, employee, department, description, device, frequency, createdAt, printfilePath, createdfileName, orderSku);
        PrintCreatedWorksheet(createdfileName);


    }

    private static void CreateWorksheet(string calibrationSKU, string employee, string department, string description, string device, string frequency, DateTime createdAt, string printfilePath, string createdfileName, int orderSku)
    {
        using var wbook = new XLWorkbook(printfilePath);

        wbook.Worksheet(1).PageSetup.Margins.Top = 1;
        wbook.Worksheet(1).PageSetup.Margins.Bottom = 1.25;
        wbook.Worksheet(1).PageSetup.Margins.Left = 0.5;
        wbook.Worksheet(1).PageSetup.Margins.Right = 0.75;
        wbook.Worksheet(1).PageSetup.Margins.Footer = 0.15;
        wbook.Worksheet(1).PageSetup.Margins.Header = 0.30;

        wbook.Worksheet(1).PageSetup.CenterHorizontally = true;
        wbook.Worksheet(1).PageSetup.CenterVertically = true;



        wbook.Worksheet(1).Cell("D2").SetValue(createdAt.ToString("dd/MM/yyyy"))
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        wbook.Worksheet(1).Cell("D2")
            .Style.Font.SetFontSize(15);



        wbook.Worksheet(1).Range("E3:F3").Merge().SetValue(orderSku.ToString())
           .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        wbook.Worksheet(1).Range("E3:F3").Merge()
           .Style.Font.SetFontSize(18).Font.SetBold();


        wbook.Worksheet(1).Range("B4:C4").Merge().SetValue(employee);
        wbook.Worksheet(1).Range("G4:H4").Merge().SetValue(department);
        wbook.Worksheet(1).Range("B6:C6").Merge().SetValue(device);
        wbook.Worksheet(1).Range("G6:H6").Merge().SetValue(description);
        wbook.Worksheet(1).Range("A8:E8").Merge()
                            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);



        wbook.Worksheet(1).Range("A8:E8").Style.Font.FontSize = 30;


        wbook.Worksheet(1).Cell("G9").SetValue(frequency).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        wbook.Worksheet(1).Range("B9:C9").Merge().SetValue(calibrationSKU);


        wbook.Worksheet(1).Range("B12:C12").Merge().SetValue(createdAt.ToString("dd/MM/yyyy")).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        Image img = b.Encode(BarcodeLib.TYPE.CODE39, calibrationSKU, Color.Black, Color.White, 350, 40);

        using var ms = new MemoryStream();
        img.Save(ms, ImageFormat.Png);

        wbook.Worksheet(1).AddPicture(ms)
         .MoveTo(wbook.Worksheet(1).Cell(8, 8));





        Image iconImage = (Image)new Bitmap(Resources.heblogo_blue__002_);


        using var ms1 = new MemoryStream();

        iconImage.Save(ms1, ImageFormat.Png);


        //wbook.Worksheet(1).AddPicture(ms1)
        // .MoveTo(wbook.Worksheet(1).Cell(8, 8));

         wbook.Worksheet(1).AddPicture(ms1)
           .MoveTo(wbook.Worksheet(1).Cell(2, 4))
           .ScaleWidth(.2)
           .ScaleHeight(.3);

        wbook.SaveAs(createdfileName);
    }

    private static void PrintCreatedWorksheet(string fileName)
    {
        using Workbook workbook = new Workbook();

        workbook.LoadFromFile(fileName);

        PrintDialog dialog = new PrintDialog();
        dialog.UserPageRangeEnabled = true;
        PageRange rang = new PageRange(1, 1);
        dialog.PageRange = rang;
        PageRangeSelection seletion = PageRangeSelection.UserPages;
        dialog.PageRangeSelection = seletion;

        workbook.Worksheets[1].PageSetup.IsFitToPage = true;

        PrintWorksheet(fileName, workbook, dialog);
    }

    private static void PrintWorksheet(string fileName, Workbook workbook, PrintDialog dialog)
    {
        PrintDocument pd = workbook.PrintDocument;

        //if (dialog.ShowDialog() == true)
        //{
        //    pd.DefaultPageSettings.Landscape = true;
        //    pd.DefaultPageSettings.PaperSize = new PaperSize("A4Landscape", 827, 1169);
        //    pd.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
        //    pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

        //    pd.Print();


        //    File.Delete(fileName);


        //}


        pd.DefaultPageSettings.Landscape = true;
        pd.DefaultPageSettings.PaperSize = new PaperSize("A4Landscape", 827, 1169);
        pd.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
        pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

        pd.Print();


        File.Delete(fileName);
    }
}