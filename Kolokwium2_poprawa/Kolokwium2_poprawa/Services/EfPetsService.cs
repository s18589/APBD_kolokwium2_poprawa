using Kolokwium2_poprawa.DTO.Requests;
using Kolokwium2_poprawa.DTO.Responses;
using Kolokwium2_poprawa.Exceptions;
using Kolokwium2_poprawa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.Services
{
    public class EfPetsService : IPetsService
    {
        private readonly s18589Context _context;

        public EfPetsService(s18589Context context)
        {
            _context = context;
        }
        public IList<GetPetsResponse> GetPets(int year)
        {
            List<Pet> pets = new List<Pet>();
            List<GetPetsResponse> response = new List<GetPetsResponse>();
            if(year < 0)
            {
                pets = _context.Pet.ToList();
            }
            else
            {
                pets = _context.Pet
                    .Where(p => p.DateRegistered.Year.Equals(year)).ToList();
            }

            if(pets == null)
            {
                throw new NoPetsException($"No pets exception with this year of registration {year}");
            }

            foreach(Pet p in pets)
            {
                var volunteerPet = _context.VolunteerPet
                    .Where(x => x.IdPet == p.IdPet);

                IList<Volunteer> volunteers = new List<Volunteer>();
                foreach(VolunteerPet vp in volunteerPet)
                {
                    volunteers = _context.Volunteer
                        .Where(x => x.IdVolunteer == vp.IdVolunteer).ToList();
                    
                }
                response.Add(new GetPetsResponse
                {
                    Pet = p,
                    Volunteers = volunteers
                });
            }

            return response;
        }

        public void PostPet(PostPetRequest request)
        {
            if(request.BreedName == null)
            {
                throw new NoBreedNameException("You need to give a breed name");
            }

            if(request.Name == null)
            {
                throw new NoPetNameException("There is no pet name given");
            }

            if(request.IsMale == null)
            {
                throw new NoPetSexException("You haven't provided if pet is male or female");
            }

            if(request.DateRegistered == null)
            {
                throw new NoDateRegisteredException("You need to provide registration date");
            }

            var breedInDatabase = _context.BreedType
                .Any(x => x.Name.Equals(request.BreedName));

            if (!breedInDatabase)
            {
                _context.BreedType.Add(new BreedType
                {
                    Name = request.BreedName
                });
            }

            bool isMale = false;
            if (request.IsMale.Equals("1"))
            {
                isMale = true;
            }

            int idBreed = _context.BreedType
                .Single(b => b.Name.Equals(request.BreedName))
                .IdBreedType;

            _context.Pet.Add(new Pet
            {
                Name = request.Name,
                IsMale = isMale,
                DateRegistered = request.DateRegistered,
                ApprocimateDateOfBirth = request.ApprocimatedDateOfBirth,
                IdBreedType = idBreed
            });

            _context.SaveChanges();
        }
    }
}
