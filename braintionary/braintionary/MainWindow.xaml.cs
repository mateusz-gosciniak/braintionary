using System.IO;
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

// TODO
// ładny wygląd
// zmienić listview na treeview i dodać możliwość grupowania
// stworzyć plik konfiguracyjny zapamiętujący ustawienia
// stworzyć plik postępu w nauce 
// dodać pomoc
// dodać edycje listy słówek
// dodać informacje o twórcy
// możliwość uruchamiania wraz z systemem i przypominania o nauce słówek
// funkcja słownika w trayu
// dodać menu opcji

namespace braintionary
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lvTasks_Update();
        }

        private void lvTasks_Update()
        {
            if (!Directory.Exists(GlobalVariables.PathToList))
            {
                Directory.CreateDirectory(GlobalVariables.PathToList);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(GlobalVariables.PathToList);
            FileInfo[] info = dirInfo.GetFiles("*.xml");
            lvTasks.Items.Clear();
            foreach (FileInfo f in info)
            {
                lvTasks.Items.Add(f.Name.Remove(f.Name.LastIndexOf('.')));
            }
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            (new AddWindow()).Show();
            Close();
        }

        private void bDel_Click(object sender, RoutedEventArgs e)
        {
            if (lvTasks.SelectedItem == null)
            {
                MessageBox.Show("Najpierw wybierz listę słówek do nauki");
            }
            else
            {
                File.Delete(GlobalVariables.PathToList + GlobalVariables.CurrentWordsList + GlobalVariables.ExtensionWordsList);
                lvTasks_Update();
                MessageBox.Show("Lista została usunięta");
            }
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            if (lvTasks.SelectedItem == null)
            {
                MessageBox.Show("Najpierw wybierz listę słówek do nauki");
            }
            else
            {
                if (cbRandomize.IsChecked == true)
                {
                    GlobalVariables.Randomize = true;
                }

                (new TeacherWindow()).Show();
                Close();
            }
        }
        
        private void lvTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GlobalVariables.CurrentWordsList = lvTasks.SelectedItem as string;
        }
    }
}
