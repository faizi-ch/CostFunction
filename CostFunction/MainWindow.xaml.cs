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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

namespace CostFunction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        private int total = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void XTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (XTextEdit.Text != "")
                {
                    XList.Items.Add(XTextEdit.Text);
                }
                XTextEdit.Text = "";
            }
        }

        private void YTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (YTextEdit.Text != "")
                {
                    YList.Items.Add(YTextEdit.Text);
                }
                YTextEdit.Text = "";
            }
        }

        private void TotalTextEdit_EditValueChanging(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
            if (TotalTextEdit.Text != "")
            {
                total = Convert.ToInt32(TotalTextEdit.Text);
            }
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double h = 0, j = 0;
            total = Convert.ToInt32(TotalTextEdit.Text);
            if (Theta0TextEdit.Text != "" && Theta1TextEdit.Text != "" && XList.Items.Count>0 && YList.Items.Count>0)
            {
                for (int i = 0; i < total; i++)
                {
                    h = Convert.ToDouble(Theta0TextEdit.Text) + Convert.ToDouble(Theta1TextEdit.Text) * Convert.ToDouble(XList.Items[i]);

                    j += Math.Pow((h - Convert.ToDouble(YList.Items[i])), 2);
                    CalculatedList.Items.Add(h.ToString());
                }
                //MessageBox.Show(j.ToString());
                double m = (2 * total);
                double d = 1 / m;
                j *= d;

                CalculatedLabel.Content += j.ToString();
            }

            
        }
    }
}
