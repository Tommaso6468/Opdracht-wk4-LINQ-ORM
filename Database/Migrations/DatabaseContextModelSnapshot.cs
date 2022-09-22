﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Database.Attractie", b =>
                {
                    b.Property<int>("AttractieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReserveringId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AttractieId");

                    b.HasIndex("ReserveringId");

                    b.ToTable("Attracties");
                });

            modelBuilder.Entity("Database.GastInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GastId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LaatstBezochteUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GastId")
                        .IsUnique();

                    b.ToTable("GastInfos");
                });

            modelBuilder.Entity("Database.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("Database.Onderhoud", b =>
                {
                    b.Property<int>("OnderhoudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttractieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Probleem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OnderhoudId");

                    b.HasIndex("AttractieId");

                    b.ToTable("Onderhoud");
                });

            modelBuilder.Entity("Database.Reservering", b =>
                {
                    b.Property<int>("ReserveringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("gastId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReserveringId");

                    b.HasIndex("gastId");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("MedewerkerOnderhoud", b =>
                {
                    b.Property<int>("CoordineertId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OnderhoudId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoordineertId", "OnderhoudId");

                    b.HasIndex("OnderhoudId");

                    b.ToTable("MedewerkerOnderhoud");
                });

            modelBuilder.Entity("Database.Gast", b =>
                {
                    b.HasBaseType("Database.Gebruiker");

                    b.Property<int?>("BegeleiderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EersteBezoek")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FavorietAttractieId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("TEXT");

                    b.HasIndex("BegeleiderId");

                    b.HasIndex("FavorietAttractieId");

                    b.ToTable("Gasten", (string)null);
                });

            modelBuilder.Entity("Database.Medewerker", b =>
                {
                    b.HasBaseType("Database.Gebruiker");

                    b.ToTable("Medewerkers", (string)null);
                });

            modelBuilder.Entity("Database.Attractie", b =>
                {
                    b.HasOne("Database.Reservering", null)
                        .WithMany("Attracties")
                        .HasForeignKey("ReserveringId");
                });

            modelBuilder.Entity("Database.GastInfo", b =>
                {
                    b.HasOne("Database.Gast", "gast")
                        .WithOne("GastInfo")
                        .HasForeignKey("Database.GastInfo", "GastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Database.Coordinate", "Coordinaat", b1 =>
                        {
                            b1.Property<int>("GastInfoId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("X")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Y")
                                .HasColumnType("INTEGER");

                            b1.HasKey("GastInfoId");

                            b1.ToTable("GastInfos");

                            b1.WithOwner()
                                .HasForeignKey("GastInfoId");
                        });

                    b.Navigation("Coordinaat")
                        .IsRequired();

                    b.Navigation("gast");
                });

            modelBuilder.Entity("Database.Onderhoud", b =>
                {
                    b.HasOne("Database.Attractie", "attractie")
                        .WithMany()
                        .HasForeignKey("AttractieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Database.DateTimeBereik", "dateTimeBereik", b1 =>
                        {
                            b1.Property<int>("OnderhoudId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("TEXT");

                            b1.HasKey("OnderhoudId");

                            b1.ToTable("Onderhoud");

                            b1.WithOwner()
                                .HasForeignKey("OnderhoudId");
                        });

                    b.Navigation("attractie");

                    b.Navigation("dateTimeBereik")
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Reservering", b =>
                {
                    b.HasOne("Database.Gast", "gast")
                        .WithMany("Reserveringen")
                        .HasForeignKey("gastId");

                    b.OwnsOne("Database.DateTimeBereik", "dateTimeBereik", b1 =>
                        {
                            b1.Property<int>("ReserveringId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("TEXT");

                            b1.HasKey("ReserveringId");

                            b1.ToTable("Reserveringen");

                            b1.WithOwner()
                                .HasForeignKey("ReserveringId");
                        });

                    b.Navigation("dateTimeBereik")
                        .IsRequired();

                    b.Navigation("gast");
                });

            modelBuilder.Entity("MedewerkerOnderhoud", b =>
                {
                    b.HasOne("Database.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("CoordineertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Database.Onderhoud", null)
                        .WithMany()
                        .HasForeignKey("OnderhoudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Gast", b =>
                {
                    b.HasOne("Database.Gast", "Begeleider")
                        .WithMany()
                        .HasForeignKey("BegeleiderId");

                    b.HasOne("Database.Attractie", "Favoriet")
                        .WithMany()
                        .HasForeignKey("FavorietAttractieId");

                    b.HasOne("Database.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("Database.Gast", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Begeleider");

                    b.Navigation("Favoriet");
                });

            modelBuilder.Entity("Database.Medewerker", b =>
                {
                    b.HasOne("Database.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("Database.Medewerker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Database.Reservering", b =>
                {
                    b.Navigation("Attracties");
                });

            modelBuilder.Entity("Database.Gast", b =>
                {
                    b.Navigation("GastInfo");

                    b.Navigation("Reserveringen");
                });
#pragma warning restore 612, 618
        }
    }
}
