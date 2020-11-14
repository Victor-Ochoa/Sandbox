using Grpc.Core;
using Sandbox.Protos;
using System.Threading.Tasks;

namespace Sandbox.Api.Services
{
    public class OlaMundoService : OlaMundo.OlaMundoBase
    {
        public override Task<OlaReply> Saudacao(OlaRequest request, ServerCallContext context)
        {
            return Task.FromResult(new OlaReply()
            { Message = $"Bem vindo {request.Name}! Ola Mundo Grpc" });
        }
    }
}
