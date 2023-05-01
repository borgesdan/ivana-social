using Ivana.Core;
using Ivana.Data;
using Ivana.Data.Entities;
using System.Windows;
using System.Windows.Controls;

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
            IncomeAmount.ApplyDecimal();
        }

        public EconomicSituationControl(EconomicSituationEntity entity)
        {
            InitializeComponent();
            IncomeAmount.ApplyDecimal();

            id = entity.Id;
            FullName.Text = entity.Name;
            Income.SelectedIndex = (int)entity.Income;
            IncomeAmount.Text = entity.IncomeAmount.ToString("C");
            Observations.Text = entity.Observations;
        }

        public EconomicSituationEntity GetEntity()
        {
            return new EconomicSituationEntity
            {
                Id = id,
                Name = FullName.Text,
                Income = (EconomicSituationIncomeType)Income.SelectedIndex,
                IncomeAmount = decimal.TryParse(IncomeAmount.Text.ApplyOnlyNumberOrChars(','), out decimal income) ? income : 0,
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
