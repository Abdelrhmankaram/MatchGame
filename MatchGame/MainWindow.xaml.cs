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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            /*
             * Eight pairs of animals
             */
            List<string> animal_emoji = new List<string>()
            {
                "🐱","🐱",//cat
                "🐶","🐶",//dog
                "🐸","🐸",//frog
                "🐰","🐰",//rabbet
                "🦒","🦒",//giraffe
                "🐼","🐼",//panda
                "🐻","🐻",//bear
                "🐙","🐙",//octopus
            };
            Random random=new Random();//define a random class
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())// select each element of 'TextBlock' data type
            {
                int index = random.Next(animal_emoji.Count);
                string next_emoji = animal_emoji[index];
                textBlock.Text = next_emoji;
                animal_emoji.RemoveAt(index);
            }
        }
    }
}