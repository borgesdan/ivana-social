using Ivana.Controls;
using Ivana.Core;
using Ivana.Data.Entities;
using Ivana.Pages;
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

namespace Ivana
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double contentPageMinWidth = 800;
        double contentPageMaxWidth = 1280;
        TabItem? persitedTab = null;

        public static MainWindow Instance { get; private set; }        

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private TabItem CreateNewTab(string header, Page contentPage)
        {
            contentPage.MinWidth = contentPageMinWidth;
            contentPage.MaxWidth = contentPageMaxWidth;
            contentPage.Title = header;

            var frame = new Frame
            {
                Content = contentPage,
                NavigationUIVisibility = NavigationUIVisibility.Hidden
            };

            var scrollViewer = new ScrollViewer
            {
                Content = frame
            };

            var tabItem = new TabItem
            {
                Header = new HeaderControl(header),
                Content = scrollViewer,
                IsSelected = true,
                Background = Brushes.Gray,
                Name = Guid.NewGuid().ToString().ApplyOnlyLetter()
            };

            return tabItem;
        }

        private void AddDemand_Click(object sender, RoutedEventArgs e)
        {
            var tab = CreateNewTab("Nova Demanda", new RegistryPage());
            MainContent.Items.Add(tab);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var tab = CreateNewTab("Nova Consulta", new RegistryListPage());
            MainContent.Items.Add(tab);
        }

        public void NavigateToDemandRegistry(int demandId, string pageHeader)
        {
            var tab = CreateNewTab(pageHeader, new RegistryPage(demandId));                        
            MainContent.Items.Add(tab);

            persitedTab = tab;
        }

        public void GoToLastTab()
        {
            int count = MainContent.Items.Count;
            MainContent.SelectedIndex = count - 1;
        }

        private void MainContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (persitedTab == null)
                return;

            MainContent.SelectedItem = persitedTab;
            persitedTab = null;
        }
    }
}
