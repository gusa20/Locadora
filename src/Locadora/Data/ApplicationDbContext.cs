using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Locadora.Models;

namespace Locadora.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Midia>().Ignore(x => x.Idioma);
            builder.Entity<Midia>().Ignore(x => x.Legenda);
            builder.Entity<Midia>().Property(x => x.TwoLetterISOLanguageName).HasColumnName("Idioma");
            builder.Entity<Midia>().Property(x => x.TwoLetterISOSubtitleName).HasColumnName("Legenda");

            builder.Entity<Filme>().Ignore(x => x.Idioma);
            builder.Entity<Filme>().Property(x => x.TwoLetterISOLanguageName).HasColumnName("Idioma");

            builder.Entity<Estudio>().Ignore(x => x.Pais);
            builder.Entity<Estudio>().Property(x => x.CountryDisplayName).HasColumnName("Pais");
        }


        public DbSet<Ator> Ator { get; set; }

        public DbSet<Diretor> Diretor { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Midia> Midia { get; set; }
        public DbSet<Estudio> Estudio { get; set; }

    }
}
