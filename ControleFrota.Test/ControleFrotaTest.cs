using ControleFrota.BLL.Data;
using ControleFrota.BLL.Services;
using ControleFrota.MDL.Models;
using ControleFrota.MDL.Enumeradores;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ControleFrota.Test
{
    public class ControleFrotaTest
    {
        VeiculosService _service;
        ControleFrotaContext _context;
        public ControleFrotaTest()
        {
            _context = new ControleFrotaContext();
            _service = new VeiculosService(_context);
        }

        [Fact]
        public void Get_DeveRetornarUmaLista()
        {
            // Act
            var okResult = _service.GetAll();
            // Assert
            var items = Assert.IsType<List<Veiculo>>(okResult);
            Assert.NotEmpty(items);
        }

        [Fact]
        public void NumeroPassageiro_ErrorQuantidade()
        {                       
            var ex = Assert.Throws<InvalidOperationException>(() => new Veiculo("123458C", Tipo.Caminhao, 35, "Azul"));

            Assert.Equal("O Número de passageiros de um caminhão deve ser 2", ex.Message);
        }


        [Fact]
        public void Create_PrimeiraExecucaoGeraTrue()
        {
            var obj = new Veiculo("123458C", Tipo.Caminhao, 2, "Azul");
            // Act
            var okResult = _service.Create(obj);
            // Assert
            Assert.True(okResult);
        }


        [Fact]
        public void Create_ErrorChassiJaExiste()
        {
            var obj = new Veiculo("123456C", Tipo.Caminhao, 2 , "Azul");

            var ex = Assert.Throws<InvalidOperationException>(() => _service.Create(obj));

            Assert.Equal("Já existe um veículo cadastrado com  esse Chassi.", ex.Message);
        }


        [Fact]
        public void Get_DeveRetornarUmVeiculo()
        {
            var chassi = "123456C";
            // Act
            var okResult = _service.FindByChassi(chassi);
            // Assert
            Assert.IsType<Veiculo>(okResult);
        }

        
    }
}
