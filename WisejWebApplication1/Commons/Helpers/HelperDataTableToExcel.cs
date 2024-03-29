﻿//Helper para convertir de DataTable a excel
//Email:roberto.taveras@hotmail.com
//Date:2/21/2023 9:02:54 AM
//Autor:Alejandrina Then
//Licencia:Frederic Schad (Todos los derechos Reservados)

using SmartXLS;
using System.Data;
using System.Drawing;

namespace Common.Helpers
{
    public class HelperDataTableToExcel
    {
        private const int ROW_TITLE = 0;
        public static WorkBook MakeDataTableToExcel(DataTable senderDataTable) 
        {
            WorkBook wb = new WorkBook();
            if (senderDataTable.Columns.Count > 0 )
             {
                
                wb.ImportDataTable(senderDataTable, true, 0, 0, senderDataTable.Rows.Count, senderDataTable.Columns.Count);
                if (senderDataTable.Rows.Count > 0)
                {
                    colorFormat(wb);
                    formatingBorder(wb);
                }
             }
           return wb;      
        }
        private static void colorFormat(WorkBook workBook)
        {
            RangeStyle rangeStyle = workBook.getRangeStyle(ROW_TITLE, 0, ROW_TITLE, workBook.LastCol);
            rangeStyle.MergeCells = false;
            rangeStyle.FontBold = true;
            rangeStyle.FontColor = Color.White.ToArgb();
            rangeStyle.Pattern = RangeStyle.PatternSolid;
            rangeStyle.PatternFG = Color.FromArgb(91, 155, 213).ToArgb();
            rangeStyle.FontName = "Calibri";
            rangeStyle.FontSize = 11 * 20;
            rangeStyle.WordWrap = true;
            rangeStyle.HorizontalAlignment = RangeStyle.HorizontalAlignmentLeft;
            rangeStyle.VerticalAlignment = RangeStyle.VerticalAlignmentCenter;
            workBook.setRangeStyle(rangeStyle, ROW_TITLE, 0, ROW_TITLE, workBook.LastCol);
        }
        private static void formatingBorder(WorkBook workBook)
        {
            //Formatea las celdas(lineas) horizontales con un color azul
            RangeStyle rangeStyle = workBook.getRangeStyle(0, 0, workBook.LastRow,workBook.LastCol);
            var color = Color.LightBlue.ToArgb();
            rangeStyle.TopBorder = RangeStyle.BorderThin;
            rangeStyle.BottomBorder = RangeStyle.BorderThin;
            rangeStyle.HorizontalInsideBorder = RangeStyle.BorderThin;
            rangeStyle.HorizontalInsideBorderColor = color;
            rangeStyle.TopBorderColor = color;
            rangeStyle.BottomBorderColor = color;
            workBook.setRangeStyle(rangeStyle, 1, 0, workBook.LastRow, workBook.LastCol);
            //Formatea las celdas(lineas) verticales de la izquierda con un color azul 
            RangeStyle rangeStyleVerticalLeft = workBook.getRangeStyle(0, 0, workBook.LastRow, workBook.LastCol);
            rangeStyleVerticalLeft.LeftBorder = RangeStyle.BorderThin;
            rangeStyleVerticalLeft.VerticalInsideBorder = RangeStyle.BorderThin;
            rangeStyleVerticalLeft.VerticalInsideBorderColor = color;
            rangeStyleVerticalLeft.LeftBorderColor = color;
            workBook.setRangeStyle(rangeStyleVerticalLeft, 1, 0, workBook.LastRow, 0);
            //Formatea las celdas(lineas) verticales de la derecha con un color azul 
            RangeStyle rangeStyleVerticalRight = workBook.getRangeStyle(0, workBook.LastCol, workBook.LastRow, workBook.LastCol);
            rangeStyleVerticalRight.RightBorder = RangeStyle.BorderThin;
            rangeStyleVerticalRight.VerticalInsideBorder = RangeStyle.BorderThin;
            rangeStyleVerticalRight.VerticalInsideBorderColor = color;
            rangeStyleVerticalRight.RightBorderColor = color;
            workBook.setRangeStyle(rangeStyleVerticalRight, 0, workBook.LastCol, workBook.LastRow, workBook.LastCol);
        }
    }
}
