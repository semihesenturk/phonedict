namespace Report.Application.Repositories;

public interface IReportRepository
{
    Task<Domain.Models.Report> FindAsync(Guid id);
    Task<bool> CreateReport(Domain.Models.Report report);
    Task<bool> UpdateReport(Domain.Models.Report report);
}
