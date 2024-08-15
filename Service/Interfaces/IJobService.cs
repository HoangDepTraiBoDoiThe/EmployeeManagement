using EmployeeManagement.models.EmployeeTables;

namespace EmployeeManagement.Service.Interfaces;

public interface IJobService
{
    Task CreateNewJob(Job job);
    Task CreateNewJobs(IEnumerable<Job> jobs);
    Task<bool> IsJobsEmpty();
}