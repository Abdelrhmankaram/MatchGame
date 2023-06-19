using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int tenth_of_seconds;
        int matches_found;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenth_of_seconds++;
            timeTextBlock.Text = (tenth_of_seconds / 10F).ToString("0.0s");
            if (matches_found == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
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
                if (textBlock.Name == "timeTextBlock") continue;
                int index = random.Next(animal_emoji.Count);
                string next_emoji = animal_emoji[index];
                textBlock.Text = next_emoji;
                animal_emoji.RemoveAt(index);
            }
            timer.Start();
            tenth_of_seconds = 0;
            matches_found = 0;
        }
        TextBlock last;
        bool match = false;
        int cnt = 0;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            if (match == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                last = textBlock;
                match = true;
            }
            else if (textBlock.Text == last.Text)
            {
                matches_found++;
                textBlock.Visibility = Visibility.Hidden;
                match = false;
                cnt += 2;
            }
            else
            {
                last.Visibility = Visibility.Visible;
                match = false;
            }
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(matches_found == 8)
            {
                SetUpGame();
            }
        }
    }
}