using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdminChangeWin.xaml
    /// </summary>
    public partial class AdminChangeWin : Window
    {
        private string uri;
        string temp = "";
        string img = "";
        string Rtf = "";
        int id = 0;
        private DataIO serializer = new DataIO();
        public AdminChangeWin(int ind)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            DataPicker.DisplayDate = now; // Setovano je da je uvek na danasnji datum + predefinisano je ne moze da se menja 
            ComboBoxFontFamily.ItemsSource = Fonts.SystemFontFamilies;
            ComboBoxFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
            ComboBoxColor.ItemsSource = new List<string>() { "Black", "White", "Blue", "Red", "Green", "Yellow", "Gray", "Pink", "Brown", "Purple" };

            id = ind;

            GraphicCard gpu = AdminWindow.GraphicCards[ind];

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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
        private void AdminChangeExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void CountWord()
        {
            string richText = new TextRange(RTBoxTyper.Document.ContentStart, RTBoxTyper.Document.ContentEnd).Text;

            int wordCount = Regex.Matches(richText, @"\b[A-Za-z0-9]+\b").Count;

            TBNumWords.Text = wordCount.ToString();
        }

        private void RTBoxTyper_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountWord();
        }


        private void ComboBoxFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFontSize.SelectedValue != null)
            {
                RTBoxTyper.Selection.ApplyPropertyValue(Inline.FontSizeProperty, ComboBoxFontSize.SelectedValue);
            }
        }


        private void ComboBoxColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxColor.SelectedValue != null)
            {
                RTBoxTyper.Selection.ApplyPropertyValue(Inline.ForegroundProperty, ComboBoxColor.SelectedValue);
            }
        }

        private void BrowseChange_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                uri = openFileDialog.FileName;
                Uri fileUri = new Uri(uri);
                PictureProduct.Source = new BitmapImage(fileUri);
            }
        }

        private void ComboBoxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFontFamily.SelectedItem != null)
            {
                RTBoxTyper.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFontFamily.SelectedItem);
            }

        }
 

        private void BrowseChange_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                BrowseChange.Background = Brushes.Blue;
                temp = openFileDialog.FileName;
                Uri fileUri = new Uri(temp);
                PictureProduct.Source = new BitmapImage(fileUri);

            }
        }

        private bool GPU_PRICE()
        {
            bool result = true;
            int x;
            bool parse_num = int.TryParse(PriceProduct.Text.Trim(), out x);

            if (PriceProduct.Text.Trim().Equals("") || (x <= 0 && parse_num))
            {
                result = false;
                PriceProduct.BorderBrush = Brushes.Red;
                PriceProduct.BorderThickness = new Thickness(2);
            }

            return result;
        }

        private bool CHECK_DESRIPTION()
        {
            bool result = true;
            int num_words = int.Parse(TBNumWords.Text);
            if (num_words < 2)
            {
                result = false;
                MessageBox.Show("Type some description!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }


        private bool GPU_NAME_VALIDATE()
        {
            bool result = true;

            if (GpuNameTb.Text.Trim().Equals(""))
            {
                result = false;
                GpuNameTb.BorderBrush = Brushes.Red;
                GpuNameTb.BorderThickness = new Thickness(2);
            }
            return result;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (GPU_NAME_VALIDATE() && CHECK_DESRIPTION() && GPU_PRICE())
            {
                if (temp == "") temp = img;

                AdminWindow.GraphicCards[id] = new GraphicCard(Rtf,temp, Convert.ToInt32(PriceProduct.Text), DateTime.Now, GpuNameTb.Text);

                serializer.SerializeObject<BindingList<GraphicCard>>(AdminWindow.GraphicCards, "grafickeKartice.xml");

                TextRange range;
                FileStream fStream;
                range = new TextRange(RTBoxTyper.Document.ContentStart, RTBoxTyper.Document.ContentEnd);
                fStream = new FileStream(Rtf, FileMode.Open);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();


                this.Close();

            }
       }

        
    }
}
