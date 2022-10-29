using CalibrationTracking.Desktop.Properties;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

public sealed class PrintImageHelper
{
    public static Bitmap? Tag { get; private set; }

    /// <summary>
    /// Create new tag from the cart data
    /// </summary>
    /// <returns>The new created tag</returns>
    /// 

    public static void CreateImage(string sku,string employee, string department, string description, string device,string remarks, string frequency)
    {
        Bitmap tag = Resources.CalibrationPrint;

        Brush black = Brushes.Black;
        float fontSize = 16f;
        float spacing = 120f;
        float halfWidth = 150f;

        PointF skuPos = new(halfWidth, 600f + spacing);
        PointF employeePos = new(halfWidth, spacing += 170f);
        PointF cellCountPos = new(halfWidth, spacing += 70f);
        PointF cellAgePos = new(halfWidth, spacing += 65f);
        RectangleF drawRect = new(halfWidth, spacing += 60f, 500f, 400f);
        PointF approvelPos = new(tag.Width / 2, spacing += 240f);
        PointF testerPos = new(halfWidth, spacing += 75f);
        PointF datePos = new(halfWidth, spacing += 65f);
        RectangleF barcodeRect = new(halfWidth, spacing += 80f, tag.Width - 80, 200f);

        StringFormat approvalFormat = new()
        {
            Alignment = StringAlignment.Far,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.DirectionRightToLeft | StringFormatFlags.DisplayFormatControl
        };

        StringFormat hebFormat = new()
        {
            Alignment = StringAlignment.Near,
            FormatFlags = StringFormatFlags.DirectionRightToLeft | StringFormatFlags.DisplayFormatControl
        };

        StringFormat barcodeFormat = new()
        {
            Alignment = StringAlignment.Center
        };

        using Graphics graphics = Graphics.FromImage(tag);
        using Font arialFont = new("Arial", fontSize, FontStyle.Regular);
        using Font barcodeFont = GetBarcodeFont();

        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

        graphics.DrawString(sku, arialFont, black, skuPos);
        graphics.DrawString(employee, arialFont, black, employeePos);
        graphics.DrawString(department, arialFont, black, cellCountPos);
        graphics.DrawString(description, arialFont, black, cellAgePos);
        graphics.DrawString(device, new Font("Arial", 18f, FontStyle.Bold), Brushes.White, approvelPos, barcodeFormat);
        graphics.DrawString(remarks, arialFont, black, drawRect, hebFormat);
        graphics.DrawString(frequency, arialFont, black, testerPos);
        graphics.DrawString($"*{sku}*", barcodeFont, black, barcodeRect, barcodeFormat);
        Tag = tag;
    }

    [DllImport("gdi32.dll")]
    private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

    /// <summary>
    /// Create new font object from the font in the resources
    /// </summary>
    /// <returns>Barcode font</returns>
    private static Font GetBarcodeFont()
    {
        byte[] fontData = Resources.Code39;
        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
        uint dummy = 0;
        PrivateFontCollection fonts = new();
        fonts.AddMemoryFont(fontPtr, Resources.Code39.Length);
        AddFontMemResourceEx(fontPtr, (uint)Resources.Code39.Length, IntPtr.Zero, ref dummy);
        Marshal.FreeCoTaskMem(fontPtr);
        return new Font(fonts.Families[0], 28F, FontStyle.Regular);
    }

    /// <summary>
    /// Print the tag to the default printer
    /// </summary>
    public static void Print(int numberOfCopies)
    {
        using PrintDocument doc = new();
        try
        {
            doc.DefaultPageSettings.Landscape = false;
            doc.DefaultPageSettings.Margins = new(0, 0, 0, 0);
            doc.DefaultPageSettings.PaperSize = new() { RawKind = (int)PaperKind.A6 };
            doc.DefaultPageSettings.PaperSource = new() { RawKind = (int)PaperSourceKind.Manual };
            doc.DefaultPageSettings.PrinterResolution.Kind = PrinterResolutionKind.High;
            doc.DefaultPageSettings.PrinterSettings.Copies = (short)numberOfCopies;
            doc.PrintPage += PrintPageEvent;
            doc.Print();
        }
        catch
        {
            throw;
        }
        finally
        {
            doc.Dispose();
        }
    }

    // Printing event
    private static void PrintPageEvent(object s, PrintPageEventArgs e)
    {
        float cmToUnits = 100f / 2.54f;
        float width = 17.6f * cmToUnits;
        float height = 40.6f * cmToUnits;


        e.PageSettings.PaperSize = new() { RawKind = (int)PaperKind.A4 };
        e.PageSettings.PrinterResolution.Kind = PrinterResolutionKind.High;
        e.PageSettings.PaperSource = new() { RawKind = (int)PaperSourceKind.Manual };
        e.Graphics.DrawImage(Tag, 0, 0, width, height);
    }

}