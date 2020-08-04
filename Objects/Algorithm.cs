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
    public class AlgorithmContext : DbContext
    {
        public DbSet<Algorithm> Algorithms { get; set; }
    }
    public class Algorithm
    {
        public int AlgorithmId { get; set; }

        public string Name { get; set; } 
    }
}
