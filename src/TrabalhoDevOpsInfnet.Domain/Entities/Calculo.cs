using TrabalhoDevOpsInfnet.Domain.Enum;
using TrabalhoDevOpsInfnet.Domain.Exceptions;
using TrabalhoDevOpsInfnet.Domain.SeedWork;

namespace TrabalhoDevOpsInfnet.Domain.Entities
{
    public class Calculo : Entity
    {
        public Calculo(
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
            Validar();
        }

        public decimal ValorInicial { get; private set; }

        public decimal ValorMensal { get; private set; }

        public decimal TaxaJuros { get; private set; }

        public int QuantidadePeriodo { get; private set; }

        public TipoCalculoEnum TipoCalculo { get; private set; }

        public TipoPeriodoEnum TipoPeriodo { get; private set; }


        public IReadOnlyList<ResultadoMensal> CalcularJurosCompostos()
        {
            var resultados = new List<ResultadoMensal>(QuantidadePeriodo);
            var saldo = ValorInicial;
            var totalInvestido = ValorInicial;
            var totalJuros = 0m;

            for (var mes = 1; mes <= QuantidadePeriodo; mes++)
            {
                var jurosDoMes = saldo * TaxaJuros;
                saldo += jurosDoMes + ValorMensal;
                totalInvestido += ValorMensal;
                totalJuros += jurosDoMes;

                resultados.Add(new ResultadoMensal(
                    mes,
                    Math.Round(jurosDoMes, 2),
                    Math.Round(totalInvestido, 2),
                    Math.Round(totalJuros, 2),
                    Math.Round(saldo, 2)
                ));
            }

            return resultados;
        }


        private void Validar()
        {
            if (ValorInicial <= 0)
                throw new EntityValidationException($"{nameof(ValorInicial)} deve ser maior que zero.");

            if (ValorMensal <= 0)
                throw new EntityValidationException($"{nameof(ValorMensal)} deve ser maior que zero.");

            if (TaxaJuros <= 0)
                throw new EntityValidationException($"{nameof(TaxaJuros)} deve ser maior que zero.");

            if (QuantidadePeriodo <= 0)
                throw new EntityValidationException($"{nameof(QuantidadePeriodo)} deve ser maior que zero.");
        }
    }
}
