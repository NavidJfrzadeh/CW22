using Core.CarEntity;
using Core.RequestEntity;
using System.ComponentModel.DataAnnotations;

namespace Core.LogEntity
{
    public class Log
    {
        public Log()
        {
            CreatedAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(11)]
        public string UserPhoneNumber { get; set; }
        [MaxLength(50)]
        public string CarPlateNumber { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public DateOnly CarProduceDate { get; set; }
        [MaxLength(250)]
        public DateTime CreatedAt { get; private set; }
    }
}
