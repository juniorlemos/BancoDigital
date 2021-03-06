// <auto-generated />
using BancoDigital.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoDigital.Migrations
{
    [DbContext(typeof(ContaContext))]
    [Migration("20210821014118_ContaDb1")]
    partial class ContaDb1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("BancoDigital.Models.Conta", b =>
                {
                    b.Property<string>("ContaNumero")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NomeDoUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.HasKey("ContaNumero");

                    b.ToTable("Contas");
                });
#pragma warning restore 612, 618
        }
    }
}
