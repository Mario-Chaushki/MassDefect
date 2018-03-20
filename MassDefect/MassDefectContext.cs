using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MassDefect.Models;

namespace MassDefect
{
    using System;
    using System.Data;
    using System.Linq;

    public class MassDefectContext : DbContext
    {
        // Your context has been configured to use a 'MassDefectContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MassDefect.Data.MassDefectContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MassDefectContext' 
        // connection string in the application configuration file.
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
            Database.SetInitializer( new CreateDatabaseIfNotExists<MassDefectContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Person> Persons { get; set; }

        public virtual IDbSet<Anomaly> Anomalies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            modelBuilder.Entity<Star>()
                .HasRequired(ss => ss.SolarSystem)
                .WithMany(s => s.Stars)
                .HasForeignKey(s => s.SolarSystemId);

            modelBuilder.Entity<Planet>()
                .HasRequired(p => p.Sun)
                .WithMany(s => s.Planets)
                .HasForeignKey(s => s.SunId);
            
            modelBuilder.Entity<Anomaly>()
                .HasMany(anomaly => anomaly.Victims)
                .WithMany(person => person.Anomalies)
                .Map(entity =>
                {
                    entity.ToTable("AnomalyVictims");
                    entity.MapLeftKey("AnomalyId");
                    entity.MapRightKey("PersonId");
                });

            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.TeleportPlanet)
                .WithMany(op => op.TeleportAnomalies)
                .HasForeignKey(a => a.TeleportPlanetId);

            modelBuilder.Entity<Anomaly>()
                .HasRequired(a => a.OriginPlanet)
                .WithMany(op => op.OriginAnomalies)
                .HasForeignKey(a => a.OriginPlanetId);
        }
    }
}