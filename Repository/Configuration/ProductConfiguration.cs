﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
                builder.Property(p => p.Name).IsRequired().HasMaxLength(30);

                builder.HasOne(p => p.Creator)
                    .WithMany(p => p.History)
                    .HasForeignKey(p => p.CreatorId);
        }
    }
}
