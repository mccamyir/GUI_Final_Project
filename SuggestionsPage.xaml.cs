using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Windows.UI.Xaml.Media.Imaging;
using GUI_Final_Project.Model;
using GUI_Final_Project.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace GUI_Final_Project
{
    public sealed partial class SuggestionsPage : Page
    { 
        public WarframeViewModel Warframe { get; set; }
        public SuggestionsPage()
        {
            this.InitializeComponent();
            selectRandomFrame();
            Warframe = new WarframeViewModel();
        }

        private void selectRandomFrame()
        {
            Random rand = new Random();
            int chosenFrame = rand.Next(1, 5);

            switch (chosenFrame)
            {
                case 1:
                    warframeBox.Source = new BitmapImage(new Uri("ms-appx:///Assets/Warframes/ExcaliburLook.png"));
                    WarframeName.Text = "Excalibur";

                    WarframeHealth.Text = "100";
                    WarframeShields.Text = "100";
                    WarframeArmor.Text = "225";
                    WarframeEnergy.Text = "100";
                    WarframeSprint_Speed.Text = "1.0";

                    break;
                case 2:
                    warframeBox.Source = new BitmapImage(new Uri("ms-appx:///Assets/Warframes/MagLook.png"));
                    WarframeName.Text = "Mag";

                    WarframeHealth.Text = "75";
                    WarframeShields.Text = "150";
                    WarframeArmor.Text = "65";
                    WarframeEnergy.Text = "125";
                    WarframeSprint_Speed.Text = "1.0";

                    break;
                case 3:
                    warframeBox.Source = new BitmapImage(new Uri("ms-appx:///Assets/Warframes/FrostLook.png"));
                    WarframeName.Text = "Frost";

                    WarframeHealth.Text = "100";
                    WarframeShields.Text = "150";
                    WarframeArmor.Text = "300";
                    WarframeEnergy.Text = "100";
                    WarframeSprint_Speed.Text = "0.95";

                    break;
                case 4:
                    warframeBox.Source = new BitmapImage(new Uri("ms-appx:///Assets/Warframes/BansheeLook.png"));
                    WarframeName.Text = "Banshee";

                    WarframeHealth.Text = "100";
                    WarframeShields.Text = "100";
                    WarframeArmor.Text = "15";
                    WarframeEnergy.Text = "150";
                    WarframeSprint_Speed.Text = "1.1";

                    break;
                default:
                    warframeBox.Source = new BitmapImage(new Uri("ms-appx:///Assets/Warframes/Square150x150Logo.scale-200.png"));
                    break;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void RandButton_Click(object sender, RoutedEventArgs e)
        {
            selectRandomFrame();
        }
    }
}
