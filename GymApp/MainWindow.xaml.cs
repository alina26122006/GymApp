using System.Windows;
using GymLibrary;

namespace GymApp
{
    public partial class MainWindow : Window
    {
        private JsonRepository<Visitor> visitorRepository;
        private JsonRepository<Service> serviceRepository;

        public MainWindow()
        {
            InitializeComponent();
            visitorRepository = new JsonRepository<Visitor>("visitors.json");
            serviceRepository = new JsonRepository<Service>("services.json");
        }

        private void ManageVisitors_Click(object sender, RoutedEventArgs e)
        {
            var visitorWindow = new VisitorWindow(visitorRepository);
            visitorWindow.Show();
        }

        private void ManageServices_Click(object sender, RoutedEventArgs e)
        {
            var serviceWindow = new ServiceWindow(serviceRepository);
            serviceWindow.Show();
        }
    }
}
