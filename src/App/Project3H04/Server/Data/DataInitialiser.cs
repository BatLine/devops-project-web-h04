using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3H04.Server.Data
{
    public class DataInitialiser
    {
        private readonly ApplicationDbcontext _dbContext;

        public DataInitialiser(ApplicationDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            //_dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database, see DBContext               
            }
        }
    }
}
