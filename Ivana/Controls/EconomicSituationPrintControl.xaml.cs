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
    /// Interaction logic for EconomicSituationPrintControl.xaml
    /// </summary>
    public partial class EconomicSituationPrintControl : UserControl
    {
        public EconomicSituationPrintControl(EconomicSituationEntity entity)
        {
            InitializeComponent();
            FullName.Text = entity.Name;
            Income.Text = EConverter.Convert(entity.Income);
            IncomeAmount.Text = entity.IncomeAmount.ToString("C");
        }
    }
}
