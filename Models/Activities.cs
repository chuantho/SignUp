using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUp.Models
{
    public class Activities
    {
        public List<Activity> AvailableActivities { get; set; } = new List<Activity>();
    }
}
