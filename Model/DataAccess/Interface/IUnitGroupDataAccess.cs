﻿using Model.Entity;
using System.Collections.Generic;

namespace Model.DataAccess.Interface
{
    public interface IUnitGroupDataAccess
    {
        IEnumerable<UnitGroup> Get();
        UnitGroup Get(long id);
        long Insert(UnitGroup model);
        bool Update(UnitGroup model);
        bool Delete(long id);
    }
}