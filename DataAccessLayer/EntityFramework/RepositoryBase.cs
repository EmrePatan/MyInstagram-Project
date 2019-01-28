using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext db;
        private static object _lockSyn = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (db == null)
            {
                lock (_lockSyn)
                {
                    if (db == null)
                    {
                        db = new DatabaseContext();
                    }
                }
            }
        }
    }
}
