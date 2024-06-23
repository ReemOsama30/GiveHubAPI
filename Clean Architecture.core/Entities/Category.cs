using Clean_Architecture.Application.Interfaces;

namespace Clean_Architecture.core.Entities
{
    public class Category : IsoftDeletable
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
