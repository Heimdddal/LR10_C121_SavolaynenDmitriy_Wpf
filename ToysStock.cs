using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;


using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace LR10_C121_SavolaynenDmitriy_Wpf
{
    internal class ToysStock : List<ToyInfo>
    {
        public static void saveToJson(string filename, List<ToyInfo> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filename, json);
        }
        public static void saveToWord(List<ToyInfo> data)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Add();

            Word.Paragraph title = document.Paragraphs.Add();
            title.Range.Text = "Состояние склада на " + DateTime.Now.ToLongDateString();
            title.set_Style("Заголовок 1");
            title.Range.InsertParagraphAfter();
            // добавление таблицы
            Word.Paragraph tableParag = document.Paragraphs.Add();
            Word.Table tableRange = document.Tables.Add(tableParag.Range, data.Count + 1, 7);
            tableRange.Borders.InsideLineStyle = tableRange.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            tableRange.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            tableRange.Cell(1, 1).Range.Text = "Название";
            tableRange.Cell(1, 2).Range.Text = "Название фирмы";
            tableRange.Cell(1, 3).Range.Text = "Возраст";
            tableRange.Cell(1, 4).Range.Text = "Дата изготовления";
            tableRange.Cell(1, 5).Range.Text = "Цена";
            tableRange.Cell(1, 6).Range.Text = "Скидка";
            tableRange.Cell(1, 7).Range.Text = "Наличие на складе";
            tableRange.Rows[1].Range.Bold = 1;
            tableRange.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            // заполнение
            int indexRow = 2;
            foreach (var dataToy in data)
            {
                tableRange.Cell(indexRow, 1).Range.Text = dataToy.Name;
                tableRange.Cell(indexRow, 2).Range.Text = dataToy.FactoryName;
                tableRange.Cell(indexRow, 3).Range.Text = dataToy.Age;
                tableRange.Cell(indexRow, 4).Range.Text = dataToy.Price.ToString();
                tableRange.Cell(indexRow, 5).Range.Text = dataToy.Discount;
                tableRange.Cell(indexRow, 6).Range.Text = dataToy.ProductionDate;
                if(dataToy.OnStock) tableRange.Cell(indexRow, 7).Range.Text = "Да";
                else tableRange.Cell(indexRow, 7).Range.Text = "Нет";
                indexRow++;
            }

            application.Visible = true;
            try
            {
                document.SaveAs2("datas.docx");
                document.SaveAs2(@"datas.docx", Word.WdExportFormat.wdExportFormatPDF);
            }
            catch (Exception)
            { }
        }

    }
}
