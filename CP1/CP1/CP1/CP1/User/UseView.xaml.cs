using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UseView.xaml
    /// </summary>
    public partial class UseView : Window
    {
        private string uri;
        string temp = "";
        string img = "";
        string Rtf = "";
        int id = 0;
        private DataIO serializer = new DataIO();
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        public UseView(int ind)
        {
            InitializeComponent();

            GraphicCard gpu = UserWindow.GraphicCardsUser[ind];

            img = gpu.Image;
            GpuNameTb.Text = gpu.Name;
            PriceProduct.Text = Convert.ToString(gpu.Cena);
            Uri fileUri = new Uri(gpu.Image);
            PictureProduct.Source = new BitmapImage(fileUri);

            Rtf = gpu.Rtf_file;
            TextRange textRange;
            FileStream fileStream;

            if (File.Exists(Rtf))
            {
                textRange = new TextRange(RTBoxTyper.Document.ContentStart, RTBoxTyper.Document.ContentEnd);
                using (fileStream = new FileStream(Rtf, FileMode.OpenOrCreate))
                {
                    textRange.Load(fileStream, DataFormats.Rtf);
                }
            }
        }

        private void AdminChangeExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
