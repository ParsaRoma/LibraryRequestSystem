using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfigs
{
    public class BookShelfConfig : IEntityTypeConfiguration<BookShelf>
    {
        public void Configure(EntityTypeBuilder<BookShelf> builder)
        {
            #region ManyToManyConfigs
            builder.HasKey(bs => new {bs.BookID, bs.ShelfID});
            
            builder
            .HasOne(bs => bs.Book)
            .WithMany(bs => bs.BookShelves)
            .HasForeignKey(bs => bs.BookID);

            builder
            .HasOne(bs => bs.Shelf)
                 .WithMany(bs => bs.BookShelves)
                 .HasForeignKey(bs => bs.ShelfID);
            #endregion
        }
    }
}