using Microsoft.EntityFrameworkCore;

namespace DocTruyenApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ReadHistory> ReadHistories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Tiên Hiệp"},    
                new Genre { GenreId = 2, GenreName = "Huyền Huyễn"},    
                new Genre { GenreId = 3, GenreName = "Đô Thị"},    
                new Genre { GenreId = 4, GenreName = "Khoa Huyễn"},    
                new Genre { GenreId = 5, GenreName = "Kỳ Huyễn"},    
                new Genre { GenreId = 6, GenreName = "Võ Hiệp"},    
                new Genre { GenreId = 7, GenreName = "Lịch Sử"},    
                new Genre { GenreId = 8, GenreName = "Đồng Nhân"},    
                new Genre { GenreId = 9, GenreName = "Quân sự"},    
                new Genre { GenreId = 10, GenreName = "Du Hí"},    
                new Genre { GenreId = 11, GenreName = "Cạnh Kỹ"},    
                new Genre { GenreId = 12, GenreName = "Linh Dị"},    
                new Genre { GenreId = 13, GenreName = "Ngôn Tình"}    
            );
        }
    }
}
