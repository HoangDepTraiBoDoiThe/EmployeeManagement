using EmployeeManagement.Context;
using EmployeeManagement.models.EmployeeTables;
using EmployeeManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Service;

public class JobService(MyIdentityDbContext dbContext) : IJobService
{
    public async Task CreateNewJob(Job job)
    {
        await dbContext.Jobs.AddAsync(job);
        await dbContext.SaveChangesAsync();
    }

    public async Task CreateNewJobs(IEnumerable<Job> jobs)
    {
        await dbContext.Jobs.AddRangeAsync(jobs);
        await dbContext.SaveChangesAsync();
    }

    public Task<bool> IsJobsEmpty()
    {
        return dbContext.Jobs.AnyAsync();
    }
}