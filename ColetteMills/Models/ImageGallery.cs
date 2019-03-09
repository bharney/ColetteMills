using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ColetteMills.Models
{
    public class ImageGallery
    {
        public ImageGallery()
        {
            ImageList = new List<string>();
        }
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<string> ImageList { get; set; }
    }
}


/*

using ImageGalleryInMvc5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ImageGalleryInMvc5.Models
{
    public class DbConnectionContext : DbContext
    {
        public DbConnectionContext():base("name=dbContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbConnectionContext>());
        }
        public DbSet<ImageGallery> ImageGallery { get; set; }
    }
}

*/