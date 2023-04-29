using System.Windows.Controls;
using System.Windows.Media;

namespace Ivana.Core
{
    public static class TextBoxExtensions
    {
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
