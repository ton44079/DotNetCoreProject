using System;
using System.Collections;
using System.Collections.Generic;
using ArcAPI.EFCore;
using ArcAPI.EFCore.Entities;
using ArcAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ArcAPI.Repository.Implements
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : DbSet<T>
    {
        internal BloggingContext _context;
        internal DbSet<T> _dbSet;

        public GenericRepository(BloggingContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        //    _dbSet.AddAsync()
        }
    }
}
