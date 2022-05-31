namespace Report.Application.Repositories;

public interface IReportRepository
{
    Task<bool> CreateReport(Domain.Models.Report report);
    Task<bool> UpdateReport(Domain.Models.Report report);
}
