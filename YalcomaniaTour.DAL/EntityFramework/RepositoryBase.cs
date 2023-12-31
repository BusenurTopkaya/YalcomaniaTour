﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalcomaniaTour.DAL.EntityFramework;

namespace YalcomaniaTour.DAL.EntityFramework
{
    public class RepositoryBase
    {
        private static DatabaseContext db;

        private static object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        public static DatabaseContext CreateContext()
        {
            if (db == null)
            {
                 lock (_lockSync)
                {
                   
                    if (db == null)
                    {
                        db = new DatabaseContext();
                    }
                }

            }

            return db;
        }
    }
}
