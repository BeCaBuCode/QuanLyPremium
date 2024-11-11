using Microsoft.EntityFrameworkCore;
using QuanLyLop.Interfaces;
using QuanLyLop.Models;
using QuanLyLop.Services;

namespace QuanLyLop.Data;

public class StudentRepo(DatabaseService databaseService) : IStudentRepo
{
    private readonly AppDbContext _context = databaseService.DbContext;

    public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
    {
        return await _context.Students.Where(s => s.ClassId == classId).ToListAsync();
    }

    public async Task AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }
}