using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AGR.MyElements
{
    /// <summary>
    /// Логика взаимодействия для NumberBoxWLabel.xaml
    /// </summary>
    public partial class NumberBoxWLabel : UserControl
    {
        public NumberBoxWLabel()
        {
            InitializeComponent();
        }

        private void TBox_KeyDown(object sender, KeyEventArgs e)
        {
            char key = e.Key.ToString()[0];
            if (!char.IsControl(key) && !char.IsDigit(key))
            {
                e.Handled = true;
            }
        }

        private void TBox_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        //  private void textBox_KeyUp(object sender, KeyPressEventArgs e) { }
    }
}
