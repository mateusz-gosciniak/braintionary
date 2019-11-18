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
using System.Windows.Shapes;

// TODO

// wprowadzanie ręczne/głosowe

// przechwytywanie schowka

// możliwość edycji dodanych wyrazów
// możliwość posortowania słówek ręcznie
// możliwość usuwania słówek

// możliwość dodania obrazka do słówek jak i całej listy

namespace braintionary
{
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            tbTitleName.Focus();
            GlobalVariables.CurrentWordsList = string.Empty;
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbNew.Text.Equals(String.Empty) || tbOriginal.Text.Equals(String.Empty))
            {
                MessageBox.Show("Uzupełnij odpowiednio pola wyrazami");
            }
            else
            {
                GlobalVariables.Set.pack.Add(new Word() { name1 = tbOriginal.Text, name2 = tbNew.Text });
                lvWords.Items.Add(new Word() { name1 = tbOriginal.Text, name2 = tbNew.Text });
                if (cbTurnOffMessageBox.IsChecked == false)
                {
                    MessageBox.Show("Wyraz został dodany");
                }
                tbNew.Text = String.Empty;
                tbOriginal.Text = String.Empty;
                tbOriginal.Focus();
            }
        }

        private void bEnd_Click(object sender, RoutedEventArgs e)
        {
            if (tbTitleName.Text.Equals(String.Empty))
            {
                MessageBox.Show("Podaj nazwę listy.");
                return;
            }

            if (!(tbNew.Text.Equals(String.Empty) || tbOriginal.Text.Equals(String.Empty)))
            {
                GlobalVariables.Set.pack.Add(new Word() {name1 = tbOriginal.Text, name2 = tbNew.Text});

                if (cbTurnOffMessageBox.IsChecked == false)
                {
                    MessageBox.Show("Wyraz został dodany");
                }

                tbNew.Text = String.Empty;
                tbOriginal.Text = String.Empty;
            }

            GlobalVariables.CurrentWordsList = tbTitleName.Text;
            GlobalVariables.XmlTool.Save(GlobalVariables.Set, GlobalVariables.PathToList + GlobalVariables.CurrentWordsList + GlobalVariables.ExtensionWordsList);
            GlobalVariables.Set.pack.Clear();
            (new MainWindow()).Show();
            Close();
        }

        private void bSave_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.CurrentWordsList = tbTitleName.Text;
            GlobalVariables.XmlTool.Save(GlobalVariables.Set, GlobalVariables.PathToList + GlobalVariables.CurrentWordsList + GlobalVariables.ExtensionWordsList);
        }

        private void tbTitleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && !string.IsNullOrWhiteSpace(tbTitleName.Text))
            {
                tbOriginal.Focus();
            }
        }

        private void tbOriginal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && !string.IsNullOrWhiteSpace(tbOriginal.Text))
            {
                tbNew.Focus();
            }
        }

        private void tbNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && !string.IsNullOrWhiteSpace(tbNew.Text))
            {
                bAdd_Click(sender, e);
            }
        }

        private void lvWords_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged)
            {
                GridView view = lvWords.View as GridView;

                double width = lvWords.ActualWidth / view.Columns.Count;
                foreach (GridViewColumn col in view.Columns)
                {
                    col.Width = width;
                }
            }
        }
    }
}
