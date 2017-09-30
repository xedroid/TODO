using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace TODOList.Models
{
    public class CustomTask
    {
        #region Properties

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreationDate { get; set; }

        [NotMapped]
        public string ShortDescription
        {
            get
            {
                if(Description.Length > 60)
                {
                    return Description.Substring(0,60) + "...";
                }
                return Description;                
            }
        }

        #endregion 

        #region Management methods

        /// <summary>
        /// Add a new CustomTask.
        /// </summary>
        public void Save()
        {
            using (var context = new ManagerDbContext())
            {
                context.CustomTasks.Add(this);
                context.SaveChanges();
            }
        }

        public void Update()
        {
            using (var context = new ManagerDbContext())
            {
                context.Entry(this).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds a new CustomTask or modify an existing.
        /// </summary>
        public void SaveOrUpdate()
        {
            using (var context = new ManagerDbContext())
            {
                if (Id > 0)
                    context.Entry(this).State = EntityState.Modified;
                else
                    context.CustomTasks.Add(this);

                context.SaveChanges();
            }
        }

        public void SaveChanges()
        {
            using (var context = new ManagerDbContext())
            {
                context.SaveChanges();
            }
        }

        #endregion 

    }
}
