namespace Ingenico.DB.Entities
{
    public class Users
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] Image { get; set; }

        public int? SavingsCardId { get; set; }
    }
}
