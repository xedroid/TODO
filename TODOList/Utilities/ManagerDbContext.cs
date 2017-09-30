using System.Data.Entity;

namespace TODOList.Models
{
    public class ManagerDbContext :DbContext
    {
        public ManagerDbContext() :base("DefaultConnection"){}

        public DbSet<CustomTask> CustomTasks { get; set; }
        public DbSet<Settings> Settings { get; set; }
    }

}
