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
    /// Interaction logic for RegistryDetailListControl.xaml
    /// </summary>
    public partial class RegistryDetailListControl : UserControl
    {
        private DemandEntity demand;

        public RegistryDetailListControl(DemandEntity demand)
        {
            InitializeComponent();

            this.demand = demand;
            PatientName.Content = demand.PatientName;
            DemandNumber.Content = demand.ServiceNumber;

            switch(demand.Status)
            {
                case Data.DemandStatus.EmAndamento:
                    Status.Text = "EM ACOMPANHAMENTO";
                    Status.Background = Brushes.Green;
                    break;
                case Data.DemandStatus.Finalizada:
                    Status.Text = "FINALIZADO";
                    Status.Background = Brushes.Blue;
                    break;
                case Data.DemandStatus.Cancelada:
                    Status.Text = "CANCELADO";
                    Status.Background = Brushes.Red;
                    break;
            }
        }

        public DemandEntity GetEntity()
        {
            return demand;
        }
    }
}
