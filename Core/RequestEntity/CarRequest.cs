using Core.CarEntity;
using System.ComponentModel.DataAnnotations;

namespace Core.RequestEntity
{
    public class CarRequest
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(11)]
        public string UserPhoneNumber { get; set; }
        [MaxLength(50)]
        public string UserNationalCode { get; set; }
        [MaxLength(50)]
        public string CarPlateNumber { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public DateOnly CarProduceDate { get; set; }
        [MaxLength(250)]
        public string UserAddress { get; set; }
        public bool IsAccepted { get; private set; } = false;
        public DateOnly CreatedAt { get; set; }

        public void SetStatus()
        {
            IsAccepted = true;
        }
    }
}
