using NorthWind.UseCasesDTOs.CreateOrder;
using NorthWind.UseCases.Common.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.UseCases.CreateOrder
{
    public class CreateOrderInputPort : IInputPort<CreateOrderParams, int>
    {

        public CreateOrderParams RequestData {get; }
     
        public IOutputPort<int> OutputPort { get; }

        public CreateOrderInputPort(CreateOrderParams requestData,
            IOutputPort<int> outputPort) =>
            (RequestData, OutputPort) = (requestData, outputPort);IOutputPort
              
    }
}
