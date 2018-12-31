using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SehirRehberi.API.Data;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cities")]
    public class CitiesController : Controller
    {
        private IAppRepository _apprepository;
        private IMapper _mapper;

        public CitiesController(IAppRepository apprepository, IMapper mapper)
        {
            _apprepository = apprepository;
            _mapper = mapper;
        }


        public ActionResult GetCities()
        {
            var cities = _apprepository.GetCities();
            var citiesToReturn = _mapper.Map<List<CityForListDto>>(cities);
            return Ok(citiesToReturn);
        }


        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]City city)
        {
            _apprepository.Add(city);
            _apprepository.SaveAll();
            return Ok(city);

        }

        [HttpGet]
        [Route("detail")]
        public ActionResult GetCityById(int id)
        {
            var city = _apprepository.GetCityById(id);
            var cityToReturn = _mapper.Map<CityForDetailDto>(city);
            return Ok(cityToReturn);
        }

        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosByCity(int cityId)
        {
            var photos = _apprepository.GetPhotosByCity(cityId);
            return Ok(photos);
        }
             
    }
}