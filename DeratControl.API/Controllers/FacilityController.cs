using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeratControl.API.Dispatchers;
using DeratControl.Application.Requests;
using DeratControl.Application.Perimeters.Commands;
using DeratControl.Application.Perimeters.Queries.GetPerimetersList;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Application.Interfaces;

namespace DeratControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
       
    }
}
