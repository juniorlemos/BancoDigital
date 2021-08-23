﻿// <auto-generated />
using BancoDigital.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoDigital.Migrations
{
    [DbContext(typeof(ContaContext))]
    partial class ContaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("BancoDigital.Models.Conta", b =>
                {
                    b.Property<string>("ContaNumero")
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("ContaNumero");

                    b.ToTable("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
