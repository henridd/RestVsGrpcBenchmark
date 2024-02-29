using BenchmarkDotNet.Attributes;

namespace BenchmarkRunner
{
    using gRpcSender = GrpcClient.Sender;
    using RestSender = RestClient.Sender;

    public abstract class BenchmarkBase
    {
        protected gRpcSender _gRpcSender;
        protected RestSender _restSender;

        [GlobalSetup]
        public void Setup()
        {
            _gRpcSender = new gRpcSender();
            _restSender = new RestSender();
        }
    }
}
