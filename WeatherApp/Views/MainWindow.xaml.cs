using OpenWeatherAPI;
using System.Windows;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            /// TODO : Faire les appels de configuration ici ainsi que l'initialisation
            ApiHelper.InitializeClient();

            ITemperatureService ITempServ = new OpenWeatherService(AppConfiguration.GetValue("ApiKey"));

            vm = new TemperatureViewModel();
            vm.SetTemperatureService(ITempServ);

            DataContext = vm;           
        }
    }
}
