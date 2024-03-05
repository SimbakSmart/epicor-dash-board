
namespace Infraestructure.Utils
{
    public class UsersStringQuery
    {
        public static readonly string TOTAL_ACTIVE_BY_USERS = @"SELECT 
                                                AU.DisplayName AS UserName,
                                                COUNT(*) AS Total
                                                FROM SupportCall AS SC
                                                LEFT JOIN ApplicationUser AS AU  ON AU.ApplicationUserID = SC.AssignToUserID
                                                WHERE Closed =0 AND YEAR(OpenDate) >= 2020  AND AU.DisplayName IS NOT NULL
                                                GROUP BY AU.DisplayName ORDER BY TOTAL DESC ";
    }
}
