using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Filmek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public class Film
        {
            public string Cim {  get; set; }

            public string Mufaj { get; set; }

            public int  Hossz {  get; set; }

            public double Ertekeles { get; set; }

            public Film(string cim, string mufaj, int hossz, double ertekeles)
            {
                Cim = cim;
                Mufaj = mufaj;
                Hossz = hossz;
                Ertekeles = ertekeles;
            }
        }

        List<Film> filmek = new List<Film>()
        {
            new Film("Csillagok háborúja", "sci-fi", 121, 8.6),
            new Film("Titanic", "dráma", 195, 7.8),
            new Film("A Gyűrűk Ura", "fantasy", 201, 8.8),
            new Film("Mátrix", "sci-fi", 136, 8.7),
            new Film("Shrek", "animáció", 90, 7.9)
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void filmek_szama(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"A filmek száma: {filmek.Count()} db!");
        }

        private void filmek_betoltese(object sender, RoutedEventArgs e)
        {
            dgFilm.ItemsSource = filmek;
        }

        private void leghosszabb_film(object sender, RoutedEventArgs e)
        {
            Film leghosszabb = filmek[0];


            foreach (var item in filmek)
            {
                if(item.Hossz > leghosszabb.Hossz)
                {
                    leghosszabb = item;
                }
            }
            MessageBox.Show($"A leghosszabb film címe: {leghosszabb.Cim}");
        }

        private void atlagertek(object sender, RoutedEventArgs e)
        {
            double osszeg = 0;
            int db = 0;

            foreach (var item in filmek)
            {
                osszeg += item.Ertekeles;
                db++;
            }
            double atlag = osszeg / db;
            MessageBox.Show($"Az átlag értékelés: {atlag}");
        }

        private void csakScifi(object sender, RoutedEventArgs e)
        {
            List<Film> scifi = new List<Film>();

            foreach (var item in filmek)
            {
                if (item.Mufaj == "sci-fi".ToLower())
                {
                    scifi.Add(item);
                }
                else
                {
                    continue;
                }
            }
            dgFilm.ItemsSource = scifi;
        }

        private void csak_cimek(object sender, RoutedEventArgs e)
        {
            List<string> cimek = new List<string>();


            foreach (var item in filmek)
            {
                cimek.Add(item.Cim);
            }


            dgFilm.AutoGenerateColumns = false;
            dgFilm.Columns.Clear();


            DataGridTextColumn oszlop = new DataGridTextColumn();


            oszlop.Header = "Film címe";
            oszlop.Binding = new Binding();


            dgFilm.Columns.Add(oszlop);


            dgFilm.ItemsSource = cimek;
        }

        private void rendezes_cim(object sender, RoutedEventArgs e)
        {
            List<Film> cimSzerint = filmek
                                        .OrderBy(x => x.Cim)
                                        .ToList();


            dgFilm.ItemsSource = cimSzerint;
        }
    }
}