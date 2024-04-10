using Core.UserEnitiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Database.SQLServer.EF.Configurations
{
    public class AdminEntityConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(a=>a.Id);
            builder.HasData(
                new Admin { Id=1,FullName="Hasan Hasani" , Email="hasan@gmail.com",Password = "9"}
                );
        }
    }
}
