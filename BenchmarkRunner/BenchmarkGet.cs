// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkRunner;

public class BenchmarkGet : BenchmarkBase
{
    [Benchmark]
    public async Task<string> BenchmarkGrpc()
    {
        return await _gRpcSender.Get();
    }

    [Benchmark]
    public async Task<string> BenchmarkRest()
    {
        return await _restSender.Get();
    }
}
