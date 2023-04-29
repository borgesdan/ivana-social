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
        SuperiorComplero,
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
        Autonoo,
        Proprietario,
        Outro
    }
}
