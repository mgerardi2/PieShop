namespace Ingenico.DB.Entities
{
    public class OrderLines
    {
        public int Id { get; set; }

        public int PieId { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int OrderId { get; set; }
    }
}
