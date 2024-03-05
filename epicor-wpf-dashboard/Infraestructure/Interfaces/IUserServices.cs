

using Core.Models;
using System.Collections.Generic;

namespace Infraestructure.Interfaces
{
    public  interface IUserServices
    {
        List<UsersReports> TotalOpenReportsByUsers();
    }
}
