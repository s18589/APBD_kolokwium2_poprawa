using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium2_poprawa.DTO.Requests;
using Kolokwium2_poprawa.Exceptions;
using Kolokwium2_poprawa.Models;
using Kolokwium2_poprawa.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2_poprawa.Controllers
{
    [Route("api")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetsService _service;

        public PetsController(IPetsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("api/pets/{year:int}")]
        public IActionResult GetPets(int year)
        {
            IActionResult response;
            try
            {
                response = Ok(_service.GetPets(year));
            }catch(Exception e)
            {
                response = BadRequest($"Some error occured \n{e.StackTrace}");
            }

            return response;
        }


        [HttpPost]
        [Route("/api/pets")]
        public IActionResult PostPet(PostPetRequest request)
        {
            IActionResult response;
            try
            {
                _service.PostPet(request);
                response = Ok("Added pet to database");
            }catch(NoBreedNameException e)
            {
                response = BadRequest($"You need to give a breed name \n{e.StackTrace}");
            }
            catch (NoDateRegisteredException e)
            {
                response = BadRequest($"You need to provide registration dat \n{e.StackTrace}");
            }
            catch (NoPetSexException e)
            {
                response = BadRequest($"You haven't provided if pet is male or female \n{e.StackTrace}");
            }
            catch (NoPetNameException e)
            {
                response = BadRequest($"There is no pet name given \n{e.StackTrace}");
            }
            catch (Exception e)
            {
                response = BadRequest($"Other error occured \n{e.StackTrace}");
            }
            return response;
        }
    }
}