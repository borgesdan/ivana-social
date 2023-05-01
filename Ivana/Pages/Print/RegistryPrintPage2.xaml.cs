using Ivana.Controls;
using Ivana.Core;
using Ivana.Data.Entities;
using System.Linq;
using System.Windows.Controls;

namespace Ivana.Pages.Print
{
    /// <summary>
    /// Interaction logic for RegistryPrintPage2.xaml
    /// </summary>
    public partial class RegistryPrintPage2 : Page
    {
        public RegistryPrintPage2(DemandEntity entity)
        {
            InitializeComponent();

            var family = entity.FamilyCompositions.ToList();
            var economic = entity.EconomicSituations.ToList();

            for (int i = 0; i < 12; ++i)
            {
                if (i < family.Count)
                {
                    FamilyCompositionPrintControl familyControl = new FamilyCompositionPrintControl(family[i]);
                    RelationshipStack.Children.Add(familyControl);
                }
                if (i < economic.Count)
                {
                    EconomicSituationPrintControl economicSituationControl = new EconomicSituationPrintControl(economic[i]);
                    EconomicStack.Children.Add(economicSituationControl);
                }
            }
        }
    }
}
