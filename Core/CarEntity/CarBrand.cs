using System.ComponentModel.DataAnnotations;

namespace Core.CarEntity
{
    public class CarBrand
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Brand { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
