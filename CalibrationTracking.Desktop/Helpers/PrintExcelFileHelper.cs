﻿using CalibrationTracking.CustomeControls.TableControl;
using ClosedXML.Excel;
using Spire.Xls;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Controls;

public sealed class PrintExcelFileHelper
{   
    public static void  SetExcelFile(int calibrationSKU,int employeeId, string employee, string department, string description, string device, int frequency,string from, DateTime createdAt, int orderSku)
    {
        string filePath = Path.Combine(System.IO.Path.GetFullPath(@"..\..\..\"), "Resources\\Print.xlsx");

        using var wbook = new XLWorkbook(filePath);

        wbook.Worksheet(1).Cell("B4").SetValue(employee);

        wbook.Worksheet(1).Range("D2:F2").Merge().SetValue(description);
        wbook.Worksheet(1).Range("A8:E8").Merge().SetValue($"*{calibrationSKU}*");
        wbook.Worksheet(1).Range("B6:C6").Merge().SetValue(description);
        wbook.Worksheet(1).Range("G4:H4").Merge().SetValue(device);
        wbook.Worksheet(1).Range("G6:H6").Merge().SetValue(department);

        wbook.Worksheet(1).Cell("G9").SetValue(frequency);

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


        var fileName = Path.Combine(System.IO.Path.GetFullPath(@$"..\..\..\"), $"Resources\\{DateTime.Now.Millisecond}.xlsx");

        wbook.SaveAs(fileName);

        CreatePdf(fileName);

    
    }


    private static void CreatePdf(string fileName)
    {
        Workbook workbook = new Workbook();
        workbook.LoadFromFile(fileName);

        PrintDialog dialog = new PrintDialog();
        dialog.UserPageRangeEnabled = true;
        PageRange rang = new PageRange(1, 3);
        dialog.PageRange = rang;
        PageRangeSelection seletion = PageRangeSelection.UserPages;
        dialog.PageRangeSelection = seletion;

        workbook.Worksheets[1].PageSetup.IsFitToPage = true;

        PrintDocument pd = workbook.PrintDocument;

        if (dialog.ShowDialog() == true)
        {
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.PaperSize = new PaperSize("A4Landscape", 827, 1169);
            pd.DefaultPageSettings.PaperSize.RawKind = (int)PaperKind.A4;
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);

            pd.Print();

        }
    }

}