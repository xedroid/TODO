using System.Data.Entity;

namespace TODOList.Models
{
    public class Settings
    {
        #region Properties
    
        public int Id { get; set; }
        public string Email { get; set; }
        public int NumberDays { get; set; }

        #endregion 

        #region Management methods

        public void SaveOrUpdate()
        {
            using (var context = new ManagerDbContext())
            {
                if (Id > 0)
                    context.Entry(this).State = EntityState.Modified;
                else
                    context.Settings.Add(this);

                context.SaveChanges();
            }
        }

        #endregion 
    }

    public class SettingsManager
    {
        public Settings Get(int id)
        {
            using (var context = new ManagerDbContext())
            {
                return context.Settings.Find(id);
            }
        }
    }
}
