using Grpc.Core;
using GrpcProtos;

namespace GrpcService.Services
{
    public class Service : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override Task<GetHelloReply> GetHello(EmptyRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetHelloReply { Response = "1" });
        }

        public override Task<SimpleReply> PostComplex(ComplexRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SimpleReply() { Message = "ok" });
        }
    }
}