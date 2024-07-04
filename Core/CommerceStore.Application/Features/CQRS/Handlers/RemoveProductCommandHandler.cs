using CommerceStore.Application.Features.CQRS.Commands.Category;
using CommerceStore.Application.Features.CQRS.Commands.Product;
using CommerceStore.Application.Interfaces;
using CommerceStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Application.Features.CQRS.Handlers
{
    public class RemoveProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveProductCommand removeProductCommand)
        {
            await _repository.DeleteAsync(removeProductCommand.ProductId);
        }
    }
}
