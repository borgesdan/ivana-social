using Ivana.Controls;
using Ivana.Data.Context;
using Ivana.Data.Entities;
using Microsoft.EntityFrameworkCore;
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

namespace Ivana.Pages
{
    /// <summary>
    /// Interaction logic for RegistryListPage.xaml
    /// </summary>
    public partial class RegistryListPage : Page
    {
        private AppDbContext? context = AppDbContextFactory.Create();
        int _page = 1;
        int _pageCount = 30;
        int _total = -1;
        bool isLoaded = false;

        public RegistryListPage()
        {
            InitializeComponent();
        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
                return;

            var list = new List<DemandEntity>();
            var pageContent = ((ComboBoxItem)PageCount.SelectedValue).Content;

            _ = int.TryParse((string)pageContent, out _pageCount);

            if (string.IsNullOrWhiteSpace(PatientName.Text) && StartDate.SelectedDate == null && EndDate.SelectedDate == null)
            {
                list = await context.Demands
                    .OrderBy(d => d.PatientName)
                    .Skip((_page - 1) * _pageCount)
                    .Take(_pageCount)
                    .AsNoTracking()
                    .ToListAsync();

                _total = await context.Demands.CountAsync();
            }
            else
            {
                var start = StartDate.SelectedDate;
                var end = EndDate.SelectedDate;

                if (start > end)
                    start = end;

                IQueryable<DemandEntity>? query = context.Demands.AsQueryable();

                if (!string.IsNullOrWhiteSpace(PatientName.Text))
                    query = context.Demands.Where(d =>
                        (!string.IsNullOrWhiteSpace(d.PatientNameNormalized) && d.PatientNameNormalized.Contains(PatientName.Text.ToUpper()))
                        || (!string.IsNullOrWhiteSpace(d.PatientSocialNameNormalized) && d.PatientSocialNameNormalized.Contains(PatientName.Text.ToUpper())));

                if (start != null)
                    query = query.Where(d => d.ServiceDate >= start);

                if (end != null)
                    query = query.Where(d => d.ServiceDate <= end);

                list = await query
                    .OrderBy(d => d.PatientName)
                    .Skip((_page - 1) * _pageCount)
                    .Take(_pageCount)
                    .AsNoTracking()
                    .ToListAsync();

                _total = await query.CountAsync();
            }

            ResultPanel.Children.Clear();

            if (list.Count == 0)
            {
                PageManagerPanel.IsEnabled = false;
                _page = 1;
                return;
            }
            else
            {
                PageManagerPanel.IsEnabled = true;

                foreach (var d in list)
                {
                    var control = new RegistryDetailListControl(d);

                    control.MouseDown += (s, e) =>
                    {   
                        MainWindow.Instance.NavigateToDemandRegistry(control.GetEntity().Id, control.GetEntity().PatientName ?? "Demanda");
                    };

                    ResultPanel.Children.Add(control);
                }
            }

            PageNumber.Text = _page.ToString();
            Total.Text = _total.ToString();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            context ??= AppDbContextFactory.Create();

            if(!isLoaded)
                Search_Click(sender,e);

            isLoaded = true;
        }        

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //if (context != null)
            //{
            //    context.Dispose();
            //    context = null;
            //}
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            if (_page > 1)
            {
                _page--;
                Search_Click(sender, e);
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if ((_page * _pageCount) < _total)
            {
                _page++;
                Search_Click(sender, e);
            }
        }

        private void PageCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            _page = 1;
            Search_Click(sender, null);
        }
    }
}
