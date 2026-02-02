namespace EntitiesDb;

public static class BenchUtils
{
    public static Entity[] CreateEntities(this EntityDatabase db, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++)
        {
            entities[n] = db.Create();
        }
        return entities;
    }

    public static Entity[] CreateEntitiesWithComponents(this EntityDatabase db, int count)
    {
        var entities = new Entity[count];
        for (int n = 0; n < count; n++)
        {
            entities[n] = db.Create(new Component1(), new Component2(), new Component3(), new Component4(), new Component5());
        }
        return entities;
    }
}
