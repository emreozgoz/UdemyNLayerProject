using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    public class Service<Tentity> : IService<Tentity> where Tentity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tentity> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<Tentity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<Tentity> AddAsync(Tentity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<Tentity>> AddRangeAsync(IEnumerable<Tentity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(Tentity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<Tentity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<Tentity> SingleOrDefaultAsync(Expression<Func<Tentity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public Tentity Update(Tentity entity)
        {
            Tentity updateEntity = _repository.Update(entity);
            _unitOfWork.Commit();
            return updateEntity;


        }

        public async Task<IEnumerable<Tentity>> Where(Expression<Func<Tentity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }
    }
}
