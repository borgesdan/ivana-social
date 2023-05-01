using Ivana.Core;
using Ivana.Data.Entities;
using System.Windows.Controls;

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

            RentAmount.ApplyDecimal();
            MedicineAmount.ApplyDecimal();
            BolsaFamiliaValue.ApplyDecimal();

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
            RentAmount.Text = entity.RentAmount.ToString("C");
            ResidenceYears.Text = entity.ResidenceYears.ToString();
            ResidenceMonths.Text = entity.ResidenceMonths.ToString();
            HasMedicalAssistance.SelectedIndex = (int)entity.MedicalAssistance;
            UBSName.Text = entity.UBSName;
            MedicineAmount.Text = entity.MedicineAmount.ToString("C");
            FamilyDependent.Text = entity.FamilyDependent;
            DisabledPersonType.SelectedIndex = (int)entity.DisabledPersonType;
            DisabledPersonDescription.Text = entity.DisabledPersonDescription;
            IsBolsaFamilia.IsChecked = entity.IsBolsaFamilia;
            BolsaFamiliaValue.Text = entity.BolsaFamiliaValue.ToString("C");
            IsBPC.IsChecked = entity.IsBPC;
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
