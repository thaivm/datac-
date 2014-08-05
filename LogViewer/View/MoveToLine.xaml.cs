using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace LogViewer.View
{
    /// <summary>
    /// Interaction logic for MoveToLine.xaml
    /// </summary>
    public partial class MoveToLine : Window
    {

        private string strPreviousString;
        private bool bIsPasteOperation = false;
        public MoveToLine()
        {
            InitializeComponent();
            MoveToLine_LineNumber_Textbox.Focus();
        }
        private void MoveToLine_Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MoveToLine_Button_JumpTo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private Boolean TextBoxTextAllowed(String Text2)
        {
            return Array.TrueForAll<Char>(Text2.ToCharArray(),
                delegate(Char c) { return Char.IsDigit(c) || Char.IsControl(c); });
        }

        private void MoveToLine_LineNumber_Textbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextBoxTextAllowed(e.Text);
        }

        private void MoveToLine_LineNumber_Textbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Key.V == e.Key && Keyboard.Modifiers == ModifierKeys.Control)
            {
                strPreviousString = this.MoveToLine_LineNumber_Textbox.Text;
                bIsPasteOperation = true;
            }
            else
            {
                strPreviousString = this.MoveToLine_LineNumber_Textbox.Text;
            }
        }

        private void MoveToLine_LineNumber_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (true == bIsPasteOperation)
            {
                if (false == this.IsNumber(this.MoveToLine_LineNumber_Textbox.Text))
                {
                    this.MoveToLine_LineNumber_Textbox.Text = strPreviousString;
                    e.Handled = true;
                }
                if (IsOver(this.MoveToLine_LineNumber_Textbox.Text))
                {
                    this.MoveToLine_LineNumber_Textbox.Text = strPreviousString;
                    e.Handled = true;
                }
                bIsPasteOperation = false;
            }
            else
            {
                if (IsOver(this.MoveToLine_LineNumber_Textbox.Text))
                {
                    this.MoveToLine_LineNumber_Textbox.Text = strPreviousString;
                    e.Handled = true;
                }
            }
        }
        private bool IsOver(string str)
        {
            bool flag = true;
            if (str.Trim().Equals(String.Empty))
            {
                return false;
            }
            string content = MoveToLine_Warning_Lable.Content.ToString();
            try
            {
                double max = Convert.ToDouble(Regex.Split(content, Properties.Resources.Max)[1]);
                if (Convert.ToDouble(str) <= max)
                {
                    return false;
                }
            }
            catch { return false; }
            return flag;
        }
        private bool IsNumber(string text)
        {
            int number;

            //Allowing only numbers
            if (!(int.TryParse(text, out number)))
            {
                return false;
            }
            return true;
        }
    }
}
