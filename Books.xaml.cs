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
using System.Data.Entity;
using System.Collections;

namespace Library
{
    /// <summary>
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : Page
    {
        LibraryBaseEntities1 context = new LibraryBaseEntities1();
        public Books()
        {
            InitializeComponent();         
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {                     
                var booksInfoQuery =
                from k in context.Ksiazki
                join a in context.Autorzy on k.IdAutora equals a.IdAutora
                join g in context.Gatunek on k.IdGatunku equals g.IdGatunku
                orderby k.Tytul
                select new { k.Tytul, a.Imie, a.Nazwisko, g.Nazwa };
                ksiazkiDataGrid.ItemsSource = booksInfoQuery.ToList();

                var gatunkiList = context.Gatunek.ToList();


            foreach (var g in gatunkiList)
            {
                listboxGatunki.Items.Add(g.Nazwa);
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txtTytul != null && txtImie != null && txtNazwisko != null && listboxGatunki.SelectedItem != null)
            {
                Ksiazki k = new Ksiazki();
                k.Tytul = txtTytul.Text;
                

                var idAutoraOst = (
                    from aut in context.Autorzy                    
                    select aut.IdAutora
                    ).Max();

                var idAutoraSearch = (
                    from aut in context.Autorzy
                    where aut.Imie == txtImie.Text && aut.Nazwisko == txtNazwisko.Text
                    select aut.IdAutora
                    ).ToList();

                var idGatunkuSearch = (
                    from gat in context.Gatunek
                    where gat.Nazwa == (string)listboxGatunki.SelectedItem
                    select gat.IdGatunku
                    ).ToList();


                if (idAutoraSearch.Count > 0)
                {
                    k.IdAutora = idAutoraSearch[0];
                    k.IdGatunku = idGatunkuSearch[0];
                    k.IdWydawnictwa = 1;
                    context.Ksiazki.Add(k);

                }
                else
                {
                    Autorzy a = new Autorzy();
                    a.IdAutora = int.Parse((idAutoraOst+1).ToString());
                    a.Imie = txtImie.Text;
                    a.Nazwisko = txtNazwisko.Text;
                    a.DataUrodzenia = new DateTime(1997, 5, 1);
                    context.Autorzy.Add(a);

                    k.IdAutora = idAutoraOst + 1;
                    k.IdGatunku = idGatunkuSearch[0];
                    k.IdWydawnictwa = 1;
                    context.Ksiazki.Add(k);

                }
                MessageBox.Show("Dodano nową książkę! Odświerz stronę.");
                context.SaveChanges();
                
            }
            else
            {
                MessageBox.Show("Wszystkie pola muszą być uzupełnione!!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(ksiazkiDataGrid.SelectedIndex != -1)
            {
                var selectedRow = ksiazkiDataGrid.SelectedItem as Ksiazki;
                var selectedRowSql = (
                    from k in context.Ksiazki
                    where k.IdKsiazki == selectedRow.IdKsiazki
                    select k
                );
                context.Ksiazki.D

            }
            else
            {
                MessageBox.Show("Nie wybrałeś żadnej pozycji!!");
            }
            

            

        }
    }
}
