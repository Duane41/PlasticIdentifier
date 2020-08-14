using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticIdentifier.Objects
{
    class PlasticDBContext : DbContext
    {
        public DbSet<Image> Images { get; set; }

        public DbSet<HardwareUsage> HardwareUsages { get; set; }

        public DbSet<DataSet> DataSets { get; set; }

        public DbSet<Algorithm> Algorithms { get; set; }
    }
}
