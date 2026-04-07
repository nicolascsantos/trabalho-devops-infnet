using MediatR;
using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.Common;
using TrabalhoDevOpsInfnet.Domain.Enum;

namespace TrabalhoDevOpsInfnet.Application.UseCases.Calculo.CalcularJurosCompostos
{
    public class CalcularJurosCompostosInput : IRequest<CalcularJurosCompostosOutput>
    {
        public decimal ValorInicial { get; private set; }

        public decimal ValorMensal { get; private set; }

        public decimal TaxaJuros { get; private set; }

        public int QuantidadePeriodo { get; private set; }

        public TipoCalculoEnum TipoCalculo { get; private set; }

        public TipoPeriodoEnum TipoPeriodo { get; private set; }
        public CalcularJurosCompostosInput(
            decimal valorInicial,
            decimal valorMensal,
            decimal taxaJuros,
            int quantidadePeriodo,
            TipoCalculoEnum tipoCalculo,
            TipoPeriodoEnum tipoPeriodo
        )
        {
            ValorInicial = valorInicial;
            ValorMensal = valorMensal;
            TaxaJuros = taxaJuros;
            QuantidadePeriodo = quantidadePeriodo;
            TipoCalculo = tipoCalculo;
            TipoPeriodo = tipoPeriodo;
        }
    }
}
