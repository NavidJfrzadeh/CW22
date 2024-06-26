﻿using App.Infra.Database.SQLServer.EF;
using Core.RequestEntity;
using Core.RequestEntity.Contracts;
using Core.RequestEntity.DTOs;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _context;

        public RequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateRequest(RequestDTO requestDTO)
        {
            CarRequest newRequest = new CarRequest()
            {
                CarBrand = requestDTO.CarBrand,
                CarBrandId = requestDTO.CarBrandId,
                CarPlateNumber = requestDTO.CarPlateNumber,
                CarProduceDate = requestDTO.CarProduceDate,
                UserAddress = requestDTO.UserAddress,
                UserNationalCode = requestDTO.UserNationalCode,
                UserPhoneNumber = requestDTO.UserPhoneNumber,
                CreatedAt = requestDTO.CreatedAt,
            };
            _context.Requests.Add(newRequest);
            _context.SaveChanges();
        }

        public void AcceptRequest(int id)
        {
            var carRequest = GetById(id);
            if (carRequest != null)
            {
                carRequest.SetStatus();
                _context.SaveChanges();
            }
        }


        public void DeleteRequest(int id)
        {
            var request = GetById(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                _context.SaveChanges();
            }
        }

        public CarRequest GetById(int id) => _context.Requests.Include(r => r.CarBrand).FirstOrDefault(r => r.Id == id);


        public List<CarListDTO> GetList(DateOnly date)
        {
            var cars = _context.Requests.Where(r => r.IsAccepted == false && r.CreatedAt == date)
                .Include(r => r.CarBrand)
                .Select(r => new CarListDTO()
                {
                    Id = r.Id,
                    UserPhoneNumber = r.UserPhoneNumber,
                    CarPlateNumber = r.CarPlateNumber,
                    CarBrand = r.CarBrand.Brand,
                    IsAccepted = r.IsAccepted
                }).ToList();

            return cars;
        }

        public List<CarListDTO> AllAcceptedRequests()
        {
            var RequestList = _context.Requests.Where(r => r.IsAccepted)
                .Select(r => new CarListDTO()
                {
                    Id = r.Id,
                    UserPhoneNumber = r.UserPhoneNumber,
                    CarPlateNumber = r.CarPlateNumber,
                    CarBrand = r.CarBrand.Brand,
                    IsAccepted = r.IsAccepted
                }).ToList();

            return RequestList;
        }

        public int Capacity(DateOnly date)
        {
            var count = _context.Requests.Where(r => r.CreatedAt == date).Count();
            return count;
        }

        public bool ValidCarPlateNumber(string carPlateNumber)
            => _context.Requests.Any(r => r.CarPlateNumber == carPlateNumber);

        public List<DateOnly> GetDates()
        {
            var dates = _context.Requests.Select(r=>r.CreatedAt).Distinct().ToList();
            return dates;
        }
    }
}
