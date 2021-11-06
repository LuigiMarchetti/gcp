﻿using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.Domain.Entities;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    //verificar erro InscricoesModel
    [Route("inscricoes")]
    public sealed class InscricoesController : Controller<InscricoesModel, InscricoesEntity>
    {
        public InscricoesController(IInscricoesService inscricoesService) : base(inscricoesService)
        {
        }
    }
}