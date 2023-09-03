﻿using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public bool DeleteCompany(string companyCode)
        {
            return _companyRepository.DeleteByCode(companyCode);
        }

        public async Task<bool> DeleteCompanyAsync(string companyCode)
        {
            return await _companyRepository.DeleteByCodeAsync(companyCode);
        }

        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public async Task<IEnumerable<CompanyInfo>> GetAllCompaniesAsync()
        {
            var res = await _companyRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public async Task<CompanyInfo> GetCompanyByCodeAsync(string companyCode)
        {
            var result = await _companyRepository.GetByCodeAsync(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public bool SaveCompany(CompanyInfo companyInfo)
        {
            var company = _mapper.Map<Company>(companyInfo);
            return _companyRepository.SaveCompany(company);
        }

        public async Task<bool> SaveCompanyAsync(CompanyInfo companyInfo)
        {
            var company = _mapper.Map<Company>(companyInfo);
            return await _companyRepository.SaveCompanyAsync(company);
        }

        public bool UpdateCompany(CompanyInfo companyInfo, string companyCode)
        {
            var company = _mapper.Map<Company>(companyInfo);
            company.CompanyCode = companyCode;
            return _companyRepository.SaveCompany(company);

        }

        public async Task<bool> UpdateCompanyAsync(CompanyInfo companyInfo, string companyCode)
        {
            var company = _mapper.Map<Company>(companyInfo);
            company.CompanyCode = companyCode;
            return await _companyRepository.SaveCompanyAsync(company);
        }
    }
}
