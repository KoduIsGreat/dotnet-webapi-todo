using System.Collections.Generic;
using System.Threading.Tasks;
namespace EspAPI.Models
{
    public interface ITodoRepostiory : IService
    {
        Task<Todo> Get(int id);
        Task<IEnumerable<Todo>> GetAll();
        Task<IEnumerable<Todo>> Search(string name);
        Task<Todo> Update(Todo t);
        Task<int> Delete(int id);

        Task<Todo> Create(Todo t);
    }
}