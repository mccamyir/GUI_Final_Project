using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_Final_Project.Model;

namespace GUI_Final_Project.ViewModel
{
    public class FortunaViewModel
    {
        private FortunaAPI fortuna;

        public FortunaViewModel(FortunaAPI fortuna = null)
        {
            if (fortuna == null)
                this.fortuna = new FortunaAPI();
            else
                this.fortuna = fortuna;
        }

        public bool isWarm
        {
            get { return fortuna.isWarm; }
            set
            {
                fortuna.isWarm = value;
            }
        }

        public int minutes
        {
            get { return fortuna.minutes; }
            set
            {
                fortuna.minutes = value;
            }
        }

        public int seconds
        {
            get { return fortuna.seconds; }
            set
            {
                fortuna.seconds = value;
            }
        }
    }
}
