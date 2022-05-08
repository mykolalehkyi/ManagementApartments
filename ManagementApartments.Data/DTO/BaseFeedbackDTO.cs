using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.DTO
{
    public class BaseFeedbackDTO
    {
        public bool StatusSuccess { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }
    }
}
