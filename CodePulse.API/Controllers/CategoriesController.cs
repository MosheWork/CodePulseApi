﻿using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodePulse.API.Controllers
{
    //https://localhost:xxxx/api/categories
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;   

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }




        // post   https://localhost:7121/api/Categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryRequestDto request)
        {
            //map DTO to domain model

            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

           await categoryRepository.CreateAsync(category);  

            // Domain model to DTO

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            
            return Ok(response);
        }

        //GET:https://localhost:7121/api/Categories

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            //order of things to do
            //repositories>>interface>>implementation

             var caterogies = await categoryRepository.GetAllAsync();

            // mpa domain model to DTO
            var response = new List<CategoryDTO>();        
            foreach (var category in caterogies)
            {
                response.Add(new CategoryDTO { Id = category.Id, Name = category.Name, UrlHandle = category.UrlHandle });
            }
            return Ok(response);
        }

        //GET: https://localhost:7121/api/Categories/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]Guid id)
        {
         var existingCategory = await categoryRepository.GetById(id);

            if(existingCategory is null)
            {
                return NotFound();
            }

            var response= new CategoryDTO { Id = existingCategory.Id, Name = existingCategory.Name, UrlHandle = existingCategory.UrlHandle };
            return Ok(response);    
        }

        // PUT : https://localhost:7121/api/Categories/{id}

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditCategory([FromRoute]Guid id , UpdateCategoryRequestDto requset)
        {
            //convert dto to domain model

            var category = new Category { Id = id, Name = requset.Name, UrlHandle = requset.UrlHandle };
            category = await categoryRepository.UpdateAsynce(category);

            if(category == null)
            {
                return NotFound();
            }
            //convert domain model to dto

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);    
        }


        //DELETE https://localhost:7121/api/Categories/{id}

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var category = await categoryRepository.DeleAsync(id);
            if(category == null)
            {
                return NotFound();
            }
            //conver domain

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(response);    
        }

    }
}
