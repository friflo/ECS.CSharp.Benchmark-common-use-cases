namespace Scellecs.Morpeh;

public readonly struct Access
{
    internal readonly Stash<Component1>   stash1;
    internal readonly Stash<Component2>   stash2;
    internal readonly Stash<Component3>   stash3;
    internal readonly Stash<Component4>   stash4;
    internal readonly Stash<Component5>   stash5;

    internal Access(World world) {
        stash1 = world.GetStash<Component1>();
        stash2 = world.GetStash<Component2>();
        stash3 = world.GetStash<Component3>();
        stash4 = world.GetStash<Component4>();
        stash5 = world.GetStash<Component5>();
    }

    internal void Dispose()
    {
        stash1.Dispose();
        stash2.Dispose();
        stash3.Dispose();
        stash4.Dispose();
        stash5.Dispose();
    }
}