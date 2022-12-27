﻿using Hennis_DAL.DbEntities;
using Hennis_Models.Dto;
using Hennis_Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Business.Repository.Interface
{
    public interface IPaystubRepository
    {
        Task<PaystubDto> Create(PaystubModel paystubDto);
        Task<IEnumerable<PaystubDto>> GetByDate(DateTime date);
        Task<IEnumerable<PaystubDto>> GetByDateAndUserId(DateTime date, int UserId);
        Task<PaystubDto> GetById(int id);

        Task<bool> PaystubExistsForEmployee(string employeeId, DateTime payDate);

    }
}