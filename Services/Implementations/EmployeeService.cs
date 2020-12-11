using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persistence;
using Persistence.Entities;
using Services.Interfaces;
using Services.Models;

namespace Services.Implementations
{
    public class EmployeeService:IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeService(ApplicationDbContext  dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}