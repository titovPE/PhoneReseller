using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LicenseGenerator.UserForms
{
    /// <summary>
    /// Форма выбора шаблона для пакетной печати (например, ценников). Показывает выпадающий список
    /// *.rtf файлов из папки "Docs\receipts" — имя каждого файла должно начинаться с числа,
    /// означающего, сколько телефонов помещается на одной странице этого шаблона (см. <see cref="SpecialDocument"/>).
    /// По кнопке "Печать" запускает <see cref="DocPrinter"/> с выбранным шаблоном как специальным документом.
    /// </summary>
    public partial class ReceiptSelect : Form
    {
        private class TemplateItem
        {
            public string Path { get; }
            public int PhoneCount { get; }
            private readonly string _displayName;

            public TemplateItem(string path, int phoneCount, string displayName)
            {
                Path = path;
                PhoneCount = phoneCount;
                _displayName = displayName;
            }

            public override string ToString() => _displayName;
        }

        private readonly IEnumerable<ColumnsDictionary> _phones;

        public ReceiptSelect(IEnumerable<ColumnsDictionary> phones)
        {
            InitializeComponent();
            _phones = phones;
            FillTemplates();
        }

        /// <summary>
        /// Заполняет выпадающий список шаблонами из "Docs\receipts" — берутся только *.rtf файлы,
        /// имя которых начинается с числа (количество телефонов на странице шаблона). Файлы без
        /// числа в начале имени пропускаются.
        /// </summary>
        private void FillTemplates()
        {
            var receiptsPath = Path.Combine(Application.StartupPath, "Docs", "receipts");
            if (!Directory.Exists(receiptsPath)) return;

            var items = Directory.GetFiles(receiptsPath, "*.rtf")
                .Select(ParseTemplate)
                .Where(item => item != null)
                .ToList();

            comboBox1.DataSource = items;
        }

        private static TemplateItem ParseTemplate(string path)
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var match = Regex.Match(fileName, @"^(\d+)");
            if (!match.Success) return null;
            return new TemplateItem(path, int.Parse(match.Value), fileName);
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem as TemplateItem;
            if (item == null) return;
            new DocPrinter(_phones, new SpecialDocument(item.Path, item.PhoneCount));
            Close();
        }
    }
}
