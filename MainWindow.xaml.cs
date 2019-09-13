using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using RestSharp;
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

namespace BingMapXyrilleMamalateoNew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myMap.Focus();
            myMap.Mode = new AerialMode(true);
        }

        private void MyMap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Disables the default mouse double-click action.
            e.Handled = true;

            // Determin the location to place the pushpin at on the map.

            //Get the mouse click coordinates
            Point mousePosition = e.GetPosition(this);
            //Convert the mouse coordinates to a locatoin on the map
            Location pinLocation = myMap.ViewportPointToLocation(mousePosition);

            // The pushpin to add to the map.
            Pushpin pin = new Pushpin();
            pin.Location = pinLocation;

            // Adds the pushpin to the map.
            myMap.Children.Add(pin);



            var client = new RestClient("https://api.darksky.net/forecast/64ee9d4e589bb2cb3788596fd477b0f7/14.8781,120.4546");
            var request = new RestRequest("", Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var area = JsonConvert.DeserializeObject<WeatherArea>(content);


            lblSummary.Content = area.Currently.Summary;
            lblTemperature.Content = area.Currently.Temperature;
            lblHumidity.Content = area.Currently.Humidity;
            lblWindSpeed.Content = area.Currently.WindSpeed;
            lblDateTime.Content = DateTime.Now.ToString("hh:mm tt");

            BitmapImage bi = new BitmapImage();
            // BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit();
            bi.UriSource = new Uri(@"/Images/images.jpg", UriKind.RelativeOrAbsolute);
            bi.EndInit();

            // Set the image source.
            imageWeatherPanel.Source = bi;


        }
    }
}
