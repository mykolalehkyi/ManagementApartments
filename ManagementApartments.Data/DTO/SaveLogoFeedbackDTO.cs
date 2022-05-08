using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.DTO
{
    public class SaveImageFeedbackDTO : BaseFeedbackDTO
    {
        public string LogoAsBase64 { get; set; }
    }
}
