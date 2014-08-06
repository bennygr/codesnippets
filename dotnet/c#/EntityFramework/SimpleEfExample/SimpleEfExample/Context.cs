using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace SimpleEfExample
{
    public class Context : DbContext
    {
        public Context()
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<Context>(null);
        }

        public DbSet<Album> Albums { get; set; }

        /*public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<EventData> EventDataValues { get; set; }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }

    public class Album
    {
            public long AlbumId { get; set; }
            public string Title { get; set; }
            public long ArtistId { get; set; }
    }

    public class AlbumRepository
    {
        private Context ctx = new Context();
        public List<Album> GetAll()
        {
            var q = from album in ctx.Albums select album;
            return q.ToList();
        }
    }
}