using AutoMapper;
using Sample_BackEnd.Models.Domain;
using Sample_BackEnd.Models.DTO;

namespace Sample_BackEnd.Mapper
{
    public class TaskListAutoMapper : Profile

    {
        public TaskListAutoMapper()
        {
            CreateMap<TaskList, TaskListDTO>().ReverseMap();
            CreateMap<AddTaskRequestDTO, TaskList>().ReverseMap();
            CreateMap<UpdateTaskRequestDTO, TaskList>().ReverseMap();
        }
    }
}
