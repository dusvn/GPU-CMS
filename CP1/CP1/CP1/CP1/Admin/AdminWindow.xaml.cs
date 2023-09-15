using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CP1
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        //objekat klase pomocu kojeg ce se raditi sa fajlovima (upis/iscitavanje)
        private DataIO serializer = new DataIO();
        //BindingLista - Observable kolekcija koju koristimo sa idejom da se obavlja automatsko azuriranje
        public static BindingList<GraphicCard> GraphicCards { get; set; }
        public List<GraphicCard> Delete = new List<GraphicCard>();
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);


            this.DragMove();
        }
        public AdminWindow()
        {
            InitializeComponent();
            //Iscitavamo iz fajla objekat tipa BindingLista koji zelimo da nam se prikaze u tabeli (njen je ItemsSource)
            GraphicCards = serializer.DeSerializeObject<BindingList<GraphicCard>>("grafickeKartice.xml");
            if (GraphicCards== null) //U slucaju da nista nije ucitano
            {
                GraphicCards = new BindingList<GraphicCard>(); //nova lista pa cemo u nju dodavati
            }
            DataContext = this; //okidac Data Bindinga
            
        }

        private void ExitAdminWin_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            AddGPU AddWin = new AddGPU();
            AddWin.ShowDialog();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<GraphicCard>>(AdminWindow.GraphicCards, "grafickeKartice.xml");
        }

        private void oznakaChecked(object sender, RoutedEventArgs e)
        {
            GraphicCard gpu = GraphicCards[DataGridGraphicCards.SelectedIndex];
            Delete.Add(gpu);
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            foreach(GraphicCard gpu in Delete)
            {
                GraphicCards.Remove(gpu);
            }
        }

        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            AdminChangeWin win1 = new AdminChangeWin(DataGridGraphicCards.SelectedIndex);
            win1.ShowDialog();
        }



    }
}
