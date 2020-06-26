using EF6OnCore.Migrations;
using System.Data.Entity;

namespace EF6OnCore
{
    internal class DataContextInitializer : MigrateDatabaseToLatestVersion<DataContext, Configuration> { }
}