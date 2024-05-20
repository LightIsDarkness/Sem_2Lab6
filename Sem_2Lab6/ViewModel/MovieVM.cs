using Sem_2Lab6.Model;
using Sem_2Lab6.MVVM;
using System.Collections.ObjectModel;
using System.Windows;

namespace Sem_2Lab6.ViewModel
{
    public class MovieVM
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;


        public ObservableCollection<Director> Directors { get; set; }
        public ObservableCollection<Movie> Movies { get; set; }
        ObservableCollection<Movie> FilteredMovies { get; set; }
        public Movie SelectedItem { get; set; }
        public RelayCommand AddMovie => new RelayCommand(execute => addMovie(mw.NameText.Text, mw.Genres.SelectedItem.ToString(), TryParce(mw.YearText.Text), TryParceDouble(mw.RateText.Text), mw.DirectorNameText.Text));
        public RelayCommand DeleteMovie => new RelayCommand(execute => deleteMovie(SelectedItem));
        public RelayCommand ShowAllMovies => new RelayCommand(execute => showAllMovies());
        public RelayCommand FilterByGenre => new RelayCommand(execute => filterbygenre(mw.GenreBoxFilter.SelectedItem.ToString()));
        public RelayCommand FilterByDate => new RelayCommand(execute => filterbydate(TryParce(mw.FromYear.Text), TryParce(mw.ToYear.Text)));
        public RelayCommand FilterByRate => new RelayCommand(execute => filterbyrate());
        public RelayCommand FilterByUnRate => new RelayCommand(execute => filterbyunrate());
        public RelayCommand CreateDirectorsList => new RelayCommand(execute => dlist());

        public string[] s = 
        {
            "Ужасы",
            "Фэнтези",
            "Путешествие",
            "Документальный",
            "Драмма",
            "Мультфильм",
            "Комедия"
        };
        public MovieVM() 
        {
            Movies = new ObservableCollection<Movie>()
            {
            new Movie("Очень страшное кино","Ужасы",2002,5.1, "Спилберг С."),
            new Movie("Любовь и голуби","Драмма",1968,8.8,"Михалков Н.")
            };
            for (int i = 0; i < s.Length; i++)
            {
                mw.Genres.Items.Add(s[i]);
                mw.GenreBoxFilter.Items.Add(s[i]);
            }
        }
        public void addMovie(string name, string genre, int year, double raiting, string prodname)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(prodname) || year == 0 || raiting == 0)
            {
                MessageBox.Show("Какое либо из полей пустое/или неправильный формат данных");
            }
            else
            {
                Movies.Add(new Movie(name, genre, year, raiting, prodname));
            }
        }

        public void deleteMovie(Movie movie)
        {
            Movies.Remove(movie);
        }
        public int TryParce(string str)
        {
            try
            {
                Convert.ToInt64(str);
            }
            catch
            {
                return 0;
            }
            return Convert.ToInt32(str);
        }
        public double TryParceDouble(string str)
        {
            try
            {
                Convert.ToDouble(str);
            }
            catch
            {
                return 0;
            }
            return Convert.ToDouble(str);
        }
        public void showAllMovies()
        {
            mw.MainList.ItemsSource = Movies;
        }

        public void filterbygenre(string filter)
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.Where(x => x.Genre == filter).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не обнаружено");
                mw.MainList.ItemsSource = Movies;
            }
            else
            {
                mw.MainList.ItemsSource = FilteredMovies;
            }
        }

        public void filterbydate(int start, int end)
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.Where(movie => movie.Year >= start && movie.Year <= end).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не обнаружено");
                mw.MainList.ItemsSource = Movies;
            }
            else
            {
                mw.MainList.ItemsSource = FilteredMovies;
            }
        }

        public void filterbyrate()
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.OrderBy(x => x.Rate).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не обнаружено");
                mw.MainList.ItemsSource = Movies;
            }
            else
            {
                mw.MainList.ItemsSource = FilteredMovies;
            }
        }

        public void filterbyunrate()
        {
            FilteredMovies = new ObservableCollection<Movie>(Movies.OrderByDescending(x => x.Rate).ToList());
            if (FilteredMovies.Count == 0)
            {
                MessageBox.Show("По данному фильтру ничего не найдено:((");
                mw.MainList.ItemsSource = Movies;
            }
            else
            {
                mw.MainList.ItemsSource = FilteredMovies;
            }
        }
        public void dlist()
        {
            Directors = new ObservableCollection<Director>(Movies
            .GroupBy(movie => movie.Director)
            .Select(group => new Director
            {
                Name = group.Key,
                Films_count = group.Count(),
                Avg_rate = group.Average(movie => movie.Rate),
                Year_start = group.Min(movie => movie.Year),
                Year_end = group.Max(movie => movie.Year)
            })
            .ToList());
            mw.DirectorsList.ItemsSource = Directors;
        }
    }
}
