using System.Collections.Generic;
using System.Data;
using Dapper;
using TaskMaster.Models;

namespace TaskMaster.Repositories
{
    public class TodosRepository
    {
        public readonly IDbConnection _db;

        public TodosRepository(IDbConnection db)
        {
            _db = db;
        }

        //GET ALL****************
        public IEnumerable<Todo> Get()
        {
            string sql = "SELECT * FROM todos;";
            return _db.Query<Todo>(sql);
        }

        //GET ONE WITH ID**************
        internal Todo Get(string Id)
        {
            string sql = "SELECT * FROM todoss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Todo>(sql, new { Id });
        }

        //CREATE***************
        internal Todo Create(Todo newTodo)
        {
            string sql = @"
      INSERT INTO todos
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newTodo);
            newTodo.id = id;
            return newTodo;
        }

        //EDIT********************
        internal Todo Edit(Todo todosToEdit)
        {
            string sql = @"
      UPDATE todos
      SET
          name = @Name
          WHERE id = @Id;
          SELECT * FROM todos WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Todo>(sql, todosToEdit);

        }

        //DELETE***********************
        internal void Delete(string id)
        {
            string sql = "DELETE FROM todos WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}