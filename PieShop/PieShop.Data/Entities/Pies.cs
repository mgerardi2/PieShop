using System.ComponentModel;

namespace Ingenico.DB.Entities
{
    public class Pies
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public decimal Price { get; set; }
    }
}
