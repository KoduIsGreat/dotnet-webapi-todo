using System;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;
using Dapper;
namespace EspAPI.Models
{
    
    public class TodoRepository : ITodoRepostiory

    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction transaction;
        public TodoRepository(IDbTransaction transaction)
        {
            this.transaction = transaction;
            this.connection = transaction.Connection;
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await connection.QueryAsync<Todo>("SELECT * FROM todo.todos;");
        }


        public async Task<Todo> Get(int id)
        {
            return await connection.QueryFirstAsync<Todo>("SELECT * from todo.todos where id = @Id;", new {  id });
        }

        public async Task<Todo> Create(Todo t)
        {
            var q = "INSERT INTO todo.todos (name, completed,created_at,modified_on) Values (@Name,@Completed, @CreatedAt, @ModifiedOn);";
            
            var result  =  await connection.ExecuteScalarAsync(q, new {  
                Name = t.Name, 
                Completed = t.Completed, 
                CreatedAt = DateTime.UtcNow, 
                ModifiedOn = DateTime.UtcNow
                });
            if (result != null)
            {
                t.Id = Convert.ToInt32(result);
            }
            return t;
        }

        public async Task<IEnumerable<Todo>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Todo> Update(Todo todo) {
            var q = "UPDATE todo.todos SET name=@Name, completed=@Completed,modified_on=now() WHERE id=@Id";
            var result = await connection.ExecuteAsync(q, new {
                Id = todo.Id,
                Name = todo.Name,
                Completed = todo.Completed,
            });
            return todo;
        }

        public async Task<int> Delete(int id) {
            var q = "DELETE FROM todo.todos where id=@Id";
            return await connection.ExecuteAsync(q, new {Id = id});
        }
    }
}