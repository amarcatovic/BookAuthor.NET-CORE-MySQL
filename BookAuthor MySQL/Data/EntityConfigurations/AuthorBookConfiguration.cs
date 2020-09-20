using BookAuthor_MySQL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAuthor_MySQL.Data.EntityConfigurations
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(ab => new { ab.BookId, ab.AuthorId });

            builder.HasOne(ab => ab.Author)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId);

            builder.HasOne(ab => ab.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ab => ab.BookId);
        }
    }
}
