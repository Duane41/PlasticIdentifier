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
    public class DataSet
    {
        public int Id { get; set; }

        public virtual List<Image> Images { get; set; }

        public virtual List<HardwareUsage> HardwareUsage { get; set; }

        public int? AlgorithmId { get; set; }

        public virtual Algorithm Algorithm { get; set; }

        public int NumImages { get; set; }

        public int NumImagesPlastic { get; set; }

        public int NumImagesNotPlastic { get; set; }

        public string Name { get; set; }

        public bool Trained { get; set; }
    }
}
