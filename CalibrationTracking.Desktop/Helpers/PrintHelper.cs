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
    public static void PrintCalibration(string calibrationSKU,
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
        string path = System.IO.Path.GetFullPath(@"..\..\..\");
        string printfilePath = Path.Combine(path, "Resources\\Print.xlsx");
        string createdfileName = Path.Combine(path, $"Resources\\{DateTime.Now.Millisecond}.xlsx");

        CreateWorksheet(calibrationSKU, employeeId, employee, department, description, device, frequency, from, orderSku, printfilePath, createdfileName);
        PrintCreatedWorksheet(createdfileName);


    }

    private static void CreateWorksheet(string calibrationSKU, string employeeId, string employee, string department, string description, string device, string frequency, string from, string orderSku, string printfilePath, string createdfileName)
    {
        using var wbook = new XLWorkbook(printfilePath);

        wbook.Worksheet(1).Range("D2:F2").Merge().SetValue(orderSku);
        wbook.Worksheet(1).Range("B4:C4").Merge().SetValue(employee);
        wbook.Worksheet(1).Range("G4:H4").Merge().SetValue(department);
        wbook.Worksheet(1).Range("B6:C6").Merge().SetValue(device);
        wbook.Worksheet(1).Range("G6:H6").Merge().SetValue(description);
        wbook.Worksheet(1).Range("A8:E8").Merge().SetValue($"*{calibrationSKU}*").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); ;



        wbook.Worksheet(1).Range("A8:E8").Style.Font.FontSize = 30;


        wbook.Worksheet(1).Cell("G9").SetValue(frequency).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        wbook.Worksheet(1).Range("B9:C9").Merge().SetValue(calibrationSKU);


        wbook.Worksheet(1).Cell("B12").SetValue(DateTime.Now.ToString("d"));
        wbook.Worksheet(1).Range("B24:C24").Merge().SetValue(from);
        wbook.Worksheet(1).Range("E24:F24").Merge().SetValue(employeeId);


        wbook.Worksheet(1).Cell("A28").SetValue(calibrationSKU);
        wbook.Worksheet(1).Cell("B28").SetValue(description);
        wbook.Worksheet(1).Cell("C28").SetValue(device);
        wbook.Worksheet(1).Cell("D28").SetValue(frequency);
        wbook.Worksheet(1).Cell("E28").SetValue(from);
        wbook.Worksheet(1).Cell("G28").SetValue(department);
        wbook.Worksheet(1).Cell("F28").SetValue(orderSku);
        wbook.Worksheet(1).Cell("H28").SetValue(DateTime.Now.ToString("d"));

        wbook.SaveAs(createdfileName);
    }

    private static void PrintCreatedWorksheet(string fileName)
    {
        using Workbook workbook = new Workbook();

        workbook.LoadFromFile(fileName);

        PrintDialog dialog = new PrintDialog();
        dialog.UserPageRangeEnabled = true;
        PageRange rang = new PageRange(1, 3);
        dialog.PageRange = rang;
        PageRangeSelection seletion = PageRangeSelection.UserPages;
        dialog.PageRangeSelection = seletion;

        workbook.Worksheets[1].PageSetup.IsFitToPage = true;

        PrintWorksheet(fileName, workbook, dialog);
    }

    private static void PrintWorksheet(string fileName, Workbook workbook, PrintDialog dialog)
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