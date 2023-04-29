using Ivana.Core;
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

namespace Ivana.Pages.Print
{
    /// <summary>
    /// Interaction logic for RegistryPrintPage.xaml
    /// </summary>
    public partial class RegistryPrintPage : Page
    {
        public RegistryPrintPage(DemandEntity entity)
        {
            InitializeComponent();

            ServiceLocal.Text = entity.ServiceLocal;
            ServiceNumber.Text = entity.ServiceNumber;
            ServiceDate.Text = entity.ServiceDate?.ToShortDateString();
            PatientName.Text = entity.PatientName;
            PatientGender.SelectedIndex = (int)entity.PatientGender;
            PatientSocialName.Text = entity.PatientSocialName;
            PatientPhone.Text = entity.PatientPhone?.ApplyPhoneMask();
            PatientBirthDate.Text = entity.PatientBirthDate?.ToShortDateString();
            PatientBirthLocal.Text = entity.PatientBirthLocal;
            PatientCPF.Text = entity.PatientCPF;
            PatientRG.Text = entity.PatientRG;
            PatientEducation.Text = entity.PatientEducation;
            PatientAddressStreet.Text = entity.PatientAddressStreet;
            PatientAddressNumber.Text = entity.PatientAddressNumber;
            PatientAddressDistrict.Text = entity.PatientAddressDistrict;
            PatientAddressReference.Text = entity.PatientAddressReference;
            PatientCivilState.SelectedIndex = (int)entity.PatientCivilState;
            PatientRelationship.SelectedIndex = (int)entity.PatientRelationship;
            ResidenceType.SelectedIndex = (int)entity.ResidenceType;
            RoomsNumber.Text = entity.RoomsNumber.ToString();
            ResidenceStatus.SelectedIndex = (int)entity.ResidenceStatus;
            RentAmount.Text = entity.RentAmount.ToString();
            ResidenceYears.Text = entity.ResidenceYears.ToString();
            ResidenceMonths.Text = entity.ResidenceMonths.ToString();
            HasMedicalAssistance.SelectedIndex = (int)entity.MedicalAssistance;
            UBSName.Text = entity.UBSName;
            MedicineAmount.Text = entity.MedicineAmount.ToString();
            FamilyDependent.Text = entity.FamilyDependent;
            DisabledPersonType.SelectedIndex = (int)entity.DisabledPersonType;
            DisabledPersonDescription.Text = entity.DisabledPersonDescription;
            IsBolsaFamilia.IsChecked = entity.IsBolsaFamilia;
            HasAnotherAssistanceType.IsChecked = entity.HasAnotherAssistanceType;
            IsSCFV.SelectedIndex = entity.IsSCFV ? 0 : 1;
            SCFVDescription.Text = entity.SCFVDescription;
            OtherAssistenceProgram.Text = entity.OtherAssistenceProgram;
            AdmissionStyle.SelectedIndex = (int)entity.AdmissionStyle;
            OtherAdmissionDescription.Text = entity.OtherAdmissionDescription;
            DemandsDescription.Text = entity.DemandsDescription;
            Observations.Text = entity.Observations;
        }
    }
}
