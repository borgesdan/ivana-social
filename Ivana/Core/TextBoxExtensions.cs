using System.Windows.Controls;

namespace Ivana.Core
{
    public static class TextBoxExtensions
    {
        public static void ApplyDecimal(this TextBox textbox)
        {
            textbox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var currentText = textbox.Text.ApplyOnlyNumber();
                
                if(currentText.Length == 1)
                {
                    currentText = currentText.Insert(0, ",0");
                }
                else if(currentText.Length < 3)
                {
                    currentText = currentText.Insert(0, ",");
                }
                else
                {
                    currentText = currentText.Insert(currentText.Length - 2, ",");
                }

                _ = decimal.TryParse(currentText, out var value);
                textbox.Text = value.ToString("C");
                
                textbox.CaretIndex = textbox.Text.Length;
            };
        }

        public static void ApplyCPFMask(this TextBox textbox)
        {
            textbox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var currentCaretIndex = textbox.CaretIndex;

                textbox.Text = textbox.Text.ApplyOnlyNumber().ApplyCPFMask();
                textbox.CaretIndex = currentCaretIndex;
            };
        }

        public static void ApplyPhoneNumbers(this TextBox textbox)
        {
            textbox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var currentCaretIndex = textbox.CaretIndex;
                textbox.Text = textbox.Text.ApplyOnlyNumber().ApplyPhoneMask();
                textbox.CaretIndex = currentCaretIndex;
            };
        }       

        public static void ApplyOnlyNumbers(this TextBox textbox)
        {
            textbox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var currentCaretIndex = textbox.CaretIndex;
                textbox.Text = textbox.Text.ApplyOnlyNumber();
                textbox.CaretIndex = currentCaretIndex;
            };
        }

        public static void ApplyOnlyNumberOrLetter(this TextBox textbox)
        {
            textbox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var currentCaretIndex = textbox.CaretIndex;
                textbox.Text = textbox.Text.ApplyOnlyNumerOrLetter();
                textbox.CaretIndex = currentCaretIndex;
            };
        }

        public static void ApplyOnlyLetterOrWhiteSpace(this TextBox textbox)
        {
            textbox.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                var currentCaretIndex = textbox.CaretIndex;
                textbox.Text = textbox.Text.ApplyOnlyLetterOrWhiteSpace();
                textbox.CaretIndex = currentCaretIndex;
            };
        }
    }
}
