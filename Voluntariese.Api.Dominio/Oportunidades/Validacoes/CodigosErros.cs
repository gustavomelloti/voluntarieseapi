namespace Voluntariese.Api.Dominio.Oportunidades.Validacoes
{
    public static class CodigosErros
    {
        public const string OportunidadeDeveEstarAtiva = "OPORTUNIDADE_DEVE_ESTAR_ATIVA";
        public const string OportunidadeDeveTerVagasPositivas = "OPORTUNIDADE_DEVE_TER_QUANTIDADE_POSITIVA";
        public const string OportunidadeDeveEstarVinculadaComInstituicao = "OPORTUNIDADE_DEVE_ESTAR_VINCULADA_COM_INSTITUICAO";
        public const string CandidaturaNaoEncontrada = "CANDIDATURA_NAO_ENCONTRADA";
        public const string VoluntarioNaoSeCandidatou = "VOLUNTARIO_NAO_SE_CANDIDATOU";
        public const string CandidaturaJaAtualizada = "CANDIDATURA_JA_ATUALIZADA";
    }
}
