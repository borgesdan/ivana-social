using Ivana.Data;
using Ivana.Data.Entities;
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

namespace Ivana.Controls
{
    /// <summary>
    /// Interaction logic for EconomicSituation.xaml
    /// </summary>
    public partial class EconomicSituationControl : UserControl
    {
        int id = 0;

        public bool IsValid => !string.IsNullOrWhiteSpace(FullName.Text);

        public EconomicSituationControl()
        {
            InitializeComponent();
        }

        public EconomicSituationControl(EconomicSituationEntity entity)
        {
            InitializeComponent();

            id = entity.Id;
            FullName.Text = entity.Name;
            Income.SelectedIndex = (int)entity.Income;
            IncomeAmount.Text = entity.IncomeAmount.ToString();
            Observations.Text = entity.Observations;
        }

        public EconomicSituationEntity GetEntity()
        {
            return new EconomicSituationEntity
            {
                Id = id,
                Name = FullName.Text,
                Income = (EconomicSituationIncomeType)Income.SelectedIndex,
                IncomeAmount = decimal.TryParse(IncomeAmount.Text, out decimal income) ? income : 0,
                Observations = Observations.Text
            };
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (!IsValid)
            {
                this.Visibility = Visibility.Collapsed;
                return;
            }

            var result = MessageBox.Show(
                "Deseja realmente remover esse registro?",
                "Remover",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            this.Visibility = Visibility.Collapsed;
        }
    }
}
