namespace TaskMaster.Models
{
    public class Todo
    {
        internal int id;
        internal string todoId;

        public Todo(string name)
        {
            Name = name;

        }

        public Todo()
        {

        }

        public string Name { get; set; }
        public int Id { get; private set; }
    }
}