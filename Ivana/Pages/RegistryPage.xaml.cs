using Ivana.Controls;
using Ivana.Core;
using Ivana.Data;
using Ivana.Data.Context;
using Ivana.Data.Entities;
using Ivana.Pages.Print;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace Ivana.Pages
{
    /// <summary>
    /// Interaction logic for RegistryPage.xaml
    /// </summary>
    public partial class RegistryPage : Page
    {
        private AppDbContext? _context = AppDbContextFactory.Create();
        private DemandEntity? _entity = null;

        public RegistryPage()
        {
            InitializeComponent();
            LoadComponents();
        }

        public RegistryPage(int demandId)
        {
            InitializeComponent();

            _entity = _context.Demands
                .Where(d => d.Id == demandId)
                .Include(i => i.FamilyCompositions)
                .Include(i => i.EconomicSituations)
                .FirstOrDefault();

            LoadComponents();
        }

        private void LoadComponents()
        {
            ServiceDate.SelectedDate = DateTime.Now;
            ServiceNumber.ApplyOnlyNumbers();
            PatientName.ApplyOnlyLetterOrWhiteSpace();
            PatientSocialName.ApplyOnlyLetterOrWhiteSpace();
            PatientPhone.ApplyPhoneNumbers();
            PatientCPF.ApplyCPFMask();
            RoomsNumber.ApplyOnlyNumbers();
            ResidenceYears.ApplyOnlyNumbers();
            ResidenceMonths.ApplyOnlyNumbers();
            RentAmount.ApplyDecimal();
            MedicineAmount.ApplyDecimal();
            BolsaFamiliaValue.ApplyDecimal();
            PatientBirthDate.SelectedDateChanged += (object? sender, SelectionChangedEventArgs e) 
                => PatientAge.Text = PatientBirthDate.SelectedDate.GetAge()?.ToString() ?? string.Empty;

            if (_entity != null)
            {
                DemandSituation.SelectedIndex = (int)_entity.Status;
                ServiceLocal.Text = _entity.ServiceLocal;
                ServiceNumber.Text = _entity.ServiceNumber;
                ServiceDate.SelectedDate = _entity.ServiceDate;
                PatientName.Text = _entity.PatientName;
                PatientGender.SelectedIndex = (int)_entity.PatientGender;
                PatientSocialName.Text = _entity.PatientSocialName;
                PatientPhone.Text = _entity.PatientPhone;
                PatientBirthDate.SelectedDate = _entity.PatientBirthDate;
                PatientBirthLocal.Text = _entity.PatientBirthLocal;
                PatientCPF.Text = _entity.PatientCPF;
                PatientRG.Text = _entity.PatientRG;
                PatientEducation.Text = _entity.PatientEducation;
                PatientAddressStreet.Text = _entity.PatientAddressStreet;
                PatientAddressNumber.Text = _entity.PatientAddressNumber;
                PatientAddressDistrict.Text = _entity.PatientAddressDistrict;
                PatientAddressReference.Text = _entity.PatientAddressReference;
                PatientCivilState.SelectedIndex = (int)_entity.PatientCivilState;
                PatientRelationship.SelectedIndex = (int)_entity.PatientRelationship;
                ResidenceType.SelectedIndex = (int)_entity.ResidenceType;
                RoomsNumber.Text = _entity.RoomsNumber.ToString();
                ResidenceStatus.SelectedIndex = (int)_entity.ResidenceStatus;
                RentAmount.Text = _entity.RentAmount.ToString("C");
                ResidenceYears.Text = _entity.ResidenceYears.ToString();
                ResidenceMonths.Text = _entity.ResidenceMonths.ToString();
                HasMedicalAssistance.SelectedIndex = (int)_entity.MedicalAssistance;
                UBSName.Text = _entity.UBSName;
                MedicineAmount.Text = _entity.MedicineAmount.ToString("C");
                FamilyDependent.Text = _entity.FamilyDependent;
                DisabledPersonType.SelectedIndex = (int)_entity.DisabledPersonType;
                DisabledPersonDescription.Text = _entity.DisabledPersonDescription;
                IsBolsaFamilia.IsChecked = _entity.IsBolsaFamilia;
                BolsaFamiliaValue.Text = _entity.BolsaFamiliaValue.ToString("C");
                IsBPC.IsChecked = _entity.IsBPC;
                HasAnotherAssistanceType.IsChecked = _entity.HasAnotherAssistanceType;
                IsSCFV.SelectedIndex = _entity.IsSCFV ? 0 : 1;
                SCFVDescription.Text = _entity.SCFVDescription;
                OtherAssistenceProgram.Text = _entity.OtherAssistenceProgram;
                AdmissionStyle.SelectedIndex = (int)_entity.AdmissionStyle;
                OtherAdmissionDescription.Text = _entity.OtherAdmissionDescription;
                DemandsDescription.Text = _entity.DemandsDescription;
                Observations.Text = _entity.Observations;

                SetFamilyCompositionControls();
                SetEconomicSituationControls();
            }

            ServiceLocal.Focus();
        }

        private void AddFamilyComposition_Click(object sender, RoutedEventArgs e)
        {
            var compositionControl = new FamilyCompositionControl();
            var childrenCount = FamilyComposition.Children.Count;

            FamilyComposition.Children.Insert(childrenCount, compositionControl);
        }

        private void AddEconomicSituation_Click(object sender, RoutedEventArgs e)
        {
            var control = new EconomicSituationControl();
            var childrenCount = EconomicSituation.Children.Count;

            EconomicSituation.Children.Insert(childrenCount, control);
        }

        private bool Validate()
        {
            MainPanel.ForEachVisual(v =>
            {
                if (v != null && v is TextBox tx)
                    tx.Text.Trim();
            });            

            if (string.IsNullOrWhiteSpace(PatientName.Text))
            {
                MessageBox.Show("Você precisa digitar o nome do paciente antes de salvar os dados.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        private async void Apply_Click(object sender, RoutedEventArgs e)
        {
            if (!Validate())
                return;

            var create = false;

            if (_context == null)
                _context = AppDbContextFactory.Create();

            if (_entity == null)
            {
                _entity = new DemandEntity();
                create = true;
            }

            _entity.Status = (DemandStatus)DemandSituation.SelectedIndex;
            _entity.ServiceLocal = ServiceLocal.Text;
            _entity.ServiceNumber = ServiceNumber.Text;
            _entity.ServiceDate = ServiceDate.SelectedDate != null ? ServiceDate.SelectedDate : DateTime.Now;
            _entity.PatientName = PatientName.Text;
            _entity.PatientNameNormalized = PatientName.Text.RemoveDiacritics().ToUpperInvariant();
            _entity.PatientGender = (GenderType)PatientGender.SelectedIndex;
            _entity.PatientSocialName = PatientSocialName.Text;
            _entity.PatientSocialNameNormalized = PatientName.Text.RemoveDiacritics().ToUpperInvariant();
            _entity.PatientPhone = PatientPhone.Text.ApplyOnlyNumber();
            _entity.PatientBirthDate = PatientBirthDate.SelectedDate;
            _entity.PatientBirthLocal = PatientBirthLocal.Text;
            _entity.PatientCPF = PatientCPF.Text.ApplyOnlyNumber();
            _entity.PatientRG = PatientRG.Text;
            _entity.PatientEducation = PatientEducation.Text;
            _entity.PatientAddressStreet = PatientAddressStreet.Text;
            _entity.PatientAddressNumber = PatientAddressNumber.Text;
            _entity.PatientAddressDistrict = PatientAddressDistrict.Text;
            _entity.PatientAddressReference = PatientAddressReference.Text;
            _entity.PatientCivilState = (PatientCivilStateType)PatientCivilState.SelectedIndex;
            _entity.PatientRelationship = (PatientRelationshipType)PatientRelationship.SelectedIndex;
            _entity.ResidenceType = (PatientResidenceType)ResidenceType.SelectedIndex;
            _entity.RoomsNumber = int.TryParse(RoomsNumber.Text.ApplyOnlyNumber(), out int rooms) ? rooms : 0;
            _entity.ResidenceStatus = (PatientResidenceStatusType)ResidenceStatus.SelectedIndex;
            _entity.RentAmount = decimal.TryParse(RentAmount.Text.ApplyOnlyNumberOrChars(','), out decimal rent) ? rent : 0;
            _entity.ResidenceYears = int.TryParse(ResidenceYears.Text.ApplyOnlyNumber(), out int years) ? years : 0;
            _entity.ResidenceMonths = int.TryParse(ResidenceMonths.Text.ApplyOnlyNumber(), out int months) ? months : 0;
            _entity.MedicalAssistance = (PatientMedicalAssistanceType)HasMedicalAssistance.SelectedIndex;
            _entity.UBSName = UBSName.Text;
            _entity.MedicineAmount = decimal.TryParse(MedicineAmount.Text.ApplyOnlyNumberOrChars(','), out decimal medicine) ? medicine : 0;
            _entity.FamilyDependent = FamilyDependent.Text;
            _entity.DisabledPersonType = (PatientDisabledPersonType)DisabledPersonType.SelectedIndex;
            _entity.DisabledPersonDescription = DisabledPersonDescription.Text;
            _entity.IsBolsaFamilia = IsBolsaFamilia.IsChecked == true;
            _entity.BolsaFamiliaValue = decimal.TryParse(BolsaFamiliaValue.Text.ApplyOnlyNumberOrChars(','), out decimal bolsaValue) ? bolsaValue : 0;
            _entity.IsBPC = IsBPC.IsChecked == true;
            _entity.HasAnotherAssistanceType = HasAnotherAssistanceType.IsChecked == true;
            _entity.IsSCFV = IsSCFV.SelectedIndex == 0;
            _entity.SCFVDescription = SCFVDescription.Text;
            _entity.OtherAssistenceProgram = OtherAssistenceProgram.Text;
            _entity.AdmissionStyle = (PatientAdmissionStyleType)AdmissionStyle.SelectedIndex;
            _entity.OtherAdmissionDescription = OtherAdmissionDescription.Text;
            _entity.DemandsDescription = DemandsDescription.Text;
            _entity.Observations = Observations.Text;

            ApplyFamilyComposition(create);
            ApplyEconomicSituation(create);

            try
            {
                if (create)
                    _context.Add(_entity);

                await _context.SaveChangesAsync();
                MessageBox.Show("Dados registrados com sucesso.", "Tudo ocorreu bem.", MessageBoxButton.OK, MessageBoxImage.Information);

                FamilyComposition.Children.Clear();
                EconomicSituation.Children.Clear();
                
                SetFamilyCompositionControls();
                SetEconomicSituationControls();
            }
            catch
            {
                MessageBox.Show("Infelizmente não possível salvar os dados. Tente mais uma vez e se o problema persistir relate o erro.", "A vida é feita de problemas!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SetFamilyCompositionControls()
        {
            foreach (var composition in _entity.FamilyCompositions)
            {
                var childrenCount = FamilyComposition.Children.Count;
                FamilyComposition.Children.Insert(childrenCount, new FamilyCompositionControl(composition));
            }
        }

        private void SetEconomicSituationControls()
        {
            foreach (var economic in _entity.EconomicSituations)
            {
                var childrenCount = EconomicSituation.Children.Count;
                EconomicSituation.Children.Insert(childrenCount, new EconomicSituationControl(economic));
            }
        }

        private void ApplyFamilyComposition(bool createMode)
        {
            if (createMode)
            {
                foreach(var child in FamilyComposition.Children)
                {
                    if(child is FamilyCompositionControl ctrl)
                    {
                        if (ctrl.IsValid && ctrl.Visibility == Visibility.Visible)
                            _entity.FamilyCompositions.Add(ctrl.GetEntity());
                    }
                }

                return;
            }

            foreach (var child in FamilyComposition.Children)
            {
                if (child is FamilyCompositionControl ctrl)
                {
                    if (!ctrl.IsValid)
                        continue;

                    var current = ctrl.GetEntity();

                    if (current.Id == 0 && ctrl.IsVisible)
                    {
                        _entity.FamilyCompositions.Add(current);
                        continue;
                    }
                        
                    var finder = _entity.FamilyCompositions.FirstOrDefault(f => f.Id == current.Id);

                    if (finder == null)
                        continue;

                    if (ctrl.Visibility != Visibility.Visible)
                    {
                        _entity.FamilyCompositions.Remove(finder);
                        _context.Remove(finder);
                    }                        
                    else
                    {
                        finder.BirthDate = current.BirthDate;
                        finder.Observations = current.Observations;
                        finder.Relationship = current.Relationship;
                        finder.Education = current.Education;
                        finder.Gender = current.Gender;
                        finder.Name = current.Name;
                    }
                }
            }
        }

        private void ApplyEconomicSituation(bool createMode)
        {
            if (createMode)
            {
                foreach (var child in EconomicSituation.Children)
                {
                    if (child is EconomicSituationControl ctrl)
                    {
                        if (ctrl.IsValid && ctrl.Visibility == Visibility.Visible)
                            _entity.EconomicSituations.Add(ctrl.GetEntity());
                    }
                }

                return;
            }

            foreach (var child in EconomicSituation.Children)
            {
                if (child is EconomicSituationControl ctrl)
                {
                    if (!ctrl.IsValid)
                        continue;

                    var current = ctrl.GetEntity();

                    if (current.Id == 0 && ctrl.IsVisible)
                    {
                        _entity.EconomicSituations.Add(current);
                        continue;
                    }

                    var finder = _entity.EconomicSituations.FirstOrDefault(f => f.Id == current.Id);

                    if (finder == null)
                        continue;

                    if (ctrl.Visibility != Visibility.Visible)
                    {
                        _entity.EconomicSituations.Remove(finder);
                        _context.Remove(finder);
                    }
                    else
                    {
                        finder.Observations = current.Observations;
                        finder.Income = current.Income;
                        finder.IncomeAmount = current.IncomeAmount;
                        finder.Name = current.Name;                        
                    }
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_context == null)
                _context = AppDbContextFactory.Create();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //if (_context != null)
            //{
            //    _context.Dispose();
            //    _context = null;
            //}
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            if (_entity == null)
                return;            

            PrintFixedPages();
        }

        private void PrintFixedPages()
        {
            var pageSize = new Size(8.26 * 96, 11.69 * 96);
            var document = new FixedDocument();
            document.DocumentPaginator.PageSize = pageSize;

            var fixedPage = new FixedPage();
            fixedPage.Width = pageSize.Width;
            fixedPage.Height = pageSize.Height;
            fixedPage.Margin = new Thickness(50, 20, 0, 10);

            var registryPrintPage = new RegistryPrintPage(_entity);
            var mainGrid = registryPrintPage.MainGrid;
            var mainStack = mainGrid.Children[0];
            mainGrid.Children.Remove(mainStack);

            fixedPage.Resources = registryPrintPage.Resources;

            fixedPage.Children.Add((UIElement)mainStack);
            fixedPage.Measure(pageSize);
            fixedPage.Arrange(new Rect(new Point(), pageSize));
            fixedPage.UpdateLayout();

            var pageContent = new PageContent();
            ((IAddChild)pageContent).AddChild(fixedPage);
            document.Pages.Add(pageContent);

            var fixedPage2 = new FixedPage();
            fixedPage2.Width = pageSize.Width;
            fixedPage2.Height = pageSize.Height;
            fixedPage2.Margin = new Thickness(50, 20, 0, 10);

            var registryPrintPage2 = new RegistryPrintPage2(_entity);
            var mainGrid2 = registryPrintPage2.MainGrid;
            var mainStack2 = mainGrid2.Children[0];
            mainGrid2.Children.Remove(mainStack2);

            fixedPage2.Resources = registryPrintPage2.Resources;

            fixedPage2.Children.Add((UIElement)mainStack2);
            fixedPage2.Measure(pageSize);
            fixedPage2.Arrange(new Rect(new Point(), pageSize));
            fixedPage2.UpdateLayout();

            var pageContent2 = new PageContent();
            ((IAddChild)pageContent2).AddChild(fixedPage2);
            document.Pages.Add(pageContent2);

            try
            {
                var pd = new PrintDialog();
                pd.PrintDocument(document.DocumentPaginator, "Página de Atendimento");

                MessageBox.Show("O arquivo PDF foi salvo para impressão!", "Tudo certo!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao criar o arquivo PDF. Verifique se o arquivo já está aberto e tente novamente", "Tudo errado!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
