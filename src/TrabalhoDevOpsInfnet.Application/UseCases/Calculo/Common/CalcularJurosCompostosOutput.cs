namespace TrabalhoDevOpsInfnet.Application.UseCases.Calculo.Common
{
    public class CalcularJurosCompostosOutput
    {
        public CalcularJurosCompostosOutput(IReadOnlyList<ResultadoMensalOutput> resultados)
        {
            Resultados = resultados;

            var ultimo = resultados[^1];
            TotalInvestidoFinal = ultimo.TotalInvestido;
            TotalJurosFinal = ultimo.TotalJuros;
            TotalAcumuladoFinal = ultimo.TotalAcumulado;
        }

        public IReadOnlyList<ResultadoMensalOutput> Resultados { get; private set; }

        public decimal TotalInvestidoFinal { get; private set; }

        public decimal TotalJurosFinal { get; private set; }

        public decimal TotalAcumuladoFinal { get; private set; }

        public string Teste { get; set; }
    }
}
