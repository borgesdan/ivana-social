using Ivana.Data;
using Ivana.Data.Entities;
using System.Windows;
using System.Windows.Controls;

namespace Ivana.Controls
{
    /// <summary>
    /// Interaction logic for FamilyCompositionControl.xaml
    /// </summary>
    public partial class FamilyCompositionControl : UserControl
    {
        int id = 0;

        public bool IsValid => !string.IsNullOrWhiteSpace(FullName.Text);

        public FamilyCompositionControl()
        {
            InitializeComponent();            
        }

        public FamilyCompositionControl(FamilyCompositionEntity entity)
        {
            InitializeComponent();

            id = entity.Id;

            FullName.Text = entity.Name;
            BirthDate.SelectedDate = entity.BirthDate;
            Education.SelectedIndex = (int)entity.Education;
            Relationship.SelectedIndex = (int)entity.Relationship;
            Gender.SelectedIndex = (int)entity.Gender;
        }

        public FamilyCompositionEntity GetEntity()
        {
            return new FamilyCompositionEntity
            {
                Id = id,
                BirthDate = BirthDate.SelectedDate,
                Education = (FamilyCompositionEducationType)Education.SelectedIndex,
                Relationship = (FamilyCompositionRelationshipType)Relationship.SelectedIndex,
                Gender = (GenderType)Gender.SelectedIndex,
                Name = FullName.Text,
                Observations = Observations.Text,
            };
        }

        private void Remove_Click(object sender, System.Windows.RoutedEventArgs e)
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
