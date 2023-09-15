using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace CP1
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private DataIO serializer = new DataIO();
        //BindingLista - Observable kolekcija koju koristimo sa idejom da se obavlja automatsko azuriranje
        public static BindingList<GraphicCard> GraphicCardsUser { get; set; }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        public UserWindow()
        {
            GraphicCardsUser =  serializer.DeSerializeObject<BindingList<GraphicCard>>("grafickeKartice.xml");
            if (GraphicCardsUser == null) //U slucaju da nista nije ucitano
            {
                GraphicCardsUser = new BindingList<GraphicCard>(); //nova lista pa cemo u nju dodavati
            }
            DataContext = this; //okidac Data Bindinga
            InitializeComponent();

        }


        private void ExitUserWin_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }

        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            UseView win1 = new UseView(DataGridGraphicCards.SelectedIndex);
            win1.ShowDialog();
        }
    }
}
