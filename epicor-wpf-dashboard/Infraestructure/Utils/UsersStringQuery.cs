
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

        public static readonly string TOTAL_ACTIVE_BY_USERS_AND_RANGE = @"SELECT
                                                  ISNULL(Au.DisplayName,'ASIGNADA A QUEUE') AS [UserName],
                                                  SUM(CASE WHEN DATEDIFF(DAY, OpenDate, GETDATE()) BETWEEN 0 AND 2 THEN 1 ELSE 0 END) AS [0-2 días],
                                                  SUM(CASE WHEN DATEDIFF(DAY, OpenDate, GETDATE()) BETWEEN 3 AND 7 THEN 1 ELSE 0 END) AS [3-7 días],
                                                  SUM(CASE WHEN DATEDIFF(DAY, OpenDate, GETDATE()) BETWEEN 8 AND 15 THEN 1 ELSE 0 END) AS [8-15 días],
                                                  SUM(CASE WHEN DATEDIFF(DAY, OpenDate, GETDATE()) BETWEEN 16 AND 20 THEN 1 ELSE 0 END) AS [16-21 días],
                                                  SUM(CASE WHEN DATEDIFF(DAY, OpenDate, GETDATE()) >= 21 THEN 1 ELSE 0 END) AS [>21 días],
                                                  COUNT(*) AS Total
                                                FROM SupportCall AS Sc
                                                LEFT JOIN ApplicationUser AS Au ON Au.ApplicationUserID = Sc.AssignToUserID
                                                WHERE YEAR(Sc.OpenDate) >= 2020 AND SC.Closed=0 AND Au.DisplayName IS NOT NUll
                                                GROUP BY
                                                  Au.DisplayName
                                                ORDER BY Au.DisplayName";
    }
}
