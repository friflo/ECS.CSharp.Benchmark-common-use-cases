using BenchmarkDotNet.Attributes;

namespace EntitiesDb;

public class CreateWorld_EntitiesDb : CreateWorld
{
    [Benchmark]
    public override void Run()
    {
        var db = new EntityDatabase(new(16384));
        db.Dispose();
    }
}
