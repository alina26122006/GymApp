using System.Windows;
using GymLibrary;

namespace GymApp
{
    public partial class ServiceWindow : Window
    {
        private JsonRepository<Service> serviceRepository;

        public ServiceWindow(JsonRepository<Service> repository)
        {
            InitializeComponent();
            serviceRepository = repository;
            UpdateServiceList();
        }

        private void UpdateServiceList()
        {
            ServiceListBox.ItemsSource = null;
            ServiceListBox.ItemsSource = serviceRepository.GetAll();
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            var newService = new Service { Id = serviceRepository.GetAll().Count + 1, Name = "Новая услуга", Price = 100, Description = "Описание" };
            serviceRepository.Add(newService);
            UpdateServiceList();
        }

        private void ServiceListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ServiceListBox.SelectedItem is Service selectedService)
            {
                ServiceNameTextBox.Text = selectedService.Name;
                ServicePriceTextBox.Text = selectedService.Price.ToString();
                ServiceDescriptionTextBox.Text = selectedService.Description;
            }
        }

        private void SaveService_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceListBox.SelectedItem is Service selectedService)
            {
                selectedService.Name = ServiceNameTextBox.Text;
                if (decimal.TryParse(ServicePriceTextBox.Text, out var price))
                {
                    selectedService.Price = price;
                }
                selectedService.Description = ServiceDescriptionTextBox.Text;
                serviceRepository.Update(selectedService);
                UpdateServiceList();
            }
        }
    }
}
