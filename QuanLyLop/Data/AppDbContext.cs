using Microsoft.EntityFrameworkCore;
using QuanLyLop.Models;

namespace QuanLyLop.Data;

public class AppDbContext (DbContextOptions options) : DbContext (options)
{
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
}