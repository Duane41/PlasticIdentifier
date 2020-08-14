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
    public class HardwareUsage
    {
        public int Id { get; set; }

        public string SI_Unit { get; set; }

        public int DataSetId { get; set; }

        public virtual DataSet DataSet { get; set; }
    }
}
