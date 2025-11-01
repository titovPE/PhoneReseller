using LicenseGenerator.Data;
using PhoneReseller.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LicenseGenerator.UserForms
{
    public partial class DocPrinter : Form
    {
        readonly ColumnsDictionary _phoneInfo;

        readonly Dictionary<string, string> _localization = new Dictionary<string, string> 
        {
           {"адрес"             ,"Addres"},
           {"ФИО"               ,"FIO"},
           {"ПаспортСерия"      ,"PasportSer"},
           {"ПаспортНомер"      ,"PasportNum"},
           {"ПаспортВыдан"      ,"PasportIssuedBy"},
           {"Стоимость"         ,"Cost"},
           {"ДатаПокупки"       ,"BuyDate"},
           {"ИМЕИ"              ,"Imei"},
           {"МодельТелефона"    ,"Model"},
           {"АКБномер"          ,"AkbNumber"},
           {"АКБсостояние"      ,"AkbState"},
           {"ВыявленныеДеффекты","BaseDefect"},
           {"Состояние"         ,"State"},
           {"Комплектность"     ,"ComplectSet"},
           {"Примечания"        ,"Notes"},
           {"Принял"            ,"Acceptor"},

           {"ПеревелНаПродажу"  ,"Worker"},
           {"ДатаПроверки"      ,"DateApprowed"},
           {"НайденныеДеффекты" ,"DetectDefects"},
           {"Ремонтировался"    ,"IsRepared"},
           {"СтоимостьРемонта"  ,"WorkCost"},
           {"ОтчетПоРемонту"    ,"WorkReport"},
           {"Наценка"           ,"Margin"},

           {"ДатаПродажи"       ,"SellDate"},
           {"Продавец"          ,"Seller"},
           {"Цена"              ,"SalePrice"},
           {"Rec"               ,"ПокупкаТелефона"},
           {"ToSell"            ,"Ценник"},
           {TableNames.Sold              ,"ПродажаТелефона"}

            
        };

        public DocPrinter()
        {
            InitializeComponent();
        }

        public DocPrinter(ColumnsDictionary phoneInfo)
        {
            var path = Application.StartupPath;
            InitializeComponent();
            var docName = _localization["Rec"];
            if (_localization.ContainsKey(phoneInfo.TableName)) docName = _localization[phoneInfo.TableName];
            TextBox1.LoadFile(path + "\\Docs\\" + docName + ".rtf");

            _phoneInfo = phoneInfo;
            ReplaceLabels(Regex.Matches(TextBox1.Text, "#Label(\\w*)"));
            if (printPreviewDialog1 != null)
            {
                printPreviewDialog1.ShowDialog();
            }
        }

        public void ReplaceLabels(MatchCollection matches)
        {
            for (int i = matches.Count - 1; i > -1; i--)
            {
                var m = matches[i];
                var g = m.Groups[1];
                TextBox1.Select(m.Index, m.Length);
                var replace = _localization[g.Value];
                if (!_phoneInfo.ContainsKey(replace)) replace = "";
                else
                {
                    if (replace.IndexOf("Date") > -1)
                    {
                        var date = SQLiteDataConverter.ToDate(_phoneInfo[replace]);
                        replace = date.ToShortDateString();
                    }
                    else
                        replace = _phoneInfo[replace];
                }
                TextBox1.SelectedText = replace;
            }

        }



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var graphics = e.Graphics;
            RectangleF rectFull;

            if (graphics.VisibleClipBounds.X < 0) rectFull = e.MarginBounds;
            else
                //Определяем   объект  rectanglefFull
                rectFull = new RectangleF(
                    //Устанавливаем координату  X  
                e.MarginBounds.Left - (e.PageBounds.Width - graphics.VisibleClipBounds.Width) / 2,
                    //Устанавливаем координату  Y
                e.MarginBounds.Top - (e.PageBounds.Height - graphics.VisibleClipBounds.Height) / 2,
                    //Устанавливаем ширину области
                e.MarginBounds.Width,
                    //Устанавливаем высоту области
                e.MarginBounds.Height);

            var printer = new RichPrinter(TextBox1);
            printer.FillGraphics(rectFull, graphics);
        }

    }


    public class RichPrinter
    {
        class TextElement
        {
            public TextElement(string text, Font font, float width)
            {
                Width = width;
                Text = text;
                Font = font;
            }
            public string Text;
            public Font Font;
            public float Width;
        }


        readonly RichTextBox _rich;

        float _lineHeight;
        StringFormat _lineFormat;
        List<TextElement> _lineText;
        float _currentPosition;

        float _currentLine;
        RectangleF _textArea;
        Graphics _currentGraphics;

        public RichPrinter(RichTextBox rich)
        {
            _rich = rich;
        }


        public void FillGraphics(RectangleF textArea, Graphics currentGraphics)
        {
            _lineText = new List<TextElement>();
            _textArea = textArea;
            _currentGraphics = currentGraphics;
            _currentPosition = _textArea.Left;
            _currentLine = _textArea.Top;
            var stringFormat = new StringFormat {Trimming = StringTrimming.Word};
            var start = 0;
            var length = 1;
            _rich.Select(start, length);
            var etalon = _rich.SelectionFont;
            stringFormat.Alignment = AligmentConvert(_rich.SelectionAlignment);
            StartLine(stringFormat);
            for (; start + length < _rich.Text.Length; length++)
            {
                _rich.Select(start, length);
                if (_rich.Text[start + length - 1] == '\n')
                {
                    Puts(_rich.SelectedText, etalon);
                    start += length;
                    length = 0;
                    _rich.Select(start, length + 1);
                    etalon = _rich.SelectionFont;
                    var format = new StringFormat(stringFormat)
                                              {Alignment = AligmentConvert(_rich.SelectionAlignment)};
                    StartNewLine(format);
                    continue;
                }
                if (EqualFont(_rich.SelectionFont, etalon)) continue;
                _rich.Select(start, length - 1);
                Puts(_rich.SelectedText, etalon);
                start += length - 1;
                length = 1;
                _rich.Select(start, length);
                etalon = _rich.SelectionFont;
            }
            _rich.Select(start, length + 1);
            Puts(_rich.SelectedText, _rich.SelectionFont);
            EndLine();
        }


        public void StartLine(StringFormat format)
        {
            _lineFormat = format;
        }
        public void StartNewLine(StringFormat format)
        {
            EndLine();
            StartLine(format);
        }
        public void Puts(string text, Font textFont)
        {
            if (_lineHeight < textFont.Height) _lineHeight = textFont.Height;
            var lineSize = new SizeF(_textArea.Left + _textArea.Width - _currentPosition, textFont.Height);
            int charCount;
            int strCount;
            var width = _currentGraphics.MeasureString(text, textFont, lineSize, _lineFormat, out charCount, out strCount).Width;
            _currentPosition += width;
            var str = text.Substring(0, charCount);
            _lineText.Add(new TextElement(str, textFont, width));
            if (charCount >= text.Length) return;
            EndLine();
            Puts(text.Substring(charCount), textFont);
        }
        public void EndLine()
        {
            int start;
            int end;
            int i;
            float position;
            GetRange(out start, out  end, out  i, out position);
            for (; start != end; start = start + i)
            {
                var item = _lineText[start];
                var top = _currentLine + _lineHeight - item.Font.Height;
                var left = position;
                _currentGraphics.DrawString(item.Text, item.Font, new SolidBrush(Color.Black), left, top, _lineFormat);
                position += item.Width * i;

            }
            _lineText.Clear();
            _currentLine += _lineHeight;
            _lineHeight = 0;
            _currentPosition = _textArea.Left;
        }

        public void GetRange(out int start, out int end, out int i, out float position)
        {
            if (_lineFormat.Alignment == StringAlignment.Near)
            {
                position = _textArea.Left;
                start = 0;
                i = 1;
                end = _lineText.Count;
                return;
            }
            if (_lineFormat.Alignment == StringAlignment.Far)
            {
                position = _textArea.Left + _textArea.Width;
                start = _lineText.Count - 1;
                i = -1;
                end = -1;
                return;
            }
            if (_lineFormat.Alignment == StringAlignment.Center)
            {
                var length = _lineText.Sum(item => item.Width);

                position = _textArea.Left + (_textArea.Width - length) / 2;
                start = 0;
                i = 1;
                end = _lineText.Count;
                return;
            }
            position = _textArea.Left;
            start = 0;
            i = 1;
            end = _lineText.Count;
        }


        public StringAlignment AligmentConvert(HorizontalAlignment aligment)
        {
            if (aligment == HorizontalAlignment.Left) return StringAlignment.Near;
            if (aligment == HorizontalAlignment.Right) return StringAlignment.Far;
            return aligment == HorizontalAlignment.Center ? StringAlignment.Center : StringAlignment.Near;
        }

        public bool EqualFont(Font f1, Font f2)
        {
            if (f1 == null) return false;
            return (Math.Abs(f1.Size - f2.Size) < 0.001) && (f1.Name == f2.Name);
        }
    }
}
