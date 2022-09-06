using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfigs
{
    public class BookConfig : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {       
                #region Book
                
                builder.HasKey(b => b.Id);
                
                builder.Property(b => b.BookName)
                .IsRequired()
                .HasMaxLength(150);

                builder.Property(b => b.BookType)
                .IsRequired()
                .HasMaxLength(100);

                builder.Property(b => b.Publisher)
                .IsRequired()
                .HasMaxLength(150);

                builder.Property(b => b.PageNumber)
                .IsRequired();

                builder.Property(b => b.ISBN)
                .IsRequired()
                .HasMaxLength(15);

                builder.Property(b => b.Published)
                .IsRequired()
                .HasMaxLength(5);

                builder.Property(b => b.PublishedDate)
                .IsRequired();
                #endregion
        }
    }
}