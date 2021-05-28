using System.Threading.Tasks;

namespace TT.Data
{
    public interface ISeed
    {
        Task MigrateAsync();
        Task SeedAsync();
    }
}
