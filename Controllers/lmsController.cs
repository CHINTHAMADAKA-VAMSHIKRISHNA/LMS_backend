using LMS.DTO;
using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [ApiController]
    [Route("/api/lms")]
    public class lmsController: ControllerBase
    {
        public AppDbContext _dbContext;

        public lmsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateCourse([FromBody] CourseRequest request)
        {
            Course course = new Course
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                CreatedDate = request.CreatedDate,
            };
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return Ok("successfuuly created course");

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseResponse>>> GetCourses([FromQuery] string? search, [FromQuery] int pageNumber = 1, [FromQuery] int pagesize= 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if(!string.IsNullOrWhiteSpace(search))
            {
                var searchItem = search.Trim().ToLower();
                var searchedResult = await _dbContext.Courses.Where(c => c.Title.ToLower().Contains(searchItem)).ToListAsync();
                return Ok(searchedResult);
            }

            var totalCount = await _dbContext.Courses.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (Double)pagesize);


            var result = await _dbContext.Courses.Skip((pageNumber-1) * pagesize).Take(pagesize
                ).Select(c => new CourseResponse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    CreatedDate = c.CreatedDate
                })
                .ToListAsync(); ;

            var response = new PagedResult<CourseResponse>
            {
                PageNumber = pageNumber,
                PageSize = pagesize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = result
            };

            return Ok(response);
        }

        //[HttpGet]
    };
}
