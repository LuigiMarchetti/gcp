﻿using Microsoft.AspNetCore.Mvc;
using Senac.GCP.API.Controllers.Base;
using Senac.GCP.API.Models;
using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Services.Interfaces;
using Senac.GCP.Domain.Utils;
using System;

namespace Senac.GCP.API.Controllers
{
    [Route("usuario")]
    public sealed class UsuarioController : Controller<UsuarioModel, UsuarioEntity>
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService) : base (usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        public override long Post([FromBody] UsuarioModel model)
        {
            (model as Model).Validate();
            usuarioService.ValidarDuplicidadeEmailUsuario(model.Email);
            usuarioService.ValidarDuplicidadeCPFUsuario(model.CPF);
            string senhaAutomatica = Guid.NewGuid().ToString().Replace("-", string.Empty);
            model.Senha = senhaAutomatica.Encrypt();
            model.Ativo = true;
            model.DataCadastramento = DateTime.Now;
            long id = base.Post(model);
            usuarioService.EnviarEmailUsuarioParaConfirmacaoDeCadasatro(id, model.Nome, model.Email, senhaAutomatica);
            return id;
        }

        public override void Put([FromBody] UsuarioModel model)
        {
            (model as Model).Validate(true);
            usuarioService.ValidarDuplicidadeEmailUsuario(model.Email, model.Id.Value);
            usuarioService.ValidarDuplicidadeCPFUsuario(model.CPF, model.Id.Value);
            var usuario = GetById(model.Id.Value);
            model.Senha = usuario.Senha;
            model.DataCadastramento = usuario.DataCadastramento;
            base.Put(model);
        }

        [HttpPut]
        [Route("alterar-senha/{idUsuario:long}/{senhaAtual}/{novaSenha}")]
        public void AlterarSenha(long idUsuario, string senhaAtual, string novaSenha)
        {
            var usuario = usuarioService.GetRepository().GetById(idUsuario);
            if (usuario.Senha != senhaAtual.Encrypt())
            {
                throw new Exception("A senha atual não corresponde com a senha informada.");
            }

            usuario.Senha = novaSenha.Encrypt();
            usuarioService.GetRepository().Update(usuario);
        }
    }
}
