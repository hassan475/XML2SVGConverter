using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Security.Cryptography;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;


namespace UTF8Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private string _svg;
        private string _svg2;
        private string _svg3;
        private string _svg4;
        private string _svg5;
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;

        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Svg
        {
            get { return _svg; }
            set
            {
                _svg = value;
                OnPropertyChange();
            }
        }
        public string Svg2
        {
            get { return _svg2; }
            set
            {
                _svg2 = value;
                OnPropertyChange();
            }
        }
        public string Svg3
        {
            get { return _svg3; }
            set
            {
                _svg3 = value;
                OnPropertyChange();
            }
        }
        public string Svg4
        {
            get { return _svg4; }
            set
            {
                _svg4 = value;
                OnPropertyChange();
            }
        }
        public string Svg5
        {
            get { return _svg5; }
            set
            {
                _svg5 = value;
                OnPropertyChange();
            }
        }
        private async void Myimage_Loaded(object sender, RoutedEventArgs e)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Svg.txt");
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            await Task.Delay(200);

            using (var dataReader = DataReader.FromBuffer(buffer))
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {

                    Svg = dataReader.ReadString(buffer.Length);
                });
            }
            var svgBuffer = CryptographicBuffer.ConvertStringToBinary("svg", BinaryStringEncoding.Utf8);
        }
        private async void Myimage_Loaded2(object sender, RoutedEventArgs e)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Svg.txt");
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            await Task.Delay(400);

            using (var dataReader = DataReader.FromBuffer(buffer))
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    Svg2 = dataReader.ReadString(buffer.Length);
                });
            }
            var svgBuffer = CryptographicBuffer.ConvertStringToBinary("svg2", BinaryStringEncoding.Utf8);
        }
        private async void Myimage_Loaded3(object sender, RoutedEventArgs e)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Svg.txt");
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            await Task.Delay(600);

            using (var dataReader = DataReader.FromBuffer(buffer))
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    Svg3 = dataReader.ReadString(buffer.Length);
                });
            }
            var svgBuffer = CryptographicBuffer.ConvertStringToBinary("svg3", BinaryStringEncoding.Utf8);
        }
        private async void Myimage_Loaded4(object sender, RoutedEventArgs e)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Svg.txt");
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            await Task.Delay(800);

            using (var dataReader = DataReader.FromBuffer(buffer))
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {

                    Svg4 = dataReader.ReadString(buffer.Length);
                });
            }
            var svgBuffer = CryptographicBuffer.ConvertStringToBinary("svg4", BinaryStringEncoding.Utf8);
        }
        private async void Myimage_Loaded5(object sender, RoutedEventArgs e)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync("Svg.txt");
            IBuffer buffer = await FileIO.ReadBufferAsync(file);
            await Task.Delay(1000);

            using (var dataReader = DataReader.FromBuffer(buffer))
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    Svg5 = dataReader.ReadString(buffer.Length);
                });
            }
            var svgBuffer = CryptographicBuffer.ConvertStringToBinary("svg5", BinaryStringEncoding.Utf8);
        }
    }

    public class SVGImageConverter : IValueConverter
    {
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var svg = new SvgImageSource();
            try
            {
                var svgBuffer = CryptographicBuffer.ConvertStringToBinary(value?.ToString(), BinaryStringEncoding.Utf8);

                using (var stream = svgBuffer.AsStream())
                {
                    svg.SetSourceAsync(stream.AsRandomAccessStream()).AsTask().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
            }
            return svg;
        }
    }
}
