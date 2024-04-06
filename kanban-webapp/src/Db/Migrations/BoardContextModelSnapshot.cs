﻿// <auto-generated />
using System;
using Kanban.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace kanban_webapp.Migrations
{
    [DbContext(typeof(BoardContext))]
    partial class BoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Kanban.Model.Entity.BoardEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("Kanban.Model.Entity.CardEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("ColumnEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ColumnEntityId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Kanban.Model.Entity.ColumnEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("BoardEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BoardEntityId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("Kanban.Model.Entity.CardEntity", b =>
                {
                    b.HasOne("Kanban.Model.Entity.ColumnEntity", null)
                        .WithMany("Cards")
                        .HasForeignKey("ColumnEntityId");
                });

            modelBuilder.Entity("Kanban.Model.Entity.ColumnEntity", b =>
                {
                    b.HasOne("Kanban.Model.Entity.BoardEntity", null)
                        .WithMany("Columns")
                        .HasForeignKey("BoardEntityId");
                });

            modelBuilder.Entity("Kanban.Model.Entity.BoardEntity", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("Kanban.Model.Entity.ColumnEntity", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
