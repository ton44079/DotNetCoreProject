using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ArcAPI.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : DbSet<T>
    { 
    }
}
