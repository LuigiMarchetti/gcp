﻿using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Repositories.Base;

namespace Senac.GCP.Domain.Repositories
{
    public interface ITipoSolicitacaoIsencaoInscricaoRepository : IRepository<TipoSolicitacaoIsencaoInscricaoEntity>
    {
        decimal ObterPercentualDeIsencaoPorInscricao(long idInscricao);
    }
}