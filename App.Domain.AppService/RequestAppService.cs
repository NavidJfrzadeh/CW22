using Core.BaseService;
using Core.LogEntity.Contracts;
using Core.RequestEntity;
using Core.RequestEntity.Contracts;
using Core.RequestEntity.DTOs;
using Microsoft.Extensions.Logging;

namespace App.Domain.AppService
{
    public class RequestAppService : IRequestAppService
    {
        private readonly IRequestService _requestService;
        private readonly ILogService _logService;
        private readonly IBaseService _baseService;
        private readonly ILogger<RequestAppService> _logger;

        public RequestAppService(IRequestService requestService, ILogService logService, IBaseService baseService, ILogger<RequestAppService> logger)
        {
            _requestService = requestService;
            _logService = logService;
            _baseService = baseService;
            _logger = logger;
        }

        public void AcceptRequest(int id)
        {
            _requestService.AcceptRequest(id);
        }

        public List<CarListDTO> AllAcceptedRequests()
        {
            return _requestService.AllAcceptedRequests();
        }

        public string CreateRequest(RequestDTO requestDTO)
        {
            string message = string.Empty;

            var isEven = _baseService.IsEven(DateOnly.FromDateTime(DateTime.Now));
            if (isEven == 0)
            {
                message = "سامانه در روز جمعه غیر فعال است";
                _logger.LogError("site is not accessible at this time");
                return message;
            }

            if (requestDTO.CarBrandId == 1)
            {
                if (isEven == 2)
                {
                    var count = _requestService.Capacity(requestDTO.CreatedAt);
                    if (count < 10)
                    {
                        if (_baseService.IsValidForSubmit(requestDTO.CarProduceDate))
                        {
                            var ValidPlate = _requestService.ValidCarPlateNumber(requestDTO.CarPlateNumber);
                            if (!ValidPlate)
                            {
                                _requestService.CreateRequest(requestDTO);
                                _logger.LogInformation("Request has been created");
                                message = "درخواست شما با موفقیت ثبت شد";
                            }
                            else
                            {
                                message = "شماره پلاک ماشین قبلا ثبت شده است";
                            }
                        }
                        else
                        {
                            _logService.Create(requestDTO.UserPhoneNumber, requestDTO.CarPlateNumber, requestDTO.CarBrandId, requestDTO.CarBrand, requestDTO.CarProduceDate);
                            message = "از ارائه خدمات به ماشین های بالای پنج سال معذوریم ";
                        }
                    }
                    else
                    {
                        message = "ظرفیت ثبت درخواست برای امروز تکمیل شده است";
                    }
                }
                else
                {
                    message = "به ماشین های ایران خودرو فقط در روز های زوج خدمات ارائه می شود!";
                }
            }
            else if (requestDTO.CarBrandId == 2)
            {
                if (isEven == 1)
                {
                    var count = _requestService.Capacity(requestDTO.CreatedAt);
                    if (count < 5)
                    {
                        if (_baseService.IsValidForSubmit(requestDTO.CarProduceDate))
                        {
                            var ValidPlate = _requestService.ValidCarPlateNumber(requestDTO.CarPlateNumber);
                            if (!ValidPlate)
                            {
                                _requestService.CreateRequest(requestDTO);
                                message = "درخواست شما با موفقیت ثبت شد";
                            }
                            else
                            {
                                message = "شماره پلاک ماشین قبلا ثبت شده است";
                            }
                        }
                        else
                        {
                            _logService.Create(requestDTO.UserPhoneNumber, requestDTO.CarPlateNumber, requestDTO.CarBrandId, requestDTO.CarBrand, requestDTO.CarProduceDate);
                            message = "از ارائه خدمات به ماشین های بالای پنج سال معذوریم ";
                        }
                    }
                    else
                    {
                        message = "ظرفیت ثبت درخواست برای امروز تکمیل شده است";
                    }
                }
                else
                {
                    message = "به ماشین های سایپا فقط در روز های فرد خدمات ارائه می شود";
                }
            }

            return message;
        }

        public void DeleteRequest(int id)
        {
            _requestService.DeleteRequest(id);
        }

        public CarRequest GetById(int id)
        {
            return _requestService.GetById(id);
        }

        public List<DateOnly> GetDates()
        {
            return _requestService.GetDates();
        }

        public List<CarListDTO> GetListByDate(DateOnly date)
        {
            return _requestService.GetList(date);
        }
    }
}
