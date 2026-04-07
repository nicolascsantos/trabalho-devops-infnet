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
            var valorInicial = 1000m;
            var valorMensal = 2000m;
            var taxaJuros = 0.05m; // 5% ao mês
            var meses = 12;


            // Act
            var calculo = new Entidades.Calculo(
                valorInicial,
                valorMensal,
                taxaJuros,
                meses,
                Domain.Enum.TipoCalculoEnum.MENSAL,
                Domain.Enum.TipoPeriodoEnum.MENSAL
            );

            var resultadoCalculo = calculo.CalcularJurosCompostos();
            
            // Assert
            var valorEsperado = valorInicial * (decimal)Math.Pow((double)(1 + taxaJuros), meses);
            Assert.Equal(valorEsperado, resultadoCalculo);
        }
    }
}
