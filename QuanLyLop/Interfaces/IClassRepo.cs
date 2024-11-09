using QuanLyLop.Models;

namespace QuanLyLop.Interfaces;

public interface IClassRepo
{
    Task<IEnumerable<Class>> GetClassesAsync();
    Task AddClassAsync(Class classroom);
    Task DeleteClassAsync(Class classroom);
    Task UpdateClassAsync(Class classroom);
}