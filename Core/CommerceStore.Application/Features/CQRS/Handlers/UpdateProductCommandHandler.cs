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
    public class UpdateProductCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateProductCommand updateProductCommand)
        {
            var value = await _repository.GetById(updateProductCommand.ProductId);
            value.ProductName = updateProductCommand.ProductName;
            value.Price= updateProductCommand.Price;
            value.Stock= updateProductCommand.Stock;
            value.CategoryId= updateProductCommand.CategoryId;
            await _repository.UpdateAsync(value);
        }
    }
}
