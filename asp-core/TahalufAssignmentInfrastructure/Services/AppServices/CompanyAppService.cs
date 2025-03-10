using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TahalufAssignmentCore.Context;
using TahalufAssignmentCore.DTOs.APIs.Responses;
using TahalufAssignmentCore.DTOs.Companies;
using TahalufAssignmentCore.DTOs.Orgnizations;
using TahalufAssignmentCore.Entities.Companies;
using TahalufAssignmentCore.Helpers;
using TahalufAssignmentCore.Interfaces;
using TahalufAssignmentCore.Services.AppServices;

namespace TahalufAssignmentInfrastructure.Services.AppServices
{
    public class CompanyAppService: ICompanyAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TahalufAssignmentDbContext _dbContext;
        public CompanyAppService(IUnitOfWork unitOfWork, IMapper mapper, TahalufAssignmentDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task CreateUpdateCompany(CreateUpdateCompanyDTO input)
        {

            try
            {
                if (!ValidationHelper.IsValidCode(input.Code))
                    throw new Exception("Invalid Code Value");
                if (!ValidationHelper.IsValidName(input.Name))
                    throw new Exception("Invalid Name Value");
                if (!ValidationHelper.IsValidInternationalPhone(input.Phone))
                    throw new Exception("Invalid Phone Value");
                if (!await _dbContext.LookupItems.AnyAsync(x => x.Id.Equals(input.CountryId)))
                    throw new Exception("Country Id Should be Exisit");
                if (!await _dbContext.Orgnizations.AnyAsync(x => x.Id.Equals(input.OrganizationId)))
                    throw new Exception("Orgnization Id Should be Exisit");
                var companyRepository = _unitOfWork.Repository<Company>();
                _unitOfWork.BeginTransaction();
                if(input.Id == null)
                {
                    //Create
                    if (await _dbContext.Companies.AnyAsync(x => x.Name.Equals(input.Name)))
                        throw new Exception("Comnpany Name Should be Unique");
                    if (await _dbContext.Companies.AnyAsync(x => x.Code.Equals(input.Code)))
                        throw new Exception("Comnpany Code Should be Unique");
                    var company = _mapper.Map<Company>(input);
                    await companyRepository.AddAsync(company);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                }
                else
                {
                    //Update
                    var company = await companyRepository.GetByIdAsync((int)input.Id);
                    if(company != null)
                    {
                        company = _mapper.Map<Company>(input);
                        await companyRepository.UpdateAsync(company);
                        await _unitOfWork.SaveChangesAsync();
                        _unitOfWork.CommitTransaction();
                    }
                    else
                    {
                        throw new Exception($"No Company Exisit With The Give Id : {(int)input.Id}");
                    }
                }
                
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                Log.Error(ex.StackTrace);
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
        public async Task DeleteCompany(int Id)
        {
            try
            {
                var companyRepository = _unitOfWork.Repository<Company>();
                _unitOfWork.BeginTransaction();
                var company = await companyRepository.GetByIdAsync(Id);
                if (company != null)
                {
                    await companyRepository.DeleteAsync(company);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                }
                else
                {
                    throw new Exception($"No Company Exisit With The Give Id : {Id}");
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                Log.Error(ex.StackTrace);
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
        public async Task<CompanyInfoDTO> GetCompanyInfo(int Id)
        {
            try
            {
                var companyRepository = _unitOfWork.Repository<Company>();
                var item = await companyRepository.IsExisit(x=>x.Id==Id);
                if (item)
                {
                    var query = from company in _dbContext.Companies
                                join orgnization in _dbContext.Orgnizations
                                on company.OrganizationId equals orgnization.Id
                                join country in _dbContext.LookupItems
                                on company.CountryId equals country.Id
                                where orgnization.Id == Id
                                select new CompanyInfoDTO
                                {
                                    Id = company.Id,
                                    Address = company.Address,
                                    OrganizationId = company.OrganizationId,
                                    Code = company.Code,
                                    Country = country.Name,
                                    Name = company.Name,
                                    CountryId = country.Id,
                                    CreateDate = company.CreationDate.ToString(),
                                    OrgnizationName = orgnization.Name,
                                    Phone = company.Phone,
                                    UpdateDate = company.ModifiedDate == null? "": ((DateTime)company.ModifiedDate).ToString()
                                };
                    return await query.FirstOrDefaultAsync();
                }
                else
                {
                    throw new Exception($"No Company Exisit With The Give Id : {Id}");
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                Log.Error(ex.StackTrace);
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
        public async Task<LoadItemDTO<CompanyDTO>> SearchCompanies(SearchCompanyDTO input, int pageIndex, int pageSize)
        {
            LoadItemDTO<CompanyDTO> output = new LoadItemDTO<CompanyDTO>();
            try
            {
                var query = from company in _dbContext.Companies
                            join orgnization in _dbContext.Orgnizations
                            on company.OrganizationId equals orgnization.Id
                            join country in _dbContext.LookupItems
                            on company.CountryId equals country.Id
                            where
                            (input.Name == null || company.Name.Trim().ToLower().Contains(input.Name.Trim().ToLower())) &&
                            (input.Code == null || company.Code.Trim().ToLower().Contains(input.Code.Trim().ToLower())) &&
                            (input.CountryId == null || company.CountryId.Equals(input.CountryId))&&
                            (input.OrgnizationId == null || company.OrganizationId.Equals(input.OrgnizationId))
                            select new CompanyDTO
                            {
                                Id = company.Id,
                                Code = company.Code,
                                Name = company.Name,
                                CountryName = country.Name,
                                Phone = company.Phone,
                                CreationDate = company.CreationDate.ToString(),
                                OrgnizationName = orgnization.Name
                            };
                output.Items = await query.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
                output.TotalItem = await query.CountAsync();
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
    }
}
