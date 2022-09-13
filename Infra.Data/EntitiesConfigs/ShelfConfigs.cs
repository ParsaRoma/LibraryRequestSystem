using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.EntitiesConfigs
{
    public class ShelfConfigs : IEntityTypeConfiguration<Shelf>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Shelf> builder)
        {
            #region Shelf
            
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.ShelfName)
            .IsRequired()
            .HasMaxLength(100);

            builder.HasOne(s => s.User)
            .WithMany(s => s.Shelves) 
            .HasForeignKey(s => s.UserID);

            #endregion

        }
    }
}