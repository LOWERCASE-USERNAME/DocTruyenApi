﻿// <auto-generated />
using System;
using DocTruyenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocTruyenApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241029023803_AddChapterName")]
    partial class AddChapterName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsAuthorId", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.Property<int>("GenresGenreId")
                        .HasColumnType("int");

                    b.HasKey("BooksBookId", "GenresGenreId");

                    b.HasIndex("GenresGenreId");

                    b.ToTable("BookGenre");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadTime")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Chapter", b =>
                {
                    b.Property<int>("ChapterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChapterId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("ChapterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChapterOrder")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChapterId");

                    b.HasIndex("BookId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            GenreName = "Tiên Hiệp"
                        },
                        new
                        {
                            GenreId = 2,
                            GenreName = "Huyền Huyễn"
                        },
                        new
                        {
                            GenreId = 3,
                            GenreName = "Đô Thị"
                        },
                        new
                        {
                            GenreId = 4,
                            GenreName = "Khoa Huyễn"
                        },
                        new
                        {
                            GenreId = 5,
                            GenreName = "Kỳ Huyễn"
                        },
                        new
                        {
                            GenreId = 6,
                            GenreName = "Võ Hiệp"
                        },
                        new
                        {
                            GenreId = 7,
                            GenreName = "Lịch Sử"
                        },
                        new
                        {
                            GenreId = 8,
                            GenreName = "Đồng Nhân"
                        },
                        new
                        {
                            GenreId = 9,
                            GenreName = "Quân sự"
                        },
                        new
                        {
                            GenreId = 10,
                            GenreName = "Du Hí"
                        },
                        new
                        {
                            GenreId = 11,
                            GenreName = "Cạnh Kỹ"
                        },
                        new
                        {
                            GenreId = 12,
                            GenreName = "Linh Dị"
                        },
                        new
                        {
                            GenreId = 13,
                            GenreName = "Ngôn Tình"
                        });
                });

            modelBuilder.Entity("DocTruyenApi.Models.ReadHistory", b =>
                {
                    b.Property<int>("ReadHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReadHistoryId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReadHistoryId");

                    b.HasIndex("BookId");

                    b.HasIndex("ChapterId");

                    b.HasIndex("UserId");

                    b.ToTable("ReadHistories");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DocTruyenApi.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("UserId");

                    b.HasIndex("AccountId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocTruyenApi.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookGenre", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocTruyenApi.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocTruyenApi.Models.Account", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Chapter", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Book", "Book")
                        .WithMany("Chapters")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Comment", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocTruyenApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DocTruyenApi.Models.ReadHistory", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DocTruyenApi.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("ChapterId");

                    b.HasOne("DocTruyenApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Chapter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DocTruyenApi.Models.User", b =>
                {
                    b.HasOne("DocTruyenApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DocTruyenApi.Models.Book", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}
