namespace TrabalhoDevOpsInfnet.Domain.Entities
{
    public class ResultadoMensal
    {
        public ResultadoMensal(
            int mes,
            decimal juros,
            decimal totalInvestido,
            decimal totalJuros,
            decimal totalAcumulado
        )
        {
            Mes = mes;
            Juros = juros;
            TotalInvestido = totalInvestido;
            TotalJuros = totalJuros;
            TotalAcumulado = totalAcumulado;
        }

        public int Mes { get; private set; }

        public decimal Juros { get; private set; }

        public decimal TotalInvestido { get; private set; }

        public decimal TotalJuros { get; private set; }

        public decimal TotalAcumulado { get; private set; }
    }
}
