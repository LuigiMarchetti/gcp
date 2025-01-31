﻿using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso-fases-salas")]
    public sealed class ConcursoFasesLocaisSalaController : Controller<ConcursoFasesLocaisSalaModel, ConcursoFasesLocaisSalaEntity>
    {
        public ConcursoFasesLocaisSalaController(IConcursoFasesLocaisSalaService concursoFasesLocaisSalaService) : base(concursoFasesLocaisSalaService)
        {
        }
    }
}