using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrder.Domain.Dtos.Investor;

public class InvestorRequestDto
{
    public string Name { get; set; }
    public string Document { get; set; }
    public InvestorProfile Profile { get; set; }
}

