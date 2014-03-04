using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * 此类未完成， 规划中这个类可以实现类似C语言中读取xlsx的功能。
 * */

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace TLibCS.Protocol
{
    class TXLSXReader : TReader
    {
        public TXLSXReader(string fileName, uint rowBind)
            : base(null)
        {
            SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Open(fileName, false);
            WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
            WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
            SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
            string text;
            foreach (Row r in sheetData.Elements<Row>())
            {
                foreach (Cell c in r.Elements<Cell>())
                {
                    text = c.CellValue.Text;
                    Console.Write(text + " ");
                }
            }
        }
    }
}
