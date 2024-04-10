using Core.CarEntity;
using Core.CustomValidation;
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
        [DataType(DataType.PhoneNumber)]
        //[PhoneNumberValidation]
        [Required(ErrorMessage = "شماره تماس الزامی است")]
        public string UserPhoneNumber { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "کدملی الزامی است")]
        public string UserNationalCode { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "پلاک ماشین الزامی است")]
        public string CarPlateNumber { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        [Required]
        [DataType(DataType.Date, ErrorMessage = "تاریخ را وارد کنید")]
        public DateOnly CarProduceDate { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage = "آدرس را وارد کنید")]
        public string UserAddress { get; set; }
        public DateOnly CreatedAt { get; set; }
    }
}
