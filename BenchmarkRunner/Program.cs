using BenchmarkDotNet.Running;

var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<BenchmarkWithSamePayload>();