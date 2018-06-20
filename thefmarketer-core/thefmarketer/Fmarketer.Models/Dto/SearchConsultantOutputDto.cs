using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fmarketer.Models.Dto
{
    public class SearchConsultantOutputDto
    {
        public List<Consultant> Consultants { get; set; }

        public SearchConsultantOutputDto(List<Consultant> consultants)
        {
            Consultants = consultants;
        }
    }
}
