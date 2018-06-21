using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fmarketer.Models.Dto
{
    public class SearchRequestOutputDto
    {
        public List<Request> Requests { get; set; }

        public SearchRequestOutputDto(List<Request> requests)
        {
            Requests = requests;
        }
    }
}
