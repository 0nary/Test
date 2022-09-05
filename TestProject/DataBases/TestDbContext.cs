using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DataBases
{
    public class TestDbContext
        :DbContext
    {
        private static DbContextOptionsBuilder<TestDbContext> _dbContextOptionsBuilder
        {
            get 
            {
                DbContextOptionsBuilder<TestDbContext> builder = new DbContextOptionsBuilder<TestDbContext>();
                builder.UseSqlServer("Server=127.0.0.1,1433;Database=Neuroglia.Sowl.PosManager;User Id=SA;Password=yourStrong(!)Password;MultipleActiveResultSets=true");
                return builder;
            }
        }

        public TestDbContext()
            :base(_dbContextOptionsBuilder.Options)
        {
           
        }
    }
}
