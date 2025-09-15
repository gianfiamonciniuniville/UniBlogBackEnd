using Microsoft.EntityFrameworkCore;
using UniBlog.Domain.Entities;
using UniBlog.Domain.Exceptions;
using UniBlog.Domain.Interfaces;

namespace UniBlog.Infrastructure.Repositories;

public class Repository<T>(UniBlogDbContext context) : IRepository<T> where T : Entity
{
    protected readonly UniBlogDbContext _context = context;

    public T Create(T entity)
    {
        entity.Created = DateTime.UtcNow;
        _context.Set<T>().Add(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return entity;
    }

    public T Get(int id)
    {
        return _context.Set<T>().Find(id) ?? throw new EntityNotFoundException(typeof(T).Name, id);
    }

    public IEnumerable<T> GetAll()
    {
        return [.. _context.Set<T>().AsNoTracking()];
    }

    public T Update(T entity)
    {
        entity.Updated = DateTime.UtcNow;
        _context.Set<T>().Update(entity);
        return entity;
    }
}