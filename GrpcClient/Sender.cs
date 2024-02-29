using Grpc.Net.Client;
using GrpcProtos;

namespace GrpcClient
{
    public class Sender : IDisposable
    {
        private GrpcChannel _grpcChannel;
        private Greeter.GreeterClient _greeter;
        private HelloRequest _defaultRequest;

        public Sender()
        {
            _grpcChannel = GrpcChannel.ForAddress("http://localhost:5264");
            _greeter = new Greeter.GreeterClient(_grpcChannel);
            _defaultRequest = new HelloRequest() { Name = "default" };
        }

        public async Task<string> Post()
        {
            var request = new HelloRequest()
            {
                Name = "John Doe"
            };

            var reply = await _greeter.SayHelloAsync(request);

            return reply.Message;
        }

        public async Task<string> PostDefault()
        {
            var reply = await _greeter.SayHelloAsync(_defaultRequest);

            return reply.Message;
        }

        public async Task<string> Get()
        {
            return (await _greeter.GetHelloAsync(new EmptyRequest())).Response;
        }

        public void Dispose()
        {
            _grpcChannel.Dispose();
        }

        public async Task<string> PostComplex()
        {
            var request = new ComplexRequest()
            {
                IntField = 1,
                StringField = "hello",
                SubField = new ComplexRequestSubcontent()
                {
                    SubField = 2
                }
            };

            var reply = await _greeter.PostComplexAsync(request);

            return reply.Message;
        }
    }
}
