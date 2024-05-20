using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_2Lab6.Model
{
    public class Director : INotifyPropertyChanged
    {
        public string name;
        public int films_count;
        public double avg_rate;
        public int year_start;
        public int year_end;

        //-------------------------------------------------------------------------------------------------------------

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Films_count
        {
            get { return films_count; }
            set
            {
                films_count = value;
                OnPropertyChanged("Films_count");
            }
        }
        public double Avg_rate
        {
            get { return avg_rate; }
            set
            {
                avg_rate = value;
                OnPropertyChanged("Avg_rate");
            }
        }
        public int Year_start
        {
            get { return year_start; }
            set
            {
                year_start = value;
                OnPropertyChanged("Year_start");
            }
        }
        public int Year_end
        {
            get { return year_end; }
            set
            {
                year_end = value;
                OnPropertyChanged("Year_end");
            }
        }

        //-------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
