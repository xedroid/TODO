using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace TODOList.Models
{
    class CustomTasks
    {

        /// <summary>
        /// Get CustomTask object by id. If not found then return null.
        /// </summary>
        /// <param name="id"> Record id in database.</param>
        /// <returns></returns>
        public CustomTask GetTask(int id)
        {
            using (var context = new ManagerDbContext())
            {
                return context.CustomTasks.Find(id);
            }
        }

        public List<CustomTask> GetTasks(Dictionary<string, object> filters = null)
        {
            using (var context = new ManagerDbContext())
            {
                string queryString = @"SELECT VALUE ct FROM ManagerDbContext.CustomTasks as ct WHERE 1=1 ";

                if (filters != null)
                {
                    foreach (string key in filters.Keys)
                    {
                        if (key == "Date")
                        {
                            queryString += " AND ct.ExecutionDate = @" + key + " ";
                        }
                        else if (key == "NotificationDate")
                        {
                            queryString += " AND ct.ExecutionDate >= @" + key + " ";
                        }
                    }
                }
                var adapter = (IObjectContextAdapter)context;
                ObjectQuery<CustomTask> taskQuery = new ObjectQuery<CustomTask>(queryString, adapter.ObjectContext);

                if (filters != null)
                {
                    foreach (string key in filters.Keys)
                    {
                        if (key == "Date" || key == "NotificationDate")
                        {
                            taskQuery.Parameters.Add(new ObjectParameter(key, (DateTime)(filters[key])));
                        }
                    }
                }

                return taskQuery.ToList();
            }
        }

        public void Remove(int id)
        {
            CustomTask task = GetTask(id);
            if (task != null)
            {
                using (var context = new ManagerDbContext())
                {
                    context.CustomTasks.Attach(task);
                    context.CustomTasks.Remove(task);
                    context.SaveChanges();
                }
            }

        }
    }
}
