using DeratControl.Domain.Root.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeratControl.Domain.Root
{
    public interface IUnitOfWork : IDisposable
    {
        IFacilityRepository FacilityRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        IPerimeterRepository PerimeterRepository { get; }
        IPointRepository PointRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ITrapRepository TrapRepository { get; }
        ITrapReviewRepository TrapReviewRepository { get; }
        IUserRepository UserRepository { get; }

        Task Commit();
    }
}
