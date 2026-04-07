using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrabalhoDevOpsInfnet.API.APIModels.Response;
using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.CalcularJurosCompostos;
using TrabalhoDevOpsInfnet.Application.UseCases.Calculo.Common;

namespace TrabalhoDevOpsInfnet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculoController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost("calcular-juros-compostos")]
        public async Task<IActionResult> CalcularJurosCompostos([FromBody] CalcularJurosCompostosInput input, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(input, cancellationToken);
            return Ok(new APIResponse<CalcularJurosCompostosOutput>(output));
        }
    }
}
