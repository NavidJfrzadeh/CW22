using Core.CarEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Database.SQLServer.EF.Configurations
{
    public class CarModelEntitiyConfiguration : IEntityTypeConfiguration<CarBrand>
    {
        public void Configure(EntityTypeBuilder<CarBrand> builder)
        {
            builder.HasKey(m => m.Id);
            builder.HasData(
                new CarBrand { Id = 1, Brand = "Iran Khodro" },
                new CarBrand { Id = 2, Brand = "Saipa" }
                );
        }
    }
}
