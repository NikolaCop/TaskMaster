using System.Collections.Generic;
using System.Data;
using Dapper;
using TaskMaster.Models;

namespace TaskMaster.Repositories
{
    public class ListsRepository
    {
        public readonly IDbConnection _db;

        public ListsRepository(IDbConnection db)
        {
            _db = db;
        }

        //GET ALL****************************
        public IEnumerable<List> Get()
        {
            string sql = "SELECT * FROM lists;";
            return _db.Query<List>(sql);
        }

        //GET ONE WITH ID****************
        internal List Get(string Id)
        {
            string sql = "SELECT * FROM listss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<List>(sql, new { Id });
        }

        //POST***************************
        internal List Create(List newList)
        {
            string sql = @"
      INSERT INTO listss
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newList);
            newList.id = id;
            return newList;
        }

        //EDIT*************************
        internal List Edit(List listsToEdit)
        {
            string sql = @"
      UPDATE listss
      SET
          name = @Name
          WHERE id = @Id;
          SELECT * FROM lists WHERE id = @Id;";
            return _db.QueryFirstOrDefault<List>(sql, listsToEdit);

        }

        //DELETE************************
        internal void Delete(string id)
        {
            string sql = "DELETE FROM lists WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}