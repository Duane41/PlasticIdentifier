using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace PlasticIdentifier.Objects
{
    public class HardwareUsageContext : DbContext
    {
        public DbSet<HardwareUsage> HardwareUsages { get; set; }
    }

    public class HardwareUsage
    {
        public int HardwareUsageId { get; set; }

        public string SI_Unit { get; set; }

        public int Id { get; set; }

        public virtual DataSet DataSet { get; set; }
    }
}
