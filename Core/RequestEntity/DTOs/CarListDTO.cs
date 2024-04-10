namespace Core.RequestEntity.DTOs
{
    public class CarListDTO
    {
        public int Id { get; set; }
        public string UserPhoneNumber { get; set; }
        public string CarBrand { get; set; }
        public string CarPlateNumber { get; set; }
        public bool IsAccepted { get; set; }
    }
}
