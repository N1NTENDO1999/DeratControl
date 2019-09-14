﻿using System;
using DeratControl.Domain.Entities;

namespace DeratControl.Domain.Root.Repositories
{
    public interface IFacilityRepository : IRepository<Facility, int>
    {
        bool IsExists(Facility facility);

        bool IsInclude(Perimeter perimeter);

        void Save();
    }
}
