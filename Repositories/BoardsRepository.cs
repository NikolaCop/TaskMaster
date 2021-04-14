using System.Collections.Generic;
using System.Data;
using Dapper;
using TaskMaster.Models;

namespace TaskMaster.Repositories
{
    public class BoardsRepository
    {
        public readonly IDbConnection _db;

        public BoardsRepository(IDbConnection db)
        {
            _db = db;
        }

        //GET ALL****************************
        public IEnumerable<Board> Get()
        {
            string sql = "SELECT * FROM boards;";
            return _db.Query<Board>(sql);
        }

        //GET ONE WITH ID****************
        internal Board Get(string Id)
        {
            string sql = "SELECT * FROM boardss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Board>(sql, new { Id });
        }

        //POST***************************
        internal Board Create(Board newBoard)
        {
            string sql = @"
      INSERT INTO boardss
      (name)
      VALUES
      (@Name);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBoard);
            newBoard.id = id;
            return newBoard;
        }

        //EDIT*************************
        internal Board Edit(Board boardsToEdit)
        {
            string sql = @"
      UPDATE boardss
      SET
          name = @Name
          WHERE id = @Id;
          SELECT * FROM boards WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Board>(sql, boardsToEdit);

        }

        //DELETE************************
        internal void Delete(string id)
        {
            string sql = "DELETE FROM boards WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}