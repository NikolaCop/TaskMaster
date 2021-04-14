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

        public IEnumerable<List> Get()               //GET
        {
            string sql = "SELECT * FROM lists;";
            return _db.Query<List>(sql);
        }

        internal List Get(string Id)                 //GET WITH ID
        {
            string sql = "SELECT * FROM listss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<List>(sql, new { Id });
        }

        internal List Create(List newList)             //POST
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

        internal List Edit(List listsToEdit)          //EDIT
        {
            string sql = @"
      UPDATE listss
      SET
          name = @Name
          WHERE id = @Id;
          SELECT * FROM lists WHERE id = @Id;";
            return _db.QueryFirstOrDefault<List>(sql, listsToEdit);

        }

        internal void Delete(string id)            //DELORT
        {
            string sql = "DELETE FROM lists WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}