//namespace WarehouseApp.Models
//{
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Назва товару є обов'язковою.")]
    [StringLength(100, ErrorMessage = "Назва не може перевищувати 100 символів.")]
    public string? Name { get; set; }

    public string? Description { get; set; }

    [StringLength(50, ErrorMessage = "SKU не може перевищувати 50 символів.")]
    public string? SKU { get; set; } // Артикул

    [StringLength(20, ErrorMessage = "Одиниця виміру не може перевищувати 20 символів.")]
    public string? UnitOfMeasure { get; set; } // Одиниця виміру

    [Range(0, int.MaxValue, ErrorMessage = "Кількість не може бути від'ємною.")]
    public int Quantity { get; set; } // Поточна кількість на складі

    [Range(0b0, maximum: double.MaxValue, ErrorMessage = "Кількість не може бути від'ємною.")]
    public double Price { get; set; } // Поточна кількість на складі
}
//}
