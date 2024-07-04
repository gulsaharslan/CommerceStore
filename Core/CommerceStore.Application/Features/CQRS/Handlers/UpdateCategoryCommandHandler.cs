using CommerceStore.Application.Features.CQRS.Commands.Category;
using CommerceStore.Application.Interfaces;
using CommerceStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerceStore.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var value = await _repository.GetById(updateCategoryCommand.CategoryId);
            value.CategoryName = updateCategoryCommand.CategoryName;
            await _repository.UpdateAsync(value);
        }
    }
}
