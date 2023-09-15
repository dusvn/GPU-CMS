using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
    /// Interaction logic for AddGPU.xaml
    /// </summary>
    public partial class AddGPU : Window
    {
        private string uri;
        private DataIO serializer = new DataIO();
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

   
        public AddGPU()
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            DataPicker.DisplayDate = now; // Setovano je da je uvek na danasnji datum + predefinisano je ne moze da se menja 
            ComboBoxFontFamily.ItemsSource = Fonts.SystemFontFamilies;
            ComboBoxFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
            ComboBoxColor.ItemsSource = new List<string>() { "Black", "White", "Blue", "Red", "Green", "Yellow", "Gray", "Pink", "Brown", "Purple" };
        }

        private void AddExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }



       
        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Browse.Background = Brushes.Blue;
                uri = openFileDialog.FileName;
                Uri fileUri = new Uri(uri);
                PictureProduct.Source = new BitmapImage(fileUri);
               
            }
        }

     
 
        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            if (GPU_NAME_VALIDATE())
            {
                GPUNameTB.BorderBrush = Brushes.Black;
                if (GPU_PRICE())
                {
                    PriceProductTB.BorderBrush = Brushes.Black;
                    if (CHECK_IMAGE())
                    {
                        if (CHECK_DESRIPTION())
                        {
                            string naziv = "";
                            naziv = GPUNameTB.Text + ".rtf"; // Naziv rtf fajla ime_proizvoda.rtf

                            AdminWindow.GraphicCards.Add(new GraphicCard(naziv, uri, Convert.ToInt32(PriceProductTB.Text), DataPicker.SelectedDate.Value, GPUNameTB.Text));


                            TextRange range;
                            FileStream fStream;
                            range = new TextRange(RTBoxTyper.Document.ContentStart, RTBoxTyper.Document.ContentEnd);
                            fStream = new FileStream(naziv, FileMode.Create);
                            range.Save(fStream, DataFormats.Rtf);
                            fStream.Close();

                            this.Close();
                        }
                    }
                }
             }
              else
                {
                    MessageBox.Show("Type data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        
      
  
        private void ComboBoxFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxFontFamily.SelectedItem != null)
            {
                RTBoxTyper.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, ComboBoxFontFamily.SelectedItem);
            }

        }


        /// <summary>
        /// Pocinje da kauntuje od pocetka reci i zavrsava na kraju reci 
        /// Reci sadrze sva velika slova A-Z(kao i mala a-z) takodje sadrzi i brojeve
        /// Podrazumevao sam da korisnik nece unisiti Neka recenica _RAZMAK_ ? 
        /// Nego ce vrsiti normalan unos Neka recenica? 
        /// </summary>
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
        private bool GPU_NAME_VALIDATE()
        {
            bool result = true;

            if (GPUNameTB.Text.Trim().Equals(""))
            {
            result = false;
            GPUNameTB.BorderBrush = Brushes.Red;
            GPUNameTB.BorderThickness = new Thickness(2);
            }
            return result;
        }

        private bool GPU_PRICE()
        {
            bool result = true;
            int x;
            bool parse_num = int.TryParse(PriceProductTB.Text.Trim(),out x); 

            if (PriceProductTB.Text.Trim().Equals("") || (x<=0 && parse_num))
            {
            result = false;
            PriceProductTB.BorderBrush = Brushes.Red;
            PriceProductTB.BorderThickness = new Thickness(2);
            }

            return result;  
        }

        private bool CHECK_DESRIPTION()
        {
            bool result = true;
            int num_words = int.Parse(TBNumWords.Text);
            if (num_words<2)
            {
                result = false;
                MessageBox.Show("Type some description!","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }

        private bool CHECK_IMAGE()
        {
            bool result = true;
            if (Browse.Background == Brushes.Red)
            {
                result= false;
                MessageBox.Show("Browse photo!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return result;
        }


    }
}

