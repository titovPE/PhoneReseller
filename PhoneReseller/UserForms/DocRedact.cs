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


        /// <summary>
        /// Печатает содержимое RichTextBox (<see cref="_rich"/>) на переданной поверхности Graphics
        /// внутри области <paramref name="textArea"/>, воспроизводя форматирование (шрифт, начертание,
        /// выравнивание абзацев) с переносом слов по ширине области.
        /// Нужен потому, что стандартный <see cref="RichTextBox"/> не умеет печататься сам —
        /// метод вручную "перерисовывает" текст средствами GDI+ (Graphics.DrawString) для события
        /// PrintPage, посимвольно проходя по тексту и сравнивая шрифт каждого символа с предыдущим
        /// (Rtf не даёт прямого доступа к списку форматированных фрагментов), чтобы выделить участки
        /// с одинаковым форматированием ("прогоны").
        /// Алгоритм:
        /// 1. Инициализирует состояние печати (текущая позиция строки/страницы, область печати).
        /// 2. Идёт по тексту RichTextBox и на границах слов (пробел/таб/начало прогона) сравнивает
        ///    шрифт с шрифтом начала текущего прогона (<see cref="EqualFont"/>); внутри слова шрифт
        ///    не перепроверяется — считается таким же, как у первой буквы слова. Это осознанное
        ///    упрощение: при частых одиночных Select() на середине слова RichTextBox начинает
        ///    отдавать недостоверный шрифт отдельных символов (проверено эмпирически на реальных
        ///    документах), а смена шрифта внутри слова в шаблонах не встречается.
        /// 3. При смене шрифта или переносе строки ('\n') накопленный фрагмент передаётся в <see cref="Puts"/>.
        /// 4. На каждом переводе строки начинается новая строка (<see cref="StartNewLine"/>) с
        ///    выравниванием абзаца, взятым из RichTextBox (<see cref="AligmentConvert"/>).
        /// 5. В конце оставшийся текст также передаётся в Puts, и вызывается <see cref="EndLine"/>
        ///    для отрисовки последней строки.
        /// </summary>
        /// <param name="textArea">Прямоугольная область на странице, в которую печатается текст
        /// (обычно область печати за вычетом полей, см. printDocument1_PrintPage).</param>
        /// <param name="currentGraphics">Поверхность Graphics текущей печатаемой страницы
        /// (e.Graphics из PrintPageEventArgs), на которой непосредственно рисуется текст.</param>
        public void FillGraphics(RectangleF textArea, Graphics currentGraphics)
        {
            BeginPrint(textArea, currentGraphics);
            var text = _rich.Text;
            if (text.Length == 0) return;

            var start = 0;
            var currentFont = SelectCharFont(0);
            var stringFormat = new StringFormat
            {
                Trimming = StringTrimming.Word,
                Alignment = AligmentConvert(_rich.SelectionAlignment)
            };
            StartLine(stringFormat);

            for (var pos = 0; pos < text.Length; pos++)
            {
                if (text[pos] == '\n')
                {
                    Puts(text.Substring(start, pos - start + 1), currentFont);
                    start = pos + 1;
                    if (start < text.Length)
                    {
                        currentFont = SelectCharFont(start);
                        StartNewLine(CloneFormatWithCurrentAlignment(stringFormat));
                    }
                    continue;
                }

                if (!IsFontCheckPoint(text, pos, start)) continue;

                var font = SelectCharFont(pos);
                if (EqualFont(font, currentFont)) continue;

                Puts(text.Substring(start, pos - start), currentFont);
                start = pos;
                currentFont = font;
            }

            if (start < text.Length) Puts(text.Substring(start), currentFont);
            EndLine();
        }

        /// <summary>
        /// Сбрасывает состояние печати (накопленную строку, текущую позицию/строку и область/поверхность
        /// вывода) перед началом обхода нового документа в <see cref="FillGraphics"/>.
        /// </summary>
        private void BeginPrint(RectangleF textArea, Graphics currentGraphics)
        {
            _lineText = new List<TextElement>();
            _textArea = textArea;
            _currentGraphics = currentGraphics;
            _currentPosition = _textArea.Left;
            _currentLine = _textArea.Top;
        }

        /// <summary>
        /// Выделяет в <see cref="_rich"/> ровно один символ по позиции <paramref name="pos"/> и
        /// возвращает его шрифт. Единственное место в классе, где читается шрифт из RichTextBox —
        /// намеренно всегда выделяется один символ (а не растущий диапазон), поскольку на растущих/
        /// повторных выделениях RichTextBox отдаёт нестабильный (иногда неверный) шрифт.
        /// </summary>
        private Font SelectCharFont(int pos)
        {
            _rich.Select(pos, 1);
            return _rich.SelectionFont;
        }

        /// <summary>
        /// Определяет, нужно ли на позиции <paramref name="pos"/> перечитывать шрифт из RichTextBox.
        /// Шрифт проверяется только в начале текущего прогона, на пробеле/табе и сразу после него —
        /// то есть на границах слов; внутри слова шрифт считается неизменным (см. примечание в
        /// <see cref="FillGraphics"/> про недостоверность RichTextBox на частых одиночных Select()).
        /// </summary>
        private static bool IsFontCheckPoint(string text, int pos, int start)
        {
            if (pos == start) return true;
            if (IsWordBoundary(text[pos])) return true;
            return pos > 0 && IsWordBoundary(text[pos - 1]);
        }

        private static bool IsWordBoundary(char c)
        {
            return c == ' ' || c == '\t';
        }

        /// <summary>
        /// Копирует <paramref name="baseFormat"/>, подставляя выравнивание абзаца из текущего
        /// выделения в <see cref="_rich"/> (устанавливается непосредственно перед вызовом, см.
        /// <see cref="SelectCharFont"/> в месте вызова).
        /// </summary>
        private StringFormat CloneFormatWithCurrentAlignment(StringFormat baseFormat)
        {
            return new StringFormat(baseFormat) {Alignment = AligmentConvert(_rich.SelectionAlignment)};
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
            if (textFont == null) textFont = _rich.Font;
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
            if (f1 == null || f2 == null) return false;
            return (Math.Abs(f1.Size - f2.Size) < 0.001) && (f1.Name == f2.Name);
        }
    }
}
