using Core.CarEntity;
using System.ComponentModel.DataAnnotations;

namespace Core.RequestEntity.DTOs
{
    public class RequestDTO
    {
        public RequestDTO()
        {
            CreatedAt = DateOnly.FromDateTime(DateTime.Now);
        }

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
        public DateOnly CreatedAt { get; set; }
    }
}
