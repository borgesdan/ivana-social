using Ivana.Controls;
using Ivana.Core;
using Ivana.Data.Context;
using Ivana.Data.Entities;
using Ivana.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void Backup_Click(object sender, RoutedEventArgs e)
        {
            var file = new SaveFileDialog();
            file.DefaultExt = "db";
            file.Filter = "Arquivo de Backup (*.db)|*.db";            

            var resultDialog = file.ShowDialog();

            if (!resultDialog.HasValue || !resultDialog.Value)
                return;

            var sourcePath = System.IO.Path.Combine(Environment.CurrentDirectory, "database.db");
            var destinationPath = file.FileName;

            try
            {
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destinationPath, true);
                    MessageBox.Show("O arquivo de backup foi gerado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao realizar o backup do arquivo. Tente salvar em outro lugar e se persistir o problema entre em contato com o administrador.",
                    "Ocorreu um erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            var messageResult = MessageBox.Show("Deseja realmente restaurar o backup? As informações atuais serão sobrescritas.", "Aviso", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageResult != MessageBoxResult.Yes)
                return;

            var file = new OpenFileDialog();
            file.DefaultExt = "db";
            file.Filter = "Arquivo de Backup (*.db)|*.db";

            var resultDialog = file.ShowDialog();

            if (!resultDialog.HasValue || !resultDialog.Value)
                return;

            var sourcePath = file.FileName;
            var destinationPath = System.IO.Path.Combine(Environment.CurrentDirectory, "database.db"); 

            try
            {
                if (File.Exists(destinationPath))
                {
                    var context = AppDbContextFactory.Create();
                    context.Database.EnsureDeleted();
                }                

                File.Copy(sourcePath, destinationPath, true);
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao realizar a restauraração do backup. Se persistir o problema entre em contato com o administrador.",
                    "Ocorreu um erro!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
