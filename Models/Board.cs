namespace TaskMaster.Models
{
    public class Board
    {
        internal int id;
        internal string boardId;

        public Board(string name)
        {
            Name = name;

        }

        public Board()
        {

        }

        public string Name { get; set; }
        public int Id { get; private set; }
    }
}