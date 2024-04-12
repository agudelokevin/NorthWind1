using System;
using NorthWind.UseCases.Common.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Presenters
{
    public interface IPresenter<ResponseType,FormatType>: IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}
