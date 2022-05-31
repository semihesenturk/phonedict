using MediatR;
using PhoneDict.Common.Models.Enums;

namespace PhoneDict.Common.Models.RequestModels;

public class CreateReportCommand : IRequest<bool>
{
    #region Constructor
    public CreateReportCommand(Location location)
    {
        Location = location;
    }
    #endregion

    public Location Location { get; set; }
}
