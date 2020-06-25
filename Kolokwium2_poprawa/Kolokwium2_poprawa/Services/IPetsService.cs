using Kolokwium2_poprawa.DTO.Requests;
using Kolokwium2_poprawa.DTO.Responses;
using Kolokwium2_poprawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.Services
{
    public interface IPetsService
    {
        IList<GetPetsResponse> GetPets(int year);
        void PostPet(PostPetRequest request);
    }
}
