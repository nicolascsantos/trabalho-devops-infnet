using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.CalcularJurosCompostos;
using TrabalhoDevOpsInfnet.Domain.Exceptions;
using Entidades = TrabalhoDevOpsInfnet.Domain.Entities;

namespace TrabalhoDevOpsInfnet.UnitTests.Calculo
{
    public class CalculoTests
    {
        [Fact(DisplayName = nameof(CalcularJurosCompostos))]
        [Trait("Calculo", "Calcular Juros Compostos")]
        public void CalcularJurosCompostos()
        {
            // Arrange
            var valorInicial = 2500m;
            var valorMensal = 100m;
            var taxaJuros = 0.02m;
            var quantidadePeriodo = 2;

            // Act
            var calculo = new Entidades.Calculo(
                valorInicial,
                valorMensal,
                taxaJuros,
                quantidadePeriodo,
                Domain.Enum.TipoCalculoEnum.MENSAL,
                Domain.Enum.TipoPeriodoEnum.MENSAL
            );

            var resultado = calculo.CalcularJurosCompostos();

            // Assert
            Assert.Equal(quantidadePeriodo, resultado.Count);

            var mes1 = resultado[0];
            Assert.Equal(1, mes1.Mes);
            Assert.Equal(50.00m, mes1.Juros);
            Assert.Equal(2600.00m, mes1.TotalInvestido);
            Assert.Equal(50.00m, mes1.TotalJuros);
            Assert.Equal(2650.00m, mes1.TotalAcumulado);

            var mes2 = resultado[1];
            Assert.Equal(2, mes2.Mes);
            Assert.Equal(53.00m, mes2.Juros);
            Assert.Equal(2700.00m, mes2.TotalInvestido);
            Assert.Equal(103.00m, mes2.TotalJuros);
            Assert.Equal(2803.00m, mes2.TotalAcumulado);

            // Última linha bate com a fórmula fechada antiga (garantia de compatibilidade).
            var fatorJuros = (decimal)Math.Pow((double)(1 + taxaJuros), quantidadePeriodo);
            var montantePrincipal = valorInicial * fatorJuros;
            var montanteAportes = valorMensal * ((fatorJuros - 1) / taxaJuros);
            var totalEsperado = Math.Round(montantePrincipal + montanteAportes, 2);
            Assert.Equal(totalEsperado, resultado[^1].TotalAcumulado);
        }

        [Fact(DisplayName = nameof(CalcularJurosCompostosOutputExpoeTotaisFinais))]
        [Trait("Calculo", "Calcular Juros Compostos")]
        public async Task CalcularJurosCompostosOutputExpoeTotaisFinais()
        {
            // Arrange
            var input = new CalcularJurosCompostosInput(
                valorInicial: 2500m,
                valorMensal: 100m,
                taxaJuros: 0.02m,
                quantidadePeriodo: 2,
                tipoCalculo: Domain.Enum.TipoCalculoEnum.MENSAL,
                tipoPeriodo: Domain.Enum.TipoPeriodoEnum.MENSAL
            );
            var handler = new CalcularJurosCompostos();

            // Act
            var output = await handler.Handle(input, CancellationToken.None);

            // Assert
            var ultimo = output.Resultados[^1];
            Assert.Equal(ultimo.TotalInvestido, output.TotalInvestidoFinal);
            Assert.Equal(ultimo.TotalJuros, output.TotalJurosFinal);
            Assert.Equal(ultimo.TotalAcumulado, output.TotalAcumuladoFinal);
            Assert.Equal(2700.00m, output.TotalInvestidoFinal);
            Assert.Equal(103.00m, output.TotalJurosFinal);
            Assert.Equal(2803.00m, output.TotalAcumuladoFinal);
        }

        [Theory(DisplayName = nameof(CalcularJurosCompostosRetornaUmaLinhaPorMes))]
        [Trait("Calculo", "Calcular Juros Compostos")]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(12)]
        public void CalcularJurosCompostosRetornaUmaLinhaPorMes(int quantidadePeriodo)
        {
            // Arrange
            var calculo = new Entidades.Calculo(
                valorInicial: 1000m,
                valorMensal: 200m,
                taxaJuros: 0.01m,
                quantidadePeriodo: quantidadePeriodo,
                tipoCalculo: Domain.Enum.TipoCalculoEnum.MENSAL,
                tipoPeriodo: Domain.Enum.TipoPeriodoEnum.MENSAL
            );

            // Act
            var resultado = calculo.CalcularJurosCompostos();

            // Assert
            Assert.Equal(quantidadePeriodo, resultado.Count);
            for (var i = 0; i < resultado.Count; i++)
                Assert.Equal(i + 1, resultado[i].Mes);
        }

        [Fact(DisplayName = nameof(ExcecaoQuandoQuantidadePeriodoEMenorQueZero))]
        [Trait("Calculo", "Calcular Juros Compostos")]
        public void ExcecaoQuandoQuantidadePeriodoEMenorQueZero()
        {
            // Arrange
            var valorInicial = 1000m;
            var valorMensal = 2000m;
            var taxaJuros = 15m; // 5% ao mês
            var quantidadePeriodo = -1;


            // Act

            // Assert
            var exception = Assert.Throws<EntityValidationException>(
                () => new Entidades.Calculo(
                    valorInicial,
                    valorMensal,
                    taxaJuros,
                    quantidadePeriodo,
                    Domain.Enum.TipoCalculoEnum.MENSAL,
                    Domain.Enum.TipoPeriodoEnum.MENSAL
            ));

            Assert.Equal("QuantidadePeriodo deve ser maior que zero.", exception.Message);
        }

        [Fact(DisplayName = nameof(ExcecaoQuandoTaxaDeJurosEMenorQueZero))]
        [Trait("Calculo", "Calcular Juros Compostos")]
        public void ExcecaoQuandoTaxaDeJurosEMenorQueZero()
        {
            // Arrange
            var valorInicial = 1000m;
            var valorMensal = 2000m;
            var taxaJuros = -1m; // 5% ao mês
            var meses = 12;


            // Act

            // Assert
            var exception = Assert.Throws<EntityValidationException>(
                () => new Entidades.Calculo(
                    valorInicial,
                    valorMensal,
                    taxaJuros,
                    meses,
                    Domain.Enum.TipoCalculoEnum.MENSAL,
                    Domain.Enum.TipoPeriodoEnum.MENSAL
            ));

            Assert.Equal("TaxaJuros deve ser maior que zero.", exception.Message);
        }
    }
}
