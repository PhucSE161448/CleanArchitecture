using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain;

public class LeaveType : BaseEntity
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}
