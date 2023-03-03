using Hometask4_patterns.Data.Entities;
using Hometask4_patterns.Dto;
using Hometask4_patterns.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Hometask4_patterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BlogController> _logger;


        public BlogController(IUnitOfWork unitOfWork, ILogger<BlogController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted at {0}", DateTime.Now);
            var result = await _unitOfWork.blogRepository.GetAll().ToListAsync();
            _logger.LogWarning($"Request Successfully  completed at {DateTime.Now}, and result is {JsonSerializer.Serialize(result)}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogDto blogdto)
        {
            if (ModelState.IsValid != true)
            {
                return BadRequest(ModelState);
            }

            Blog blog = new()
            {
                Id = blogdto.Id,
                Description = blogdto.Description,
                Name = blogdto.Name,
                PostsCount = blogdto.PostsCount,
            };
            await _unitOfWork.blogRepository.Add(blog);
            await _unitOfWork.Commit();

            return Ok(blog);

        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string Name, string description)
        {
            var blog = await _unitOfWork.blogRepository.Find(id);

            blog.Name = Name;
            blog.Description = description;
            await _unitOfWork.blogRepository.Update(blog);
            await _unitOfWork.Commit();
            return Ok(blog);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var result = await _unitOfWork.blogRepository.Find(id);
                _logger.LogInformation($"Author got from db with Id of {id}");
                await _unitOfWork.blogRepository.Delete(result);
                _logger.LogDebug($"Author deleted from db with Id of {id}");
                await _unitOfWork.Commit();
                _logger.LogInformation($"Request is completed successfully, Author with ID of {id} and name of {result.Name}");
                return Ok(result);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error occured when deleting the student ith id of {id}");
                throw ex;
            }

        }
    }
}
