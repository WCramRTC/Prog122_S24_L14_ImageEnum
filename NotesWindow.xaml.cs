using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Prog122_S24_L14_ImageEnum
{
    /// <summary>
    /// Interaction logic for NotesWindow.xaml
    /// </summary>
    public partial class NotesWindow : Window
    {
        public enum ImageSize
        {
            Small,
            Medium,
            Large
        }


        public NotesWindow()
        {
            InitializeComponent();
        }


        private void PickImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                DisplayImage.Source = bitmap;
            }
        }

        private void ImageSizeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ImageSizeComboBox.SelectedItem != null)
            {
                string selectedSize = (ImageSizeComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem).Content.ToString();
                ImageSize size = (ImageSize)Enum.Parse(typeof(ImageSize), selectedSize);

                switch (size)
                {
                    case ImageSize.Small:
                        DisplayImage.Width = 100;
                        DisplayImage.Height = 100;
                        break;
                    case ImageSize.Medium:
                        DisplayImage.Width = 200;
                        DisplayImage.Height = 200;
                        break;
                    case ImageSize.Large:
                        DisplayImage.Width = 300;
                        DisplayImage.Height = 300;
                        break;
                }
            }
        }
    }
}
