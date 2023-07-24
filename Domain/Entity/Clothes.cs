

namespace Mortiz.Domain.Entity
{
    public class Clothes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Material { get; set; }
        public byte[] Photos { get; set; }

    }
}
