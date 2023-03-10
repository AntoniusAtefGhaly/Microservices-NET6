// <auto-generated />
using Basket.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Basket.API.Migrations
{
    [DbContext(typeof(BasketContext))]
    partial class BasketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Basket.API.Entities.BasketCart", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserName");

                    b.ToTable("BasketCarts");

                    b.HasData(
                        new
                        {
                            UserName = "user1"
                        },
                        new
                        {
                            UserName = "user2"
                        },
                        new
                        {
                            UserName = "user3"
                        });
                });

            modelBuilder.Entity("Basket.API.Entities.BasketCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BasketCart")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BasketCart");

                    b.ToTable("BasketCartItems");
                });

            modelBuilder.Entity("Basket.API.Entities.BasketCartItem", b =>
                {
                    b.HasOne("Basket.API.Entities.BasketCart", null)
                        .WithMany("BasketCartItems")
                        .HasForeignKey("BasketCart");
                });

            modelBuilder.Entity("Basket.API.Entities.BasketCart", b =>
                {
                    b.Navigation("BasketCartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
