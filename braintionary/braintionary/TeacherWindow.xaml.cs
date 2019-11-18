using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
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

// TO DO
// dodać obsługę wyświetlania obrazka obok wyrazu do przetłumaczenia
// dodać możliwość ukrywania wyrazów i nauki z samego dźwięku 
// możliwość wprowadzania wyrazu ręcznie
// dodać zegarek i stoper, ewentualnie minutnik z dźwiękiem
// dodać statystyki

namespace braintionary
{
    public partial class TeacherWindow : Window
    {
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private int index = -1;
        private int goodWords;
        private Word[] WordArray;

        public TeacherWindow()
        {
            InitializeComponent();
            GlobalVariables.Set = GlobalVariables.XmlTool.Read(GlobalVariables.PathToList + GlobalVariables.CurrentWordsList + GlobalVariables.ExtensionWordsList);
            Initialize();
        }

        private void Initialize()
        {
            lGoodToBad.Content = "Zacznij nauke";
            lWrongWord.Content = "Status słówka";
            RandomizeIfNeed();
            WordUpdate();
        }

        private void RandomizeIfNeed()
        {
            List<Word> randomizePack = GlobalVariables.Set.pack;
            if (GlobalVariables.Randomize == true)
            {
                Random rand = new Random();
                WordArray = randomizePack.OrderBy(x => rand.Next()).ToArray();
            }
            else
            {
                WordArray = randomizePack.ToArray();
            }
        }

        private void WordUpdate()
        {
            index += 1;
            
            if(index != 0)
            {
                float ratio = goodWords;
                ratio = ratio / index;
                ratio = ratio * 100;
                lGoodToBad.Content = ratio.ToString() + " % poprawnych";
            }
            
            if (index == GlobalVariables.Set.pack.Count)
            {
                index = 0;
                goodWords = 0;
                Initialize();
                MessageBox.Show("Koniec");
            }

            pbProgress.Value = index * 100 / GlobalVariables.Set.pack.Count;
            lOriginalWord.Content = WordArray[index].name1;
        }

        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            if((bool)cbTurnOffMessageBox.IsChecked)
            {
                if (tbNewWord.Text.Equals(WordArray[index].name2))
                {
                    MessageBox.Show("dobrze");
                }
                else
                {
                    MessageBox.Show("źle, powinno być: " + WordArray[index].name2);
                }
            }

            if (tbNewWord.Text.Equals(WordArray[index].name2))
            {
                goodWords++;
                lWrongWord.Content = "Poprawnie";
            }
            else
            {
                lWrongWord.Content = "Źle, powinno być: " + WordArray[index].name2;
            }

            tbNewWord.Text = string.Empty;
            WordUpdate();
        }

        private void bEnd_Click(object sender, RoutedEventArgs e)
        {
            GlobalVariables.Set.pack.Clear();
            GlobalVariables.CurrentWordsList = string.Empty;
            (new MainWindow()).Show();
            Close();
        }

        private void tbNewWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return && !string.IsNullOrWhiteSpace(tbNewWord.Text))
            {
                bOk_Click(sender, e);
            }
        }

        private void bListen_Click(object sender, RoutedEventArgs e)
        {
            synthesizer.Speak(WordArray[index].name2);
        }

        private void bSpeak_Click(object sender, RoutedEventArgs e)
        {
            var recognizer = new SpeechRecognizer();
        }
    }
}
