using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiRest.Context;
using WebApiRest.Dto;

namespace WebApiRest.Helpers
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Tbdatosfacturacionelectronica, ArchivoP12Dto>().ReverseMap();
        }
    }
}
