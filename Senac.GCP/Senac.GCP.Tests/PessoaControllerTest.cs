﻿using Moq;
using Senac.GCP.API.Controllers;
using Senac.GCP.API.Models;
using Senac.GCP.Domain.Entities;
using Senac.GCP.Domain.Exceptions;
using Senac.GCP.Domain.Repositories;
using Senac.GCP.Domain.Services.Implementations;
using Xunit;

namespace Senac.GCP.Tests
{
    public sealed class PessoaControllerTest
    {
        [Fact]
        public void Post_PessoaBrasileira_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cristina Priester",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<SendEmailException>(() => pessoaController.Post(model));
        }

        [Fact]
        public void Post_PessoaSemNome_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }

        [Fact]
        public void Post_PessoaSemCPF_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                Email = "cristinapriester2003@gmail.com",
                Nome = "Bu",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemRG_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemOrgaoEmissorRG_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemEmail_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemTelefone_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemEnderecoRua_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemEnderecoBairro_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Bu",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemEnderecoCEP_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoRua = "Rua dos Bobos",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoBairro = "Pedrinha",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }


        [Fact]
        public void Post_PessoaSemEnderecoNumero_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cris",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }

        [Fact]
        public void Post_PessoaBrasileiraSemNaturalidade_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdMunicipioNaturalidade = null,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cristina Priester",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "0",
                EnderecoComplemento = "casa muito engraçada",
                EnderecoRua = "Rua dos Bobos",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Post(model));
        }

        [Fact]
        public void Put_ComPessoaBrasileira_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                Id = 1,
                IdArquivoFoto = 1,
                IdMunicipioNaturalidade = 1,
                IdNacionalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cristina Priester",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            pessoaController.Put(model);
        }


        [Fact]
        public void Put_ComPessoaBrasileiraSemNaturalidade_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());
            mockNacionalidadeRepository.Setup(x => x.GetById(1)).Returns(new NacionalidadeEntity { Nome = "Brasileiro(a)" });

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            var model = new PessoaModel
            {
                Id = 1,
                IdArquivoFoto = 1,
                IdNacionalidade = 1,
                IdCorRaca = 1,
                IdMunicipioEndereco = 1,
                CPF = "11280819979",
                Email = "cristinapriester2003@gmail.com",
                Nome = "Cristina Priester",
                DataNascimento = new System.DateTime(2003, 08, 04),
                RG = "360362928",
                DataEmissaoRG = new System.DateTime(2008, 08, 04),
                OrgaoEmissorRG = "Secretaria de Sergurança Pública",
                Genero = 'F',
                Telefone = "4712093123",
                PCD = false,
                EnderecoNumero = "123",
                EnderecoComplemento = "casa",
                EnderecoRua = "Pedrinho",
                EnderecoBairro = "Pedrinha",
                EnderecoCEP = "10101010",
            };

            Assert.Throws<BusinessException>(() => pessoaController.Put(model));
        }

        [Fact]
        public void DeleteById_Test()
        {
            var mockPessoaRepository = new Mock<IPessoaRepository>();
            var mockNacionalidadeRepository = new Mock<INacionalidadeRepository>();

            mockPessoaRepository.Setup(x => x.GetById(1)).Returns(new PessoaEntity());

            var pessoaService = new PessoaService
            (
                mockPessoaRepository.Object,
                UtilsTest.GetHttpContextAccessor(),
                UtilsTest.GetEmailService(),
                mockNacionalidadeRepository.Object
            );
            var pessoaController = new PessoaController(pessoaService);

            pessoaController.DeleteById(1);
        }

    }
}
