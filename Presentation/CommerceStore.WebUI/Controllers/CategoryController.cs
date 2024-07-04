using CommerceStore.Application.Features.CQRS.Commands.Category;
using CommerceStore.Application.Features.CQRS.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CommerceStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _categoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _categoryQueryHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoryController(CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, GetCategoryByIdQueryHandler categoryByIdQueryHandler, GetCategoryQueryHandler categoryQueryHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _categoryByIdQueryHandler = categoryByIdQueryHandler;
            _categoryQueryHandler = categoryQueryHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryQueryHandler.Handle();
            return View(values);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCategoryCommandHandler.Handle(createCategoryCommand);
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _categoryByIdQueryHandler.Handle(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return RedirectToAction("CategoryList");
        }
    }
}
