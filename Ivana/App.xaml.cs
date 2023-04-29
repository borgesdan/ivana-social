using Ivana.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Ivana
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            try
            {
                var context = AppDbContextFactory.Create();
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível criar o banco de dados", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
