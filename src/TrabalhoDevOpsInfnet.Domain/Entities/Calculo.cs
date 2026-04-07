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


        public decimal CalcularJurosCompostos()
            => CalcularMontantePrincipal() + CalcularMontanteAportes();

        private decimal FatorJuros()
            => (decimal)Math.Pow((double)(1 + TaxaJuros), QuantidadePeriodo);

        private decimal CalcularMontantePrincipal()
            => ValorInicial * FatorJuros();

        private decimal CalcularMontanteAportes()
            => ValorMensal * ((FatorJuros() - 1) / TaxaJuros);


        private void Validar()
        {
            if (ValorInicial <= 0)
                throw new DomainValidationException($"{nameof(ValorInicial)} deve ser maior que zero.");

            if (ValorMensal <= 0)
                throw new DomainValidationException($"{nameof(ValorMensal)} deve ser maior que zero.");

            if (TaxaJuros <= 0)
                throw new DomainValidationException($"{nameof(TaxaJuros)} deve ser maior que zero.");

            if (QuantidadePeriodo <= 0)
                throw new DomainValidationException($"{nameof(QuantidadePeriodo)} deve ser maior que zero.");
        }
    }
}
