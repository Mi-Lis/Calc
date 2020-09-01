using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Calc
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            EnterBox.Text += btn.Content.ToString();
        }
        private void Calc_CLick(object sender, RoutedEventArgs e)
        {
            try
            {
                string math = EnterBox.Text;
                string value = new DataTable().Compute(math, null).ToString();
                EnterBox.Text = value;
            }
            catch {
                EnterBox.Text = "Ошибка";
                Thread.Sleep(300);
                EnterBox.Text = "";
                  }
            finally 
            {
                string math = EnterBox.Text;
                string value = new DataTable().Compute(math, null).ToString();
                EnterBox.Text = value;
            }
            
        }

        private void CE_Click(object sender, RoutedEventArgs e)
        {
            EnterBox.Text = "";
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            string newText = EnterBox.Text;
            if(newText == null || newText.Length == 0)
            {
                EnterBox.Text = "Ошибка";
            }
            else
            {
                EnterBox.Text = newText.Substring(0, newText.Length - 1);
            }
        }
    }
}
