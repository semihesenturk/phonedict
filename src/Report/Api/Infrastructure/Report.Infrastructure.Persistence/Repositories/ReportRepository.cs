using Report.Application.Repositories;
using Report.Infrastructure.Persistence.Context;

namespace Report.Infrastructure.Persistence.Repositories;

public class ReportRepository : IReportRepository
{
    #region Variables
    private readonly ReportContext _reportContext;
    #endregion

    #region Constructor
    public ReportRepository(ReportContext reportContext)
    {
        _reportContext = reportContext;
    }
    #endregion

    public async Task<Domain.Models.Report> FindAsync(Guid id)
    {
        var result = _reportContext.Find<Domain.Models.Report>(id);

        return result;

    }

    public async Task<bool> CreateReport(Domain.Models.Report report)
    {
        await _reportContext.AddAsync(report);

        var save = await _reportContext.SaveChangesAsync();

        if (save > 0)
            return true;
        return false;
    }

    public async Task<bool> UpdateReport(Domain.Models.Report report)
    {
        var result = _reportContext.Update(report);

        var save = await _reportContext.SaveChangesAsync();

        if (save > 0)
            return true;
        return false;
    }
}
