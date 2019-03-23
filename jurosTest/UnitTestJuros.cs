using System.Collections.Generic;
using System.Linq;
using juros.Controllers;
using StoreApp.Models;
using Xunit;

namespace jurosTest
{
    public class UnitTest1
    {
        //BLOCO1 - testes da funcionaldiade de calculo de taxa, esperado 8 sucessos
        [Fact]
        public void TestCalculadora()
        {
            //teste 1

            // Arrange
            var testProducts = GetTestAmostra();
            var controller = new CalculaJurosController();

            // Act
            for (int i = 0; i < testProducts.Count(); i++)
            {
                testProducts[i].ValorRetorno = controller.Get(testProducts[i].Valor, testProducts[i].Meses);
            }

            // Assert
            Assert.Collection(testProducts, 
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); },
                unit => { Assert.Equal(unit.ValorEsperado, unit.ValorRetorno); }
            );
        }

        [Fact]
        public void TestCalculadoraFixo()
        {
            // Arrange
            var controller = new CalculaJurosController();

            // Act
            var result = controller.Get(100,5);

            // Assert
            Assert.Equal("105.1", result.ToString());

        }

        // BLOCO2 - teste da exception de valor
        [Fact]
        public void TestExceptionSizeCalc()
        {
            // Arrange
            var controller = new CalculaJurosController();

            // Act
            var result = controller.Get(1000000000000000, 60000);

            // Assert
            Assert.Equal("-999999991", result.ToString());

            // Act
            //ponto diferente de possivel estouro de tamanho de campo
            result = controller.Get(1000000000000000, 6000);

            // Assert
            Assert.Equal("-999999990", result.ToString());
        }

        // BLOCO3 - teste da funcionalidade de link, esperado 1 sucesso
        [Fact]
        public void TestLinkGit()
        {
            // Arrange
            var controller = new ShowMeTheCodeController();

            // Act
            var result = controller.Get();
            
            // Assert
            Assert.Equal("https://github.com/ViniziSuricate/juros", result.ToString());

        }

        private List<TesteJuros> GetTestAmostra() 
        {
            List<TesteJuros> testAmostra = new List<TesteJuros>
            {
                new TesteJuros { Valor = 0M, Meses = 27, ValorEsperado = 0M, ValorRetorno = 0M}, //testes de consistencia
                new TesteJuros { Valor = -1000.00M, Meses = 2, ValorEsperado = -999999997, ValorRetorno = 0M}, //testes de consistencia
                new TesteJuros { Valor = 1000.00M, Meses = -2, ValorEsperado = -999999998, ValorRetorno = 0M}, //testes de consistencia
                new TesteJuros { Valor = 100.00M, Meses = 5, ValorEsperado = 105.1M, ValorRetorno = 0M},
                new TesteJuros { Valor = 800000.00M, Meses = 480, ValorEsperado = 94918180.08M, ValorRetorno = 0M},
                new TesteJuros { Valor = 9762.32M, Meses = 16, ValorEsperado = 11447.08M, ValorRetorno = 0M}, //teste de truncamento
                new TesteJuros { Valor = 1000.00M, Meses = 42, ValorEsperado = 1518.78M, ValorRetorno = 0M}, //teste de truncamento
                new TesteJuros { Valor = 5603.21M, Meses = 0, ValorEsperado = 5603.21M, ValorRetorno = 0M},
            };

            return testAmostra;
        }
    }
}

