using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GUI_Final_Project.Model;
using GUI_Final_Project.ViewModel;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GUI_Final_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        TextBlock EarthTextBlock;
        TextBlock FortunaTextBlock;

        private DispatcherTimer cetusTimer = new DispatcherTimer();
        private DispatcherTimer fortunaTimer = new DispatcherTimer();

        public CetusViewModel cetus = new CetusViewModel();
        public FortunaViewModel fortuna = new FortunaViewModel();

        public MainPage()
        {
            this.InitializeComponent();
            EarthTextBlock = this.nextEarthCycle;
            FortunaTextBlock = this.nextFortunaCycle;
            cetusTimer.Tick += cetus_Timer_Tick;
            fortunaTimer.Tick += fortuna_Timer_Tick;
            setFortuna();
            setCetus();
        }

        private void randFrameButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SuggestionsPage));
        }

        private void abtButton_Click(object sender, RoutedEventArgs e)
        {
            //Misplaced Aboutpage. Visual Studio had issues when trying to move back and remove '.Assets' references.
            this.Frame.Navigate(typeof(Assets.AboutPage));
        }

        //Working live clock code found https://social.msdn.microsoft.com/Forums/windowsapps/en-US/03b701f9-f78a-4df1-98db-05b752fab920/count-down-timer-by-button-windows-phone-81-c?forum=wpdevelop
        private void setCetus()
        {
            if (cetus.isDay)
            {
                EarthTextBlock.Text = "Time Left in Day Cycle:";
            }
            else
            {
                EarthTextBlock.Text = "Time Left In Night Cycle:";
            }
            earthHourInt.Text = cetus.hours.ToString();
            earthMinuteInt.Text = cetus.minutes.ToString();
            earthSecondInt.Text = cetus.seconds.ToString();
            cetusTimer.Interval = new TimeSpan(0, 0, 1);
            cetusTimer.Start();
        }
        void cetus_Timer_Tick(object sender, object e)
        {
            if (cetus.seconds == 0 && cetus.minutes == 0 && cetus.hours == 0)
            {
                if (cetus.isDay)
                {
                    EarthTextBlock.Text = "Time Left In Night Cycle:";
                    cetus.isDay = false;
                    cetus.minutes = 29;
                    earthMinuteInt.Text = cetus.minutes.ToString();
                    cetus.seconds = 60;
                }
                else
                {
                    EarthTextBlock.Text = "Time Left in Day Cycle:";
                    cetus.isDay = true;
                    cetus.hours = 1;
                    earthHourInt.Text = cetus.hours.ToString();
                    cetus.minutes = 39;
                    earthMinuteInt.Text = cetus.minutes.ToString();
                    cetus.seconds = 60;
                }
            }
            else if (cetus.seconds == 0 && cetus.minutes == 0)
            {
                cetus.hours -= 1;
                cetus.minutes = 59;
                cetus.seconds = 60;
            }
            else if (cetus.seconds == 0)
            {
                cetus.minutes -= 1;
                earthMinuteInt.Text = cetus.minutes.ToString();
                cetus.seconds = 60;
            }
            cetus.seconds = cetus.seconds - 1;
            earthSecondInt.Text = cetus.seconds.ToString();
        }
        void setFortuna()
        {
            if (fortuna.isWarm)
            {
                FortunaTextBlock.Text = "Time Left in Warm Cycle:";
            }
            else
            {
                FortunaTextBlock.Text = "Time Left In Cold Cycle:";
            }
            fortunaMinuteInt.Text = fortuna.minutes.ToString();
            fortunaSecondInt.Text = fortuna.seconds.ToString();
            fortunaTimer.Interval = new TimeSpan(0, 0, 1);
            fortunaTimer.Start();
        }
        void fortuna_Timer_Tick(object sender, object e)
        {

            if (fortuna.seconds == 0 && fortuna.minutes == 0)
            {
                if (fortuna.isWarm)
                {
                    FortunaTextBlock.Text = "Time Left In Cold Cycle:";
                    fortuna.isWarm = false;
                    fortuna.minutes = 19;
                    fortunaMinuteInt.Text = fortuna.minutes.ToString();
                    fortuna.seconds = 60;
                }
                else
                {
                    FortunaTextBlock.Text = "Time Left in Warm Cycle:";
                    fortuna.isWarm = true;
                    fortuna.minutes = 6;
                    fortunaMinuteInt.Text = fortuna.minutes.ToString();
                    fortuna.seconds = 40;
                    fortunaSecondInt.Text = fortuna.seconds.ToString();
                }
            }
            else if (fortuna.seconds == 0 && fortuna.minutes != 0)
            {
                fortuna.seconds = 60;
                fortuna.minutes -= 1;
                fortunaMinuteInt.Text = fortuna.minutes.ToString();
            }
            fortuna.seconds = fortuna.seconds - 1;
            fortunaSecondInt.Text = fortuna.seconds.ToString();
        }
    }
}
