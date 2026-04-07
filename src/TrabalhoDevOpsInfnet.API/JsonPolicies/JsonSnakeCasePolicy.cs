using System.Text.Json;
using TrabalhoDevOpsInfnet.API.Extensions;

namespace TrabalhoDevOpsInfnet.API.JsonPolicies
{
    public class JsonSnakeCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
            => name.ToSnakeCase();
    }
}
