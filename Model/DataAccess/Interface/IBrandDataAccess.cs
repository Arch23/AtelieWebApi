using Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DataAccess.Interface
{
    public interface IBrandDataAccess
    {
        IEnumerable<Brand> Get();
        Brand Get(long id);
        long Insert(Brand model);
        bool Update(Brand model);
        bool Delete(long id);

        bool IdAlreadyExists(long id);
        bool TitleAlreadyExists(string title);
    }
}
