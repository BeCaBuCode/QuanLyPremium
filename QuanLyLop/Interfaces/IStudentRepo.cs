using QuanLyLop.Models;

namespace QuanLyLop.Interfaces;

public interface IStudentRepo
{
    Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId);
    Task AddStudentAsync(Student student);
    Task DeleteStudentAsync(Student student);
    Task UpdateStudentAsync(Student student);
}