using Jhuri.Data;
using Jhuri.Models.Admin;
using Jhuri.Repository;
using Jhuri.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jhuri.ViewComponents
{
    public class GetHeaderMainMenuViewComponent:ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _Context;

        public GetHeaderMainMenuViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync(int categoryId = 0)
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            if (categoryId > 0)
            {
                categories = await GetLists(categoryId);
                return View("SubMenu", categories.OrderBy(x => x.Name).ToList());
            }
            else
            {
                categories = await GetLists();
                return View("MainMenu", categories.OrderBy(x => x.Name).ToList());
            }
        }

        private Task<List<CategoryViewModel>> GetLists(int categoryId = 0)
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            if(categoryId > 0)
            {
                _unitOfWork.Repository<Category>().GetAll().Where(x => x.CategoryId == categoryId).ToList().ForEach(a =>
               {
                   CategoryViewModel category = new CategoryViewModel
                   {
                       Id = a.Id,
                       Name = a.Name,
                   };
                   categories.Add(category);
               });
                return Task.Run(() => categories);
            }
            else
            {
                _unitOfWork.Repository<Category>().GetAll().Where(x => x.CategoryId == null).ToList().ForEach(c =>
                {
                    CategoryViewModel category = new CategoryViewModel
                    {
                        Id = c.Id,
                        Name = c.Name
                    };
                    categories.Add(category);
                });

                return Task.Run(() => categories);

            }
        }
    }
}
