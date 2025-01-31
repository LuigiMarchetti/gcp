﻿using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;

namespace Senac.GCP.API.Controllers
{
    [Route("concurso-cargo")]
    public sealed class ConcursoCargoController : Controller<ConcursoCargoModel, ConcursoCargoEntity>
    {
        public ConcursoCargoController(IConcursoCargoService ConcursoCargoService) : base(ConcursoCargoService)
        {
        }
    }
}