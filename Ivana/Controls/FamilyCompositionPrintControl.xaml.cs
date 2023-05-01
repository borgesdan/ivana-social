using Ivana.Data;
using Ivana.Data.Entities;
using System.ComponentModel;
using System.Windows.Controls;

namespace Ivana.Controls
{
    /// <summary>
    /// Interaction logic for FamilyCompositionPrintControl.xaml
    /// </summary>
    public partial class FamilyCompositionPrintControl : UserControl
    {
        public FamilyCompositionPrintControl(FamilyCompositionEntity entity)
        {
            InitializeComponent();                  

            FullName.Text = entity.Name;
            Relationship.Text = EConverter.Convert(entity.Relationship);
            BirthDate.Text = entity.BirthDate?.ToShortDateString();
            Education.Text = EConverter.Convert(entity.Education);
            Gender.Text = EConverter.Convert(entity.Gender);
        }
    }
}
