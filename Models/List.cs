namespace TaskMaster.Models
{
    public class List
    {
        internal int id;
        internal string listId;

        public List(string name)
        {
            Name = name;

        }

        public List()
        {

        }

        public string Name { get; set; }
        public int Id { get; private set; }
    }
}