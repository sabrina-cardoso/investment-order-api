using InvestmentOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrder.Domain.Ports.Out;

    public interface IInvestmentOrderProducer
    {
        Task PublishAsync(Order order);
    }

