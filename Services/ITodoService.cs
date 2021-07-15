using EspAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EspAPI.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodos();
        Task<Todo> GetTodo(int id);
        Task<IEnumerable<Todo>> Search(string searchString);
        Task<Todo> SaveTodo(Todo todo);
        Task<int> RemoveTodo(int id);
    }

    public class TodoService : ITodoService {

        private ITodoRepostiory _todoRepository;

        public TodoService(ITodoRepostiory repo)
        {

            _todoRepository = repo;
        }

        public async Task<Todo> GetTodo(int id)
        {
            return await this._todoRepository.Get(id);
        }

        public async Task<IEnumerable<Todo>> GetTodos(){
            return await this._todoRepository.GetAll();
        }

        public async Task<int> RemoveTodo(int id)
        {
             return await this._todoRepository.Delete(id);
        }

        public async  Task<Todo> SaveTodo(Todo todo)
        {
            // if id == 0 then its a new todo
            if(todo.Id  == 0) {
               return await  this._todoRepository.Create(todo);
            }
            return await this._todoRepository.Update(todo);
        }

        public async Task<IEnumerable<Todo>> Search(string searchString)
        {
            return await this._todoRepository.Search(searchString);
        }
    }
}