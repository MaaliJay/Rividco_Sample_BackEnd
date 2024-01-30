using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample_BackEnd.Data;
using Sample_BackEnd.Models.Domain;
using Sample_BackEnd.Models.DTO;
using Sample_BackEnd.Repository;
using System.Threading.Tasks;

namespace Sample_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly SampleDbContext sampleDbContext;
        private readonly TaskListRepository taskListRepository;
        private readonly IMapper mapper;

        public TasksController(SampleDbContext sampleDbContext , TaskListRepository taskListRepository, IMapper mapper)
        {
            this.sampleDbContext = sampleDbContext;
            this.taskListRepository = taskListRepository;
            this.mapper = mapper;
        }

        //Get all
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from domain model.
            var tasklistDomain = await taskListRepository.GetAllAsync();

            //Map domain model to DTO
            var tasklistDto = mapper.Map<List<TaskListDTO>>(tasklistDomain);

            return Ok(tasklistDto);
        }


        //Get by id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id) {
            var tasklistDomain = await taskListRepository.GetByIdAsync(id);
            if (tasklistDomain == null)
            {
                return NotFound();
            }
            //Map domain model to DTO
            var tasklistDto = mapper.Map<TaskListDTO>(tasklistDomain);
            return Ok(tasklistDto);
        }


        //Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTaskRequestDTO addTaskRequestDTO) {
            //Map domain DTO to model
            var tasklistDomain = mapper.Map<TaskList>(addTaskRequestDTO);

            //Use domain model to create in database
            tasklistDomain = await taskListRepository.CreateAsync(tasklistDomain);

            //Map domain model back to DTO
            var tasklistDto = mapper.Map<TaskListDTO>(tasklistDomain);

            return CreatedAtAction(nameof(GetById), new { id = tasklistDto.TaskId}, tasklistDto);
        }


        //Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateTaskRequestDTO updateTaskRequestDTO)
        {

            //Map DTO to domain model
            var tasklistDomain = mapper.Map<TaskList>(updateTaskRequestDTO);

            //check if Task exist
            tasklistDomain = await taskListRepository.UpdateAsync(id, tasklistDomain);
            if (tasklistDomain == null)
            {
                return NotFound();
            }

            //Map domain model to DTO
            var tasklistDto = mapper.Map<TaskListDTO>(tasklistDomain);
            return Ok(tasklistDto);
        }


        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id) {
            var tasklistDomain = await taskListRepository.DeleteAsync(id);
            if (tasklistDomain == null)
            {
                return NotFound();
            }

            //Map domain Model to DTO
            var tasklistDto = mapper.Map<TaskListDTO> (tasklistDomain);
            return Ok(tasklistDto);
        }

    }
}
