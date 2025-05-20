using LibraryApp.Data.API;

namespace LibraryApp.Data.Implementation
{
    internal class Reader : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Reader(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
