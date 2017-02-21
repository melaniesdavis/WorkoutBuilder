using System.Data.Entity;

namespace WorkoutBuilder.Data
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
    }
}