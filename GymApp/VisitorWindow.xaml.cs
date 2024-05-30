using System;
using System.Windows;
using GymLibrary;

namespace GymApp
{
    public partial class VisitorWindow : Window
    {
        private JsonRepository<Visitor> visitorRepository;

        public VisitorWindow(JsonRepository<Visitor> repository)
        {
            InitializeComponent();
            visitorRepository = repository;
            UpdateVisitorList();
        }

        private void UpdateVisitorList()
        {
            VisitorListBox.ItemsSource = null;
            VisitorListBox.ItemsSource = visitorRepository.GetAll();
        }

        private void AddVisitor_Click(object sender, RoutedEventArgs e)
        {
            var newVisitor = new Visitor { FirstName = "Имя", LastName = "Фамилия", VisitDate = DateTime.Now };
            visitorRepository.Add(newVisitor);
            UpdateVisitorList();
        }
    }
}
