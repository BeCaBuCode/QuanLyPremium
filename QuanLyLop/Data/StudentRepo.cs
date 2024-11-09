using Microsoft.EntityFrameworkCore;
using QuanLyLop.Interfaces;
using QuanLyLop.Models;
using QuanLyLop.Services;

namespace QuanLyLop.Data;

public class StudentRepo : IStudentRepo
{
    private readonly AppDbContext context;

    public StudentRepo(DatabaseService databaseService)
    {
        context = databaseService.DbContext;
    }

    public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
    {
        return await context.Students.Where(s=>s.ClassId==classId).ToListAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Student student)
    {
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        context.Students.Update(student);
        await context.SaveChangesAsync();
    }
}