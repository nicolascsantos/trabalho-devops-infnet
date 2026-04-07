using MediatR;
using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.Common;

namespace TrabalhoDevOpsInfnet.Application.UseCases.Calculo.CalcularJurosCompostos
{
    public interface ICalcularJurosCompostos : IRequestHandler<CalcularJurosCompostosInput, CalcularJurosCompostosOutput>
    {
    }
}
