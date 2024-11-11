using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using QuanLyLop.Data;

namespace QuanLyLop.Services;

public class DatabaseService
{
    private SqliteConnection? _sqliteConnection;
    private AppDbContext? _dbContext;

    public AppDbContext DbContext => _dbContext ?? throw new NullReferenceException("Call Initialize() first");
    public void Initialize(string databasePath)
    {
        var connectionString = $"Data Source={databasePath}";
        _sqliteConnection = new SqliteConnection(connectionString);
        _sqliteConnection.Open();
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_sqliteConnection)
            .Options;
        _dbContext = new AppDbContext(options);
        _dbContext.Database.EnsureCreated();
    }
}