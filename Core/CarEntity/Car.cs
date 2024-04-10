using System.ComponentModel.DataAnnotations;

namespace Core.CarEntity
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public int NumberPlate { get; set; }
        public DateOnly CarProduceDate { get; set; }
        public bool IsChecked { get; private set; } = false;
    }
}
