using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Queries.GetAllLeaveTypes
{
    public class LeaveTypesDto  
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
