﻿using Senac.GCP.API.Models.Base;

namespace Senac.GCP.API.Models
{
    public sealed class DocumentosSolicitacaoIsencaoInscricaoModel : Model
    {
        public long IdArquivo { get; set; }

        public long IdSolicitacaoIsencaoInscricao { get; set; }
    }
}