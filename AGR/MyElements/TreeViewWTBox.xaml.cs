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

namespace AGR
{
    /// <summary>
    /// Логика взаимодействия для TreeViewWTBox.xaml
    /// </summary>
    public partial class TreeViewWTBox : UserControl
    {
        public TreeViewWTBox()
        {
            InitializeComponent();
        }
        public void AddItem(TreeViewItem item, string s) 
        {
            AddSItem(s, item);
        }
        public void AddItem(TreeViewItem item, string Type, string s, object obj) 
        {
            

            
                if (Type == "System.Boolean")
                {
                    if (obj!=null)
                        AddChItem(s, Convert.ToBoolean(obj),item);
                    else
                        AddChItem(s,item);
                } else if (Type == "System.Int32")
                {
                    if (obj!=null)
                        AddTItem(s, obj.ToString(),item);
                    else
                        AddTItem(s,item);
                } else 
                {
                    AddSItem(s,item);
                }

            

        }

        // Добавление строки в дерево
        public void AddSItem(string s, TreeViewItem t)
        {
            var item = new TreeViewItem();
            item.Header = s;
            if (t == null)
                Tree.Items.Add(item);
            else
                t.Items.Add(item);

        }

        // Добавление строки и текстбокс в дерево
        public void AddTItem(string s1, string s2, TreeViewItem t)
        {
            var item = new TreeViewItem(); 
            TextBoxWLabel tB = new TextBoxWLabel();           
            tB.TBlock.Text = s1;
            tB.TBox.Text = s2;
            item.Header = tB;
            if (t == null)
                Tree.Items.Add(item);
            else
                t.Items.Add(item);

        }

        // Добавление строки и текстбокс в дерево
        public void AddTItem(string s, TreeViewItem t)
        {

            var item = new TreeViewItem();
            TextBoxWLabel tB = new TextBoxWLabel();
            tB.TBlock.Text = s;
            item.Header = tB;
            if (t == null)
                Tree.Items.Add(item);
            else
                t.Items.Add(item);
        }
        
        // Добавление строки и чекбокс в дерево
        public void AddChItem(string s, bool b, TreeViewItem t)
        {
            var item = new TreeViewItem();
            CheckBoxWLabel ChB = new CheckBoxWLabel();         
            ChB.TBlock.Text = s;
            ChB.ChBox.IsChecked = b;
            item.Header = ChB;
            if (t == null)
                Tree.Items.Add(item);
            else
                t.Items.Add(item);
        }

        // Добавление строки и чекбокс в дерево
        public void AddChItem(string s, TreeViewItem t)
        {
            var item = new TreeViewItem();
            CheckBoxWLabel ChB = new CheckBoxWLabel();
            ChB.TBlock.Text = s;
            ChB.ChBox.IsChecked = true;
            item.Header = ChB;
            if (t == null)
                Tree.Items.Add(item);
            else
                t.Items.Add(item);
        }


    }
}
