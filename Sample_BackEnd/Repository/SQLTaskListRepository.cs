using Microsoft.EntityFrameworkCore;
using Sample_BackEnd.Data;
using Sample_BackEnd.Models.Domain;

namespace Sample_BackEnd.Repository
{
    public class SQLTaskListRepository : TaskListRepository
    {
        private readonly SampleDbContext dbContext;

        public SQLTaskListRepository(SampleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TaskList> CreateAsync(TaskList tasklist)
        {
            await dbContext.TaskList.AddAsync(tasklist);
            await dbContext.SaveChangesAsync();
            return tasklist;
        }

        public async Task<TaskList?> DeleteAsync(string id)
        {
            var existingtask = await dbContext.TaskList.FirstOrDefaultAsync(x => x.TaskId == id);

            if (existingtask == null)
            {
                return null;
            }
            dbContext.TaskList.Remove(existingtask);
            await dbContext.SaveChangesAsync();
            return existingtask;
        }

        public async Task<List<TaskList>> GetAllAsync()
        {
            return await dbContext.TaskList.ToListAsync();
        }

        public async Task<TaskList?> GetByIdAsync(string id)
        {
            return await dbContext.TaskList.FirstOrDefaultAsync(x => x.TaskId == id);
        }

        public async Task<TaskList?> UpdateAsync(string id, TaskList tasklist)
        {
            var existingtask = await dbContext.TaskList.FirstOrDefaultAsync(x => x.TaskId == id);
            if (existingtask == null)
            {
                return null;
            }

            existingtask.Status = tasklist.Status;
            existingtask.AddedDate = tasklist.AddedDate;
            existingtask.Category = tasklist.Category;
            existingtask.AddedBy = tasklist.AddedBy;
            existingtask.RequestedBy = tasklist.RequestedBy;
            existingtask.AssignTo = tasklist.AssignTo;
            existingtask.ChatLink = tasklist.ChatLink;
            existingtask.CallBackNumber = tasklist.CallBackNumber;
            existingtask.UrgencyLevel = tasklist.UrgencyLevel;
            existingtask.ProjectIdentificationNumber = tasklist.ProjectIdentificationNumber;
            existingtask.Description = tasklist.Description;
            existingtask.Comment = tasklist.Comment;

            await dbContext.SaveChangesAsync();
            return existingtask;
        }
    }
}
