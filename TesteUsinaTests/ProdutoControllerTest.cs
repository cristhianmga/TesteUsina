using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUsina.Controllers;
using TesteUsinaNegocio.DTO;
using TesteUsinaNegocio.Interface;
using TesteUsinaNegocio.Services;
using Xunit;

namespace TesteUsinaTests
{
    public class ProdutoControllerTest
    {
        private readonly IClienteService _mockService;
        private readonly ClienteController _controller;
        public ProdutoControllerTest() 
        {
            _mockService = new Mock<IClienteService>().Object;
            _controller = new ClienteController(_mockService);
        }


        [Fact]
        public async void SalvarProdutoServico_Ok()
        {
            Moq.Mock<IClienteService> mock = new Moq.Mock<IClienteService>();
            mock.Setup(x => x.SalvarAsync(It.IsAny<ClienteDTO>())).Returns(It.IsAny<Task<ClienteDTO>>());
            ClienteDTO dTO = new ClienteDTO();
            var retorno = await _controller.Salvar(dTO);
            Xunit.Assert.IsType<OkObjectResult>(retorno);
            Xunit.Assert.NotNull(retorno);
        }

        //[Fact]
        //public async void AtualizarProdutoServico_Ok()
        //{
        //    Moq.Mock<IProdutosService> mock = new Moq.Mock<IProdutosService>();
        //    mock.Setup(x => x.SalvarAsync(It.IsAny<ProdutoDTO>())).Returns(It.IsAny<Task<ProdutoDTO>>());
        //    ProdutoDTO dTO = new ProdutoDTO();
        //    var retorno = await _controller.Salvar(dTO);
        //    Xunit.Assert.IsType<OkObjectResult>(retorno);
        //    Xunit.Assert.NotNull(retorno);
        //}

        //[Fact]
        //public async void SalvarProdutoServico_Ok()
        //{
        //    Moq.Mock<IProdutosService> mock = new Moq.Mock<IProdutosService>();
        //    mock.Setup(x => x.SalvarAsync(It.IsAny<ProdutoDTO>())).Returns(It.IsAny<Task<ProdutoDTO>>());
        //    ProdutoDTO dTO = new ProdutoDTO();
        //    var retorno = await _controller.Salvar(dTO);
        //    Xunit.Assert.IsType<OkObjectResult>(retorno);
        //    Xunit.Assert.NotNull(retorno);
        //}

        //[Fact]
        //public async void SalvarProdutoServico_Ok()
        //{
        //    Moq.Mock<IProdutosService> mock = new Moq.Mock<IProdutosService>();
        //    mock.Setup(x => x.SalvarAsync(It.IsAny<ProdutoDTO>())).Returns(It.IsAny<Task<ProdutoDTO>>());
        //    ProdutoDTO dTO = new ProdutoDTO();
        //    var retorno = await _controller.Salvar(dTO);
        //    Xunit.Assert.IsType<OkObjectResult>(retorno);
        //    Xunit.Assert.NotNull(retorno);
        //}

        //[Fact]
        //public async void SalvarProdutoServico_Ok()
        //{
        //    Moq.Mock<IProdutosService> mock = new Moq.Mock<IProdutosService>();
        //    mock.Setup(x => x.SalvarAsync(It.IsAny<ProdutoDTO>())).Returns(It.IsAny<Task<ProdutoDTO>>());
        //    ProdutoDTO dTO = new ProdutoDTO();
        //    var retorno = await _controller.Salvar(dTO);
        //    Xunit.Assert.IsType<OkObjectResult>(retorno);
        //    Xunit.Assert.NotNull(retorno);
        //}

        //[Fact]
        //public async void SalvarProdutoServico_BadRequest()
        //{
        //    Moq.Mock<IProdutosService> mock = new Moq.Mock<IProdutosService>();
        //    mock.Setup(x => x.SalvarAsync(It.IsAny<ProdutoDTO>())).Throws<Exception>();
        //    ProdutoDTO dTO = new ProdutoDTO();
        //    IActionResult retorno = await _controller.Salvar(dTO);
        //    Xunit.Assert.IsType<BadRequestObjectResult>(retorno);
        //}

    }
}
