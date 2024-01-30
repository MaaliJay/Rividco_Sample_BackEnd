using Sample_BackEnd.Models.Domain;

namespace Sample_BackEnd.Repository
{
    public interface TaskListRepository
    {
        Task<List<TaskList>> GetAllAsync();
        Task<TaskList?> GetByIdAsync(string id);                     //TaskList? -> can be null
        Task<TaskList> CreateAsync(TaskList tasklist);
        Task<TaskList?> UpdateAsync(string id, TaskList tasklist);   //TaskList? -> can be null
        Task<TaskList?> DeleteAsync(string id);                      //TaskList? -> can be null
    } 
}
