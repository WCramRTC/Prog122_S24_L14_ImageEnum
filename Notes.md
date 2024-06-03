Here’s a sample WPF application code to help facilitate your lesson on embedding images, using enums, and the file picker.

### MainWindow.xaml
```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <StackPanel>
            <!-- Image Display -->
            <Image Name="DisplayImage" Height="200" Width="200" Stretch="Uniform" Margin="10"/>

            <!-- Button to pick image file -->
            <Button Content="Pick Image" Click="PickImage_Click" Margin="10"/>

            <!-- Enum ComboBox -->
            <ComboBox Name="ImageSizeComboBox" SelectionChanged="ImageSizeComboBox_SelectionChanged" Margin="10">
                <ComboBoxItem Content="Small" />
                <ComboBoxItem Content="Medium" />
                <ComboBoxItem Content="Large" />
            </ComboBox>
        </StackPanel>
    </Grid>
</Window>
```

### MainWindow.xaml.cs
```csharp
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp
{
    public enum ImageSize
    {
        Small,
        Medium,
        Large
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
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
```

### Explanation
1. **Embedding Images:**
   - The `Image` control in XAML is used to display images.
   - The `PickImage_Click` method uses `OpenFileDialog` to select an image file, then loads it into a `BitmapImage` and sets it as the `Source` for the `Image` control.

2. **Enums:**
   - The `ImageSize` enum defines three possible sizes for the image.
   - The `ImageSizeComboBox_SelectionChanged` method handles changing the size of the displayed image based on the selected enum value from the ComboBox.

3. **File Picker:**
   - The `OpenFileDialog` class is used to open a file picker dialog, allowing the user to select an image file.

This code will help demonstrate the integration of these elements in a WPF application.

---

Here's a detailed example to help you teach embedding images, enums, and using the file picker in a WPF form.

### Embedding Images

First, ensure you have an image in your project. You can add an image by right-clicking on the project, selecting "Add", then "Existing Item", and finally choosing your image file. Set the image's Build Action to "Resource".

**XAML Code:**
```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <Image Name="MyImage" HorizontalAlignment="Left" Height="200" VerticalAlignment="Top" Width="200" Source="Images/myimage.png"/>
    </Grid>
</Window>
```

### Enums

Let's create an enum for image size options.

**Enum Code:**
```csharp
public enum ImageSize
{
    Small,
    Medium,
    Large
}
```

You can bind this enum to a ComboBox in your XAML.

**XAML Code:**
```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ComboBox Name="SizeComboBox" HorizontalAlignment="Left" VerticalAlignment="Top" Width="120" SelectionChanged="SizeComboBox_SelectionChanged">
            <ComboBoxItem Content="Small"/>
            <ComboBoxItem Content="Medium"/>
            <ComboBoxItem Content="Large"/>
        </ComboBox>
        <Image Name="MyImage" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="10,40,0,0" Width="200" Height="200" Source="Images/myimage.png"/>
    </Grid>
</Window>
```

**C# Code:**
```csharp
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SizeComboBox.ItemsSource = Enum.GetValues(typeof(ImageSize));
    }

    private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SizeComboBox.SelectedItem is ImageSize selectedSize)
        {
            switch (selectedSize)
            {
                case ImageSize.Small:
                    MyImage.Width = 100;
                    MyImage.Height = 100;
                    break;
                case ImageSize.Medium:
                    MyImage.Width = 200;
                    MyImage.Height = 200;
                    break;
                case ImageSize.Large:
                    MyImage.Width = 300;
                    MyImage.Height = 300;
                    break;
            }
        }
    }
}
```

### File Picker

Add a button to open a file dialog and allow the user to select an image file.

**XAML Code:**
```xml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ComboBox Name="SizeComboBox" HorizontalAlignment="Left" VerticalAlignment="Top" Width="120" SelectionChanged="SizeComboBox_SelectionChanged"/>
        <Button Content="Choose Image" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="140,10,0,0" Width="120" Click="ChooseImageButton_Click"/>
        <Image Name="MyImage" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="10,40,0,0" Width="200" Height="200"/>
    </Grid>
</Window>
```

**C# Code:**
```csharp
using Microsoft.Win32;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        SizeComboBox.ItemsSource = Enum.GetValues(typeof(ImageSize));
    }

    private void SizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (SizeComboBox.SelectedItem is ImageSize selectedSize)
        {
            switch (selectedSize)
            {
                case ImageSize.Small:
                    MyImage.Width = 100;
                    MyImage.Height = 100;
                    break;
                case ImageSize.Medium:
                    MyImage.Width = 200;
                    MyImage.Height = 200;
                    break;
                case ImageSize.Large:
                    MyImage.Width = 300;
                    MyImage.Height = 300;
                    break;
            }
        }
    }

    private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
        if (openFileDialog.ShowDialog() == true)
        {
            MyImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        }
    }
}
```

This code example will help your students understand how to embed images in a WPF form, use enums to control UI elements, and allow users to pick files using the file picker dialog.