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
using TahalufAssignmentCore.Entities.Orgnizations;
using TahalufAssignmentCore.Helpers;
using TahalufAssignmentCore.Interfaces;
using TahalufAssignmentCore.Services.AppServices;

namespace TahalufAssignmentInfrastructure.Services.AppServices
{
    public class OrganizationAppService : IOrganizationAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly TahalufAssignmentDbContext _dbContext;
        public OrganizationAppService(IUnitOfWork unitOfWork, IMapper mapper, TahalufAssignmentDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dbContext= dbContext;
        }

        public async Task CreateUpdateOrgnization(CreateUpdateOrganizationDTO input)
        {
            try
            {
                if (!ValidationHelper.IsValidCode(input.Code))
                    throw new Exception("Invalid Code Value");
                if (!ValidationHelper.IsValidName(input.Name))
                    throw new Exception("Invalid Name Value");
                if (!ValidationHelper.IsValidInternationalPhone(input.Phone))
                    throw new Exception("Invalid Phone Value");
                if (await _dbContext.LookupItems.AnyAsync(x => x.Id.Equals(input.CountryId)))
                    throw new Exception("Country Id Should be Exisit");
                var orgnizationRepository = _unitOfWork.Repository<Orgnization>();
                _unitOfWork.BeginTransaction();
                if (input.Id == null)
                {
                    //Create
                    if (await _dbContext.Orgnizations.AnyAsync(x => x.Name.Equals(input.Name)))
                        throw new Exception("Orgnizations Name Should be Unique");
                    if (await _dbContext.Orgnizations.AnyAsync(x => x.Code.Equals(input.Code)))
                        throw new Exception("Orgnizations Code Should be Unique");
                    var orgnization = _mapper.Map<Orgnization>(input);
                    await orgnizationRepository.AddAsync(orgnization);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                }
                else
                {
                    //Update
                    var orgnization = await _dbContext.Orgnizations.AsNoTracking().FirstOrDefaultAsync(x=>x.Id==input.Id);
                    if (orgnization != null)
                    {

                        orgnization = _mapper.Map<Orgnization>(input);
                        orgnization.ModifiedDate = DateTime.Now;
                        await orgnizationRepository.UpdateAsync(orgnization);
                        await _unitOfWork.SaveChangesAsync();
                        _unitOfWork.CommitTransaction();
                    }
                    else
                    {
                        throw new Exception($"No orgnization Exisit With The Give Id : {(int)input.Id}");
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
        public async Task DeleteOrgnization(int Id)
        {
            try
            {
                var orgnizationRepository = _unitOfWork.Repository<Orgnization>();
                _unitOfWork.BeginTransaction();
                var orgnization = await orgnizationRepository.GetByIdAsync(Id);
                if (orgnization != null)
                {
                    await orgnizationRepository.DeleteAsync(orgnization);
                    await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.CommitTransaction();
                }
                else
                {
                    throw new Exception($"No Orgnization Exisit With The Give Id : {Id}");
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                Log.Error(ex.StackTrace);
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
        public async Task<OrgnizationInfoDTO> GetOrgnizationInfo(int Id)
        {
            try
            {
                var orgnizationRepository = _unitOfWork.Repository<Orgnization>();
                var item = await orgnizationRepository.IsExisit(x => x.Id == Id);
                if (item)
                {
                    var query = from orgnization in _dbContext.Orgnizations
                                join country in _dbContext.LookupItems
                                on orgnization.CountryId equals country.Id
                                where orgnization.Id == Id
                                select new OrgnizationInfoDTO
                                {
                                    Id = orgnization.Id,
                                    Address = orgnization.Address,
                                    Code = orgnization.Code,
                                    Country = country.Name,
                                    Name = orgnization.Name,
                                    CountryId = country.Id,
                                    CreateDate = orgnization.CreationDate.ToShortDateString(),
                                    Phone = orgnization.Phone,
                                    UpdateDate = orgnization.ModifiedDate == null ? "" : ((DateTime)orgnization.ModifiedDate).ToShortDateString()
                                };
                    return await query.SingleAsync();
                }
                else
                {
                    throw new Exception($"No Orgnization Exisit With The Give Id : {Id}");
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                Log.Error(ex.StackTrace);
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
        public async Task<List<OrgnizationInfoDTO>> GetAllOrgnizations()
        {
            try
            {
                var query = from orgnization in _dbContext.Orgnizations
                            join country in _dbContext.LookupItems
                            on orgnization.CountryId equals country.Id
                            select new OrgnizationInfoDTO
                            {
                                Id = orgnization.Id,
                                Address = orgnization.Address,
                                Code = orgnization.Code,
                                Country = country.Name,
                                Name = orgnization.Name,
                                CountryId = country.Id,
                                CreateDate = orgnization.CreationDate.ToShortDateString(),
                                Phone = orgnization.Phone,
                                UpdateDate = orgnization.ModifiedDate == null ? "" : ((DateTime)orgnization.ModifiedDate).ToShortDateString()
                            };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                Log.Error(ex.StackTrace);
                throw new Exception($"Error Upon Completing Transaction  {ex.Message}");
            }
        }
        public async Task<LoadItemDTO<OrgnizationDTO>> SearchOrgnization(SearchOrgnizationDTO input, int pageIndex, int pageSize)
        {
            LoadItemDTO<OrgnizationDTO> output = new LoadItemDTO<OrgnizationDTO>();
            try
            {
                var query = from orgnization in _dbContext.Orgnizations
                            join country in _dbContext.LookupItems
                            on orgnization.CountryId equals country.Id
                            where
                            (input.Name == null || orgnization.Name.Trim().ToLower().Contains(input.Name)) &&
                            (input.Code == null || orgnization.Code.Trim().ToLower().Contains(input.Code)) &&
                            (input.CountryId == null || orgnization.CountryId.Equals(input.CountryId))
                            select new OrgnizationDTO
                            {
                                Id = orgnization.Id,
                                Code = orgnization.Code,
                                CountryName = country.Name,
                                Phone = orgnization.Phone,
                                CreationDate = orgnization.CreationDate.ToShortDateString(),
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
