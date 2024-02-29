// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkRunner;

public class BenchmarkWithSamePayload : BenchmarkBase
{
    [Benchmark]
    public async Task<string> BenchmarkGrpc()
    {
        return await _gRpcSender.PostDefault();
    }

    [Benchmark]
    public async Task<string> BenchmarkRest()
    {
        return await _restSender.PostDefault();
    }
}
