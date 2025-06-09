//namespace WarehouseApp.Models
//{
    using System.ComponentModel.DataAnnotations;

    public enum TransactionType
    {
        Incoming, // Прихід
        Outgoing  // Витрата
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Тип операції є обов'язковим.")]
        public TransactionType Type { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Кількість повинна бути більшою за нуль.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Товар є обов'язковим.")]
        public int ProductId { get; set; }

        public Product? Product { get; set; } // Навігаційна властивість
    }

//}
