using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.DTOs.NotificationDTOs
{
    public class showNotificationDTO
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
