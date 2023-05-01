using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ivana.Data.Entities
{
    public class DemandEntity
    {
        public int Id { get; set; }

        public DemandStatus Status { get; set; }

        [StringLength(200)]
        public string? ServiceLocal { get; set; }
        [StringLength(8)]
        public string? ServiceNumber { get; set; }
        public DateTime? ServiceDate { get; set; }

        [StringLength(200)]
        public string? PatientName { get; set; }
        [StringLength(200)]
        public string? PatientNameNormalized { get; set; }
        public GenderType PatientGender { get; set; }
        [StringLength(200)]
        public string? PatientSocialName { get; set; }
        [StringLength(200)]
        public string? PatientSocialNameNormalized { get; set; }
        [StringLength(80)]
        public string? PatientPhone { get; set; }
        public DateTime? PatientBirthDate { get; set; }
        [StringLength(200)]
        public string? PatientBirthLocal { get; set; }
        [StringLength(80)]
        public string? PatientCPF { get; set; }
        [StringLength(80)]
        public string? PatientRG { get; set; }
        [StringLength(80)]
        public string? PatientEducation { get; set; }
        [StringLength(80)]
        public string? PatientAddressStreet { get; set; }
        [StringLength(8)]
        public string? PatientAddressNumber { get; set; }
        [StringLength(80)]
        public string? PatientAddressDistrict { get; set; }
        [StringLength(200)]
        public string? PatientAddressReference { get; set; }
        public PatientCivilStateType PatientCivilState { get; set; }
        public PatientRelationshipType PatientRelationship { get; set; }

        public PatientResidenceType ResidenceType { get; set; }
        public int RoomsNumber { get; set; }
        public PatientResidenceStatusType ResidenceStatus { get; set; }
        [StringLength(8)]
        public decimal RentAmount { get; set; }
        public int ResidenceYears { get; set; }
        public int ResidenceMonths { get; set; }

        public PatientMedicalAssistanceType MedicalAssistance { get; set; }
        [StringLength(200)]
        public string? UBSName { get; set; }
        [StringLength(8)]
        public decimal MedicineAmount { get; set; }
        [StringLength(200)]
        public string? FamilyDependent { get; set; }
        public PatientDisabledPersonType DisabledPersonType { get; set; }
        [StringLength(80)]
        public string? DisabledPersonDescription { get; set; }
        
        public bool IsBolsaFamilia { get; set; }
        [StringLength(8)]
        public decimal BolsaFamiliaValue { get; set; }
        public bool IsBPC { get; set; }
        public bool HasAnotherAssistanceType { get; set; }
        [StringLength(80)]
        public string? AnotherAssistanceDescription { get; set; }
        public bool IsCrasAssistance { get; set; }
        public bool IsSCFV { get; set; }
        [StringLength(80)]
        public string? SCFVDescription { get; set; }
        [StringLength(80)]
        public string? OtherAssistenceProgram { get; set; }
        
        public PatientAdmissionStyleType AdmissionStyle { get; set; }
        [StringLength(80)]
        public string? OtherAdmissionDescription { get; set; }
        [StringLength(2000)]
        public string? DemandsDescription { get; set; }
        [StringLength(5000)]
        public string? Observations { get; set; }

        public virtual ICollection<EconomicSituationEntity> EconomicSituations { get; set; } = new HashSet<EconomicSituationEntity>();
        public virtual ICollection<FamilyCompositionEntity> FamilyCompositions { get; set; } = new HashSet<FamilyCompositionEntity>();
    }
}
