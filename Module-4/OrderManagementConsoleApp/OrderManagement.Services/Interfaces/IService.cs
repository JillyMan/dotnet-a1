﻿using OrderManagement.DataAccess.Contract.Models;
using System.Collections.Generic;

namespace OrderManagement.Services.Interfaces
{
    public interface IService<T>
    {
        T GetById(int id);

        IList<T> GetCollection();

        T Create(T obj);

        void Update(T obj);

        void Delete(int id);
    }
}
