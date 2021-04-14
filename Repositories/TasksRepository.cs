using System.Collections.Generic;
using System.Data;
using Dapper;
using TaskMaster.Models;

namespace TaskMaster.Repositories
{
    public class TasksRepository
    {
        public readonly IDbConnection _db;

        public TasksRepository(IDbConnection db)
        {
            _db = db;
        }

        //GET ALL****************
        public IEnumerable<Task> Get()
        {
            string sql = "SELECT * FROM tasks;";
            return _db.Query<Task>(sql);
        }

        //GET ONE WITH ID**************
        internal Task Get(string Id)
        {
            string sql = "SELECT * FROM taskss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Task>(sql, new { Id });
        }

        //CREATE***************
        internal Task Create(Task newTask)
        {
            string sql = @"
      INSERT INTO taskss
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newTask);
            newTask.id = id;
            return newTask;
        }

        //EDIT********************
        internal Task Edit(Task tasksToEdit)
        {
            string sql = @"
      UPDATE taskss
      SET
          name = @Name
          WHERE id = @Id;
          SELECT * FROM tasks WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Task>(sql, tasksToEdit);

        }

        //DELETE***********************
        internal void Delete(string id)
        {
            string sql = "DELETE FROM tasks WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}