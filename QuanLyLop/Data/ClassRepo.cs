using Microsoft.EntityFrameworkCore;
using QuanLyLop.Interfaces;
using QuanLyLop.Models;
using QuanLyLop.Services;

namespace QuanLyLop.Data;

public class ClassRepo : IClassRepo
{
    private readonly AppDbContext context;

    public ClassRepo(DatabaseService databaseService)
    {
        context = databaseService.DbContext;
    }
    public async Task<IEnumerable<Class>> GetClassesAsync()
    {
        return await context.Classes.ToListAsync();
    }
    public async Task AddClassAsync(Class classroom)
    {
        context.Classes.Add(classroom);
        await context.SaveChangesAsync();
    }
    public async Task DeleteClassAsync(Class classroom)
    {
           var studentstoDelete = context.Students.Where(s=>s.ClassId == classroom.ClassId).ToList();
           foreach (var student in studentstoDelete)
           {
               context.Students.Remove(student);
           }
           context.Classes.Remove(classroom);
           await context.SaveChangesAsync();
    }
    public async Task UpdateClassAsync(Class classroom)
    {
        context.Classes.Update(classroom);
        await context.SaveChangesAsync();
    }
}