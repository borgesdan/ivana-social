using System.Drawing;

namespace Ivana.Data
{
    public enum DemandStatus
    {
        EmAndamento,
        Finalizada,
        Cancelada
    }

    public enum GenderType
    {
        Feminino,
        Masculino
    }

    public enum PatientCivilStateType
    {
        Solteiro,
        Casado,
        Divorciado,
        Viuvo
    }

    public enum PatientRelationshipType
    {
        Pontual,
        BeneficioEventual,
        Promart,
        JoaoDeBarro,
        ViverMelhor
    }

    public enum PatientResidenceType
    {
        Alvenaria,
        Madeira,
        Mista
    }

    public enum PatientResidenceStatusType
    {
        Propria,
        Alugada,
        Cedida,
        Ocupada
    }

    public enum PatientMedicalAssistanceType
    {
        NaoPossui,
        Sus,
        Privado,
    }

    public enum PatientDisabledPersonType
    {
        Cegueira,
        BaixaVisao,
        SurdezSevera,
        SurdezLeve,
        DeficienciaFisica,
        DeficienciaMental,
        SindromeDown,
        TransfornoMental,
        Outros
    }

    public enum PatientAdmissionStyleType
    {
        Espontanea,
        BuscaAtiva,
        Craas,
        ConselhoTutelar,
        Indicacao,
        Outros
    }

    public enum FamilyCompositionRelationshipType
    {
        Conjuge,
        Filho,
        Enteado,
        Neto,
        PaiMae,
        Sogro,
        Irmao,
        Genro,
        Outro,
        NaoParente
    }

    public enum FamilyCompositionEducationType
    {
        Creche,
        Fundamental1,
        Fundamental2,
        Medio,
        SuperiorIncompleto,
        SuperiorCompleto,
        NaoAlfabetizado
    }

    public enum EconomicSituationIncomeType
    {
        Registrado,
        BPC,
        BPCIdoso,
        Aposentadoria,
        SeguroDesemprego,
        Pensao,
        Autonomo,
        Proprietario,
        Outro
    }

    public static class EConverter
    {
        public static string Convert(PatientRelationshipType patientRelationship)
        {
            switch(patientRelationship)
            {
                case PatientRelationshipType.Pontual:
                    return "Pontual";
                case PatientRelationshipType.Promart:
                    return "Promart";
                case PatientRelationshipType.JoaoDeBarro:
                    return "João de Barro";
                case PatientRelationshipType.BeneficioEventual:
                    return "Benefício Eventual";
                case PatientRelationshipType.ViverMelhor:
                    return "Viver Melhor";
                default:
                    return string.Empty;
            }
        }

        public static string Convert(GenderType gender, bool toLongString = false)
        {
            switch(gender)
            {
                case GenderType.Masculino:
                    return toLongString ? "Masculino" : "M";
                case GenderType.Feminino:
                    return toLongString ? "Feminino" : "F";
                default:
                    return string.Empty;
            }
        }

        public static string Convert(FamilyCompositionEducationType education)
        {
            switch (education)
            {
                case FamilyCompositionEducationType.Creche:
                    return "Creche";
                case FamilyCompositionEducationType.Fundamental1:
                    return "Fundamental 1";
                case FamilyCompositionEducationType.Fundamental2:
                    return "Fundamental 2";
                case FamilyCompositionEducationType.Medio:
                    return "Médio";
                case FamilyCompositionEducationType.SuperiorIncompleto:
                    return "Superior Incompleto";
                case FamilyCompositionEducationType.SuperiorCompleto:
                    return "Superior Completo";                
                case FamilyCompositionEducationType.NaoAlfabetizado:
                    return "Não Alfabetizado";
                default:
                    return string.Empty;
            }
        }
        
        public static string Convert(FamilyCompositionRelationshipType relationship)
        {
            switch (relationship)
            {
                case FamilyCompositionRelationshipType.Conjuge:
                    return "Cônjuge";
                case FamilyCompositionRelationshipType.Filho:
                    return "Filho";
                case FamilyCompositionRelationshipType.Enteado:
                    return "Enteado";
                case FamilyCompositionRelationshipType.Neto:
                    return "Neto";
                case FamilyCompositionRelationshipType.PaiMae:
                    return "Pai e Mãe";
                case FamilyCompositionRelationshipType.Sogro:
                    return "Sogro";
                case FamilyCompositionRelationshipType.Irmao:
                    return "Irmão";
                case FamilyCompositionRelationshipType.Genro:
                    return "Genro";
                case FamilyCompositionRelationshipType.Outro:
                    return "Outro";
                case FamilyCompositionRelationshipType.NaoParente:
                    return "Não Parente";
                default:
                    return string.Empty;
            }
        }

        public static string Convert(EconomicSituationIncomeType economicSituation)
        {
            switch(economicSituation)
            {
                case EconomicSituationIncomeType.Registrado:
                    return "Registrado";
                case EconomicSituationIncomeType.BPC:
                    return "BPC";
                case EconomicSituationIncomeType.BPCIdoso:
                    return "BPC/Idoso";
                case EconomicSituationIncomeType.Aposentadoria:
                    return "Aposentadoria";
                case EconomicSituationIncomeType.SeguroDesemprego:
                    return "Seguro Desemprego";
                case EconomicSituationIncomeType.Pensao:
                    return "Pensão";
                case EconomicSituationIncomeType.Autonomo:
                    return "Autônomo";
                case EconomicSituationIncomeType.Proprietario:
                    return "Proprietário";
                case EconomicSituationIncomeType.Outro:
                    return "Outro";
                default:
                    return string.Empty;
            }
        }
    }
}
