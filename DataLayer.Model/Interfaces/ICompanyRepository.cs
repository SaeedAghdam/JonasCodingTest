﻿using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Model.Interfaces
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetByCode(string companyCode);
        bool SaveCompany(Company company);
        bool DeleteByCode(string companyCode);

        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByCodeAsync(string companyCode);
        Task<bool> SaveCompanyAsync(Company company);
        Task<bool> DeleteByCodeAsync(string companyCode);
    }
}
