using LicenseGenerator.Data;
using PhoneReseller.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LicenseGenerator.UserForms
{
    public partial class DocPrinter : Form
    {
        /// <summary>
        /// Метка-плейсхолдер в шаблоне: необязательный номер слота (телефона внутри группы,
        /// начиная с 1 — "#Label1ФИО") и название поля ("ФИО" и т.п., ключ <see cref="_localization"/>).
        /// Метка без номера ("#LabelФИО") равносильна номеру 1.
        /// </summary>
        private const string LabelPattern = @"#Label(?<idx>\d*)(?<field>\D\w*)";

        readonly ColumnsDictionary _phoneInfo;

        /// <summary>
        /// Страницы документа для печати — по одному <see cref="RichTextBox"/> с заполненным
        /// шаблоном на телефон. <see cref="printDocument1_PrintPage"/> печатает их по очереди,
        /// каждую на отдельной физической странице.
        /// </summary>
        readonly List<RichTextBox> _printPages = new List<RichTextBox>();
        int _printPageIndex;

        /// <summary>
        /// Индекс символа в текущей странице (<see cref="_printPages"/>[<see cref="_printPageIndex"/>]),
        /// с которого нужно продолжить печать — используется, когда текст одного телефона не
        /// поместился на одну физическую страницу и печать продолжается на следующей.
        /// </summary>
        int _printRangeStart;

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
            InitializeComponent();
            TextBox1.LoadFile(GetTemplatePath(phoneInfo.TableName));

            _phoneInfo = phoneInfo;
            ReplaceLabels(Regex.Matches(TextBox1.Text, LabelPattern));
            _printPages.Add(TextBox1);
            ShowPrintPreview();
        }

        /// <summary>
        /// Печатает несколько телефонов. Все переданные телефоны должны относиться к одной таблице
        /// (быть документами одного типа) — при попытке передать телефоны из разных таблиц печать
        /// не выполняется, вместо этого показывается предупреждение.
        /// Без <paramref name="specialDocument"/> работает как раньше: обычный шаблон таблицы
        /// (<see cref="GetTemplatePath"/>), по одному телефону на страницу.
        /// С <paramref name="specialDocument"/> телефоны группируются по
        /// <see cref="SpecialDocument.PhoneCount"/> штук, и на каждую группу печатается одна страница
        /// по шаблону <see cref="SpecialDocument.Path"/> с пронумерованными по слотам метками
        /// ("#Label1ФИО", "#Label2ФИО", ...); недостающие в последней неполной группе слоты остаются
        /// пустыми.
        /// </summary>
        /// <param name="phones">Телефоны для печати. Должны быть одного типа (одна таблица).</param>
        /// <param name="specialDocument">Необязательное описание особого шаблона на несколько
        /// телефонов на странице. Если не передан, используется обычная печать по одному телефону
        /// на страницу.</param>
        public DocPrinter(IEnumerable<ColumnsDictionary> phones, SpecialDocument specialDocument = null)
        {
            var phoneList = phones.ToList();
            if (phoneList.Count == 0) return;
            if (phoneList.Select(p => p.TableName).Distinct().Count() > 1)
            {
                MessageBox.Show(
                    "Обнаружена попытка напечатать телефоны из разных документов. Так нельзя — все телефоны должны быть одного типа.",
                    "Печать невозможна", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InitializeComponent();

            if (specialDocument == null)
            {
                var templatePath = GetTemplatePath(phoneList[0].TableName);
                foreach (var phone in phoneList)
                {
                    var page = new RichTextBox();
                    page.LoadFile(templatePath);
                    ReplaceLabels(page, new List<ColumnsDictionary> { phone }, Regex.Matches(page.Text, LabelPattern));
                    _printPages.Add(page);
                }
            }
            else
            {
                for (var offset = 0; offset < phoneList.Count; offset += specialDocument.PhoneCount)
                {
                    var group = phoneList.Skip(offset).Take(specialDocument.PhoneCount).ToList();
                    var page = new RichTextBox();
                    page.LoadFile(specialDocument.Path);
                    ReplaceLabels(page, group, Regex.Matches(page.Text, LabelPattern));
                    _printPages.Add(page);
                }
            }

            ShowPrintPreview();
        }

        private void ShowPrintPreview()
        {
            if (printPreviewDialog1 == null) return;
            printDocument1.BeginPrint += (sender, e) =>
            {
                _printPageIndex = 0;
                _printRangeStart = 0;
            };
            printPreviewDialog1.ShowDialog();
        }

        /// <summary>
        /// Возвращает путь к rtf-шаблону документа, соответствующему таблице <paramref name="tableName"/>
        /// (например, "Rec" -&gt; ПокупкаТелефона.rtf). Если для таблицы нет отдельного шаблона,
        /// используется шаблон таблицы "Rec".
        /// </summary>
        private string GetTemplatePath(string tableName)
        {
            var docName = _localization.ContainsKey(tableName) ? _localization[tableName] : _localization["Rec"];
            return Application.StartupPath + "\\Docs\\" + docName + ".rtf";
        }

        /// <summary>
        /// Подставляет в <see cref="TextBox1"/> значения полей телефона <see cref="_phoneInfo"/>
        /// вместо меток-плейсхолдеров (например, "#LabelФИО"), найденных в <paramref name="matches"/>.
        /// </summary>
        public void ReplaceLabels(MatchCollection matches)
        {
            ReplaceLabels(TextBox1, new List<ColumnsDictionary> { _phoneInfo }, matches);
        }

        /// <summary>
        /// Подставляет в <paramref name="target"/> значения полей телефонов <paramref name="phones"/>
        /// вместо меток-плейсхолдеров, найденных в <paramref name="matches"/> (см. <see cref="LabelPattern"/>).
        /// Метка состоит из номера слота (телефона в группе, начиная с 1; без номера — слот 1) и
        /// названия поля (например, "#Label2ФИО" — поле "ФИО" второго телефона в группе). Название
        /// поля сопоставляется с ключом телефона через <see cref="_localization"/>; если для номера
        /// слота не хватило телефонов в <paramref name="phones"/> или поля нет у телефона —
        /// подставляется пустая строка, а поля-даты форматируются через <see cref="SQLiteDataConverter.ToDate"/>.
        /// Проход идёт с конца, чтобы замена одной метки не сдвигала индексы (<see cref="Match.Index"/>)
        /// ещё не обработанных совпадений.
        /// </summary>
        /// <param name="target">RichTextBox с загруженным шаблоном документа, в котором заменяются метки.</param>
        /// <param name="phones">Телефоны, значения которых подставляются вместо меток — по позиции
        /// в списке (индекс 0 — слот 1, индекс 1 — слот 2 и т.д.).</param>
        /// <param name="matches">Найденные в тексте шаблона метки-плейсхолдеры (см. <see cref="LabelPattern"/>).</param>
        private void ReplaceLabels(RichTextBox target, IReadOnlyList<ColumnsDictionary> phones, MatchCollection matches)
        {
            for (int i = matches.Count - 1; i > -1; i--)
            {
                var m = matches[i];
                var idx = m.Groups["idx"].Value;
                var field = m.Groups["field"].Value;
                var slot = idx.Length == 0 ? 0 : int.Parse(idx) - 1;
                var phoneInfo = slot >= 0 && slot < phones.Count ? phones[slot] : null;

                target.Select(m.Index, m.Length);
                var key = _localization[field];
                var replace = "";
                if (phoneInfo != null && phoneInfo.ContainsKey(key))
                {
                    replace = key.IndexOf("Date") > -1
                        ? SQLiteDataConverter.ToDate(phoneInfo[key]).ToShortDateString()
                        : phoneInfo[key];
                }
                target.SelectedText = replace;
            }

        }



        /// <summary>
        /// Печатает текущую страницу (<see cref="_printPages"/>[<see cref="_printPageIndex"/>]) через
        /// <see cref="RichTextBoxPrinter"/> (нативный EM_FORMATRANGE) начиная с символа
        /// <see cref="_printRangeStart"/>. Если текст телефона не поместился на одну физическую
        /// страницу (например, из-за таблицы или длинных примечаний), печать продолжается с того же
        /// места на следующей странице; если поместился — переходит к следующему телефону.
        /// </summary>
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            var page = _printPages[_printPageIndex];
            var printedTo = RichTextBoxPrinter.Print(page, e, _printRangeStart);

            if (printedTo < page.TextLength)
            {
                _printRangeStart = printedTo;
                e.HasMorePages = true;
                return;
            }

            RichTextBoxPrinter.ReleaseCache(page);
            _printRangeStart = 0;
            _printPageIndex++;
            e.HasMorePages = _printPageIndex < _printPages.Count;
        }

    }


    /// <summary>
    /// Описание особого шаблона документа, рассчитанного на печать сразу нескольких телефонов на
    /// одной физической странице (например, лист с несколькими ценниками). Плейсхолдеры в таком
    /// шаблоне нумеруются по слотам: "#Label1ФИО", "#Label2ФИО", ... — номер соответствует
    /// порядковому номеру телефона в группе, начиная с 1 (см. <see cref="DocPrinter.LabelPattern"/>).
    /// </summary>
    public class SpecialDocument
    {
        public string Path { get; }
        public int PhoneCount { get; }

        public SpecialDocument(string path, int phoneCount)
        {
            if (phoneCount < 1)
                throw new ArgumentOutOfRangeException(nameof(phoneCount), "Количество телефонов в документе должно быть больше нуля.");
            Path = path;
            PhoneCount = phoneCount;
        }
    }

    /// <summary>
    /// Печать содержимого <see cref="RichTextBox"/> через нативное сообщение EM_FORMATRANGE (Win32
    /// RichEdit API). В отличие от прежней ручной построчной отрисовки (посимвольный обход текста и
    /// GDI+ DrawString), делегирует разметку самому движку RichEdit — поэтому корректно печатает всё,
    /// что RichTextBox умеет отображать, включая таблицы, а не только выровненные абзацы.
    /// </summary>
    internal static class RichTextBoxPrinter
    {
        private const int EM_FORMATRANGE = 0x0400 + 57; // WM_USER + 57

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin, cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public RECT rc;
            public RECT rcPage;
            public CHARRANGE chrg;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private static RECT ToTwips(Rectangle hundredthsOfInch)
        {
            return new RECT
            {
                Left = hundredthsOfInch.Left * 1440 / 100,
                Top = hundredthsOfInch.Top * 1440 / 100,
                Right = hundredthsOfInch.Right * 1440 / 100,
                Bottom = hundredthsOfInch.Bottom * 1440 / 100
            };
        }

        /// <summary>
        /// Печатает содержимое <paramref name="rich"/>, начиная с символа <paramref name="charFrom"/>,
        /// в область печати текущей страницы <paramref name="e"/>. Возвращает индекс первого символа,
        /// который уже не поместился на странице (равен <see cref="RichTextBox.TextLength"/>, если
        /// весь оставшийся текст поместился целиком) — вызывающий код по этому индексу решает, нужно
        /// ли продолжать печать того же текста на следующей странице.
        /// </summary>
        public static int Print(RichTextBox rich, PrintPageEventArgs e, int charFrom)
        {
            var hdc = e.Graphics.GetHdc();
            try
            {
                var formatRange = new FORMATRANGE
                {
                    hdc = hdc,
                    hdcTarget = hdc,
                    rc = ToTwips(e.MarginBounds),
                    rcPage = ToTwips(e.PageBounds),
                    chrg = new CHARRANGE { cpMin = charFrom, cpMax = -1 }
                };

                var formatRangePtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(formatRange));
                try
                {
                    Marshal.StructureToPtr(formatRange, formatRangePtr, false);
                    var result = SendMessage(new HandleRef(rich, rich.Handle), EM_FORMATRANGE, new IntPtr(1), formatRangePtr);
                    return result.ToInt32();
                }
                finally
                {
                    Marshal.FreeCoTaskMem(formatRangePtr);
                }
            }
            finally
            {
                e.Graphics.ReleaseHdc(hdc);
            }
        }

        /// <summary>
        /// Освобождает информацию, закэшированную RichEdit-контролом во время печати. Нужно вызвать
        /// после того, как весь текст <paramref name="rich"/> напечатан — так требует документация
        /// EM_FORMATRANGE, чтобы не оставлять закэшированное состояние между разными печатями.
        /// </summary>
        public static void ReleaseCache(RichTextBox rich)
        {
            SendMessage(new HandleRef(rich, rich.Handle), EM_FORMATRANGE, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
