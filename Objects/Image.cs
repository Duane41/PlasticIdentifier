using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlasticIdentifier.Objects
{
    public class ImageContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
    }

    public class Image
    {
        public int ImageId { get; set; }

        public double ImageSize { get; set; }

        public string FileLocation { get; set; }

        public bool? IsPlastic { get; set; }
        //Foreign Key to dataset
        public int Id { get; set; }

        public virtual DataSet DateSet { get; set; }
    }
}
