using BookAuthor_MySQL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Name);
            builder.HasIndex(b => b.Published);

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.Published)
                .IsRequired();

            builder.Property(b => b.Description)
                .IsRequired();
        }
    }
}
