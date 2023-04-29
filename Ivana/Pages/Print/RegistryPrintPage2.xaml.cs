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

            for (int i = 0; i < 10; ++i)
            {
                if (i < family.Count)
                {
                    MainStack.FindControlByName($"FullName{i + 1}", v => ((TextBox)v).Text = family[i].Name);
                    MainStack.FindControlByName($"Relationship{i + 1}", v => ((ComboBox)v).SelectedIndex = (int)family[i].Relationship);
                    MainStack.FindControlByName($"BirthDate{i + 1}", v => ((TextBox)v).Text = family[i].BirthDate?.ToShortDateString());
                    MainStack.FindControlByName($"Education{i + 1}", v => ((ComboBox)v).SelectedIndex = (int)family[i].Education);
                    MainStack.FindControlByName($"Gender{i + 1}", v => ((ComboBox)v).SelectedIndex = (int)family[i].Gender);
                }
                if (i < economic.Count)
                {
                    MainStack.FindControlByName($"EcnomicFullName{i + 1}", v => ((TextBox)v).Text = economic[i].Name);
                    MainStack.FindControlByName($"Income{i + 1}", v => ((ComboBox)v).SelectedIndex = (int)economic[i].Income);
                    MainStack.FindControlByName($"IncomeAmount{i + 1}", v => ((TextBox)v).Text = economic[i].IncomeAmount.ToString());
                }
            }
        }
    }
}
