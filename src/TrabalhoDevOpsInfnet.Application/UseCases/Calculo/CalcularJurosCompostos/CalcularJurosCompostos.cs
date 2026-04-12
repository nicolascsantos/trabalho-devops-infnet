using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.Common;
using Entidade = TrabalhoDevOpsInfnet.Domain.Entities;

namespace TrabalhoDevOpsInfnet.Application.UseCases.Calculo.CalcularJurosCompostos
{
    public class CalcularJurosCompostos : ICalcularJurosCompostos
    {
        public CalcularJurosCompostos() { }

        public Task<CalcularJurosCompostosOutput> Handle(CalcularJurosCompostosInput request, CancellationToken cancellationToken)
        {
            var calculo = new Entidade.Calculo(
                request.ValorInicial,
                request.ValorMensal,
                request.TaxaJuros,
                request.QuantidadePeriodo,
                request.TipoCalculo,
                request.TipoPeriodo
            );

            var resultados = calculo.CalcularJurosCompostos()
                .Select(r => new ResultadoMensalOutput(
                    r.Mes,
                    r.Juros,
                    r.TotalInvestido,
                    r.TotalJuros,
                    r.TotalAcumulado
                ))
                .ToList();

            return Task.FromResult(new CalcularJurosCompostosOutput(resultados));
        }
    }
}
