using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_Final_Project.Model;

namespace GUI_Final_Project.ViewModel
{
    public class CetusViewModel
    {
        private CetusAPI cetus;

        public CetusViewModel(CetusAPI cetus = null)
        {
            if (cetus == null)
                this.cetus = new CetusAPI();
            else
                this.cetus = cetus;
        }

        public bool isDay
        {
            get { return cetus.isDay; }
            set
            {
                cetus.isDay = value;
            }
        }

        public int hours
        {
            get { return cetus.hours; }
            set
            {
                cetus.hours = value;
            }
        }

        public int minutes
        {
            get { return cetus.minutes; }
            set
            {
                cetus.minutes = value;
            }
        }

        public int seconds
        {
            get { return cetus.seconds; }
            set
            {
                cetus.seconds = value;
            }
        }
    }
}
