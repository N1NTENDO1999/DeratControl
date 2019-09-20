using DeratControl.Application.Interfaces;
using DeratControl.Application.Requests.Interfaces;
using DeratControl.Domain.Root;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Application.Traps.Queries.ViewTrapByPoint
{
    public class ViewTrapQuery : IRequest
    {
        public int PointId { get; set; }
    }

    public class ViewTrapQueryHandler : IQueryHandler<ViewTrapQuery, TrapViewModelResult>
    {
        private IUnitOfWork _unitofwork;

        public ViewTrapQueryHandler(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        public async Task<TrapViewModelResult> Handle(CommandExecutionContext executionContext, ViewTrapQuery request)
        {
            var point = await _unitofwork.PointRepository.FindByIdAsync(request.PointId);
            
            if(point.TrapId == null)
            {
                return new TrapViewModelResult() { Trap = null };
            }

            var trap = await _unitofwork.TrapRepository.FindByIdAsync((int)point.TrapId);

            return new TrapViewModelResult() { Trap = trap };
        }
    }
}
