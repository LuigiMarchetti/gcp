﻿using Microsoft.EntityFrameworkCore;
using Senac.GCP.Domain.Entities;

namespace Senac.GCP.Infraestructure.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<UsuarioEntity> Usuario { get; set; }

        public DbSet<EstadoEntity> Estado { get; set; }

        public DbSet<MunicipioEntity> Municipio { get; set; }

        public DbSet<InstituicaoEntity> Instituicao { get; set; }

        public DbSet<ArquivoEntity> Arquivo { get; set; }

        public DbSet<ClassificacaoDoencaEntity> ClassificacaoDoenca { get; set; }

        public DbSet<NacionalidadeEntity> Nacionalidade { get; set; }

        public DbSet<ConcursoEntity> concurso { get; set; }

        public DbSet<ConcursoEditaisEntity> ConcursoEditais { get; set; }
       
        public DbSet<ConcursoEditaisEntity> ConcursoTipoCotas { get; set; }

        public DbSet<PessoaEntity> Pessoa { get; set; }

        public DbSet<CorRacaEntity> CorRaca { get; set; }

        public DbSet<TipoSolicitacaoIsencaoInscricaoEntity> TipoSolicitacaoIsencaoInscricao { get; set; }
    }
}