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
            var taxaJuros = 0.02m; // 1% ao mês
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

            var resultadoCalculo = calculo.CalcularJurosCompostos();

            // Assert
            var fatorJuros = (decimal)Math.Pow((double)(1 + taxaJuros), quantidadePeriodo);
            var montantePrincipal = valorInicial * fatorJuros;
            var montanteAportes = valorMensal * ((fatorJuros - 1) / taxaJuros);
            var valorEsperado = montantePrincipal + montanteAportes;

            Assert.Equal(valorEsperado, resultadoCalculo);
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
