namespace TaskMaster.Models
{
    public class Task
    {
        internal int id;
        internal string taskId;

        public Task(string name)
        {
            Name = name;

        }

        public Task()
        {

        }

        public string Name { get; set; }
        public int Id { get; private set; }
    }
}