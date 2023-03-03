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
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public PostController(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Request accepted at {0}", DateTime.Now);
            var result = await _unitOfWork.postRepository.GetAll().ToListAsync();
            _logger.LogWarning($"Request Successfully  completed at {DateTime.Now}, and result is {JsonSerializer.Serialize(result)}");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDto post)
        {
            if (ModelState.IsValid != true)
            {
                return BadRequest(ModelState);
            }

            Posts postdto = new()
            {
                Id = post.Id,
                Description = post.Description,
                Title = post.Title,
                Subtitle = post.Subtitle,
                CreationDate = DateTime.Now,
            };
            await _unitOfWork.postRepository.Add(postdto);
            await _unitOfWork.Commit();

            return Ok(postdto);

        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string title, string description)
        {
            var post= await _unitOfWork.postRepository.Find(id);

           post.Title = title;
            post.Description = description;
            await _unitOfWork.postRepository.Update(post);
            await _unitOfWork.Commit();
            return Ok(post);
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var result = await _unitOfWork.postRepository.Find(id);
                _logger.LogInformation($"Author got from db with Id of {id}");
                await _unitOfWork.postRepository.Delete(result);
                _logger.LogDebug($"Author deleted from db with Id of {id}");
                await _unitOfWork.Commit();
                _logger.LogInformation($"Request is completed successfully, Author with ID of {id} and name of {result.Title}");
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
