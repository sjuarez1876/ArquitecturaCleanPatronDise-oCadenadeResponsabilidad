using ApiCleanArchitecture.Core.Entities;
using ApiCleanArchitecture.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCleanArchitecture.Application
{

    public interface ICarCompanyHandler
    {
        Task HandleAsync(CarCompany carCompany);
    }

    public class CreateCarCompanyHandler : ICarCompanyHandler
    {
        private readonly ICarCompanyRepository _repository;
        private readonly ICarCompanyHandler _nextHandler;

        public CreateCarCompanyHandler(ICarCompanyRepository repository, ICarCompanyHandler nextHandler = null)
        {
            _repository = repository;
            _nextHandler = nextHandler;
        }

        public async Task HandleAsync(CarCompany carCompany)
        {
            await _repository.AddAsync(carCompany);

            if (_nextHandler != null)
                await _nextHandler.HandleAsync(carCompany);
        }
    }

    public class UpdateCarCompanyHandler : ICarCompanyHandler
    {
        private readonly ICarCompanyRepository _repository;
        private readonly ICarCompanyHandler _nextHandler;

        public UpdateCarCompanyHandler(ICarCompanyRepository repository, ICarCompanyHandler nextHandler = null)
        {
            _repository = repository;
            _nextHandler = nextHandler;
        }

        public async Task HandleAsync(CarCompany carCompany)
        {
            await _repository.UpdateAsync(carCompany);

            if (_nextHandler != null)
                await _nextHandler.HandleAsync(carCompany);
        }
    }

    public class DeleteCarCompanyHandler : ICarCompanyHandler
    {
        private readonly ICarCompanyRepository _repository;
        private readonly ICarCompanyHandler _nextHandler;

        public DeleteCarCompanyHandler(ICarCompanyRepository repository, ICarCompanyHandler nextHandler = null)
        {
            _repository = repository;
            _nextHandler = nextHandler;
        }

        public async Task HandleAsync(CarCompany carCompany)
        {
            await _repository.DeleteAsync(carCompany.Id);

            if (_nextHandler != null)
                await _nextHandler.HandleAsync(carCompany);
        }

    }

}