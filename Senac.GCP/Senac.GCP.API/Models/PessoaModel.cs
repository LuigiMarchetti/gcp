﻿using Senac.GCP.API.Models.Base;
using Senac.GCP.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Senac.GCP.API.Models
{
    public sealed class PessoaModel : Model
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdArquivoFoto' não foi preenchido")]
        public long IdArquivoFoto { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdNaturalidade' não foi preenchido")]
        public long IdNaturalidade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdNacionalidade' não foi preenchido")]
        public long IdNacionalidade { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdClassificacaoDoenca' não foi preenchido")]
        public long IdClassificacaoDoenca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdCorRaca' não foi preenchido")]
        public long IdCorRaca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'IdMunicipio' não foi preenchido")]
        public long IdMunicipio { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Nome' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Nome' aceita no máximo 255 caracteres")]
        public string Nome { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'DataNascimento' não foi preenchido")]
        public DateTime DataNascimento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'CPF' não foi preenchido")]
        public string CPF { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'RG' não foi preenchido")]
        public string RG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'DataEmissaoRG' não foi preenchido")]
        public DateTime DataEmissaoRG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'OrgaoEmissorRG' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'OrgaoEmissorRG' aceita no máximo 255 caracteres")]
        public string OrgaoEmissorRG { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Genero' não foi preenchido")]
        [StringLength(maximumLength: 1, ErrorMessage = "O campo 'Genero' aceita no máximo 1 caracteres")]
        public char Genero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Email' não foi preenchido")]
        [StringLength(maximumLength: 255, ErrorMessage = "O campo 'Email' aceita no máximo 255 caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "O conteúdo informado para o campo 'Email' não representa um e-mail válido")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Telefone' não foi preenchido")]
        [StringLength(maximumLength: 11, ErrorMessage = "O campo 'Telefone' aceita no máximo 11 caracteres")]
        public string Telefone { get; set; }

        public bool PCD { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoRua' não foi preenchido")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoRua' aceita no máximo 150 caracteres")]
        public string EnderecoRua { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoNumero' não foi preenchido")]
        [StringLength(maximumLength: 20, ErrorMessage = "O campo 'EnderecoNumero' aceita no máximo 20 caracteres")]
        public string EnderecoNumero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoBairro' não foi preenchido")]
        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoBairro' aceita no máximo 150 caracteres")]
        public string EnderecoBairro { get; set; }

        [StringLength(maximumLength: 150, ErrorMessage = "O campo 'EnderecoComplemento' aceita no máximo 150 caracteres")]
        public string EnderecoComplemento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'EnderecoCEP' não foi preenchido")]
        [StringLength(maximumLength: 10, ErrorMessage = "O campo 'EnderecoCEP' aceita no máximo 10 caracteres")]
        public string EnderecoCEP { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo 'Ativo' não foi definido")]
        public bool Ativo { get; set; }

        public string ChaveAcesso { get; set; }

        public override void AdditionalValidations()
        {
            if (!ValidadorCPF.Validar(CPF, out string cpf))
            {
                throw new Exception("O CPF informado não é válido");
            }

            CPF = cpf;
            Email = Email.Trim().ToUpper();
            Nome = Nome.Trim();
        }
    }
}