using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompany company)
        {
            var mapped = _mapper.Map<CreateCompanyDTO>(company);
            try
            {
                var companyId = await _companyService.CreateCompany(mapped);
                return StatusCode(201, new {Id = companyId});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<IActionResult> SearchCompany([FromBody] SearchCompany searchCompany)
        {
            var mapped = _mapper.Map<SearchCompanyDTO>(searchCompany);
            try
            {
                var result = await _companyService.SearchCompany(mapped);
                var resultMapped = _mapper.Map<ICollection<CompanySearchResult>>(result);
                return StatusCode(200, new { Results = resultMapped });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompany company, [FromRoute] long id)
        {
            var exist = await _companyService.CompanyExist(id);
            if (!exist) return StatusCode(404);
            try
            {
                var mapped = _mapper.Map<UpdateCompanyDTO>(company);
                await _companyService.UpdateCompany(mapped, id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveCompany([FromRoute] long id)
        {
            var exist = await _companyService.CompanyExist(id);
            if (!exist) return StatusCode(404);
            try
            {
                
                await _companyService.RemoveCompany(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }

        }
    }
}
