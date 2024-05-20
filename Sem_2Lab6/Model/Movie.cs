using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sem_2Lab6.Model
{
    public class Movie : INotifyPropertyChanged
    {
        public string title;
        public string genre;
        public string director;
        public int year;
        public double rate;

        //-------------------------------------------------------------------------------------------------------------

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
               OnPropertyChanged("Title");
            }
        }
        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }
        public string Director
        {
            get { return director; }
            set
            {
                director = value;
                OnPropertyChanged("Director");
            }
        }
        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }
        public double Rate
        {
            get { return rate; }
            set
            {
                rate = value;
                OnPropertyChanged("Rate");
            }
        }

        //-------------------------------------------------------------------------------------------------------------

        public Movie(string title_, string genre_, int year_, double rate_, string director_)
        {
            title = title_;
            genre = genre_;
            director = director_;
            year = year_;
            rate = rate_;
            
        }

        //-------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
