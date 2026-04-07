namespace TrabalhoDevOpsInfnet.Application.UseCases.Calculo.Common
{
    public class CalcularJurosCompostosOutput
    {
        public decimal Resultado { get; private set; }

        public CalcularJurosCompostosOutput(decimal resultado)
        {
            Resultado = resultado;
        }
    }
}
