using Kolokwium2_poprawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2_poprawa.DTO.Responses
{
    public class GetPetsResponse
    {
        public Pet Pet { get; set; }
        public IList<Volunteer> Volunteers { get; set; }
    }
}
