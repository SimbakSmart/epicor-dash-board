

namespace Core.Models
{
    public class UsersReports
    {
       

        public string UserName { get; set; }
        public int Total { get; set; }

        public UsersReports()
        {
            
        }
        public UsersReports(string userName, int total)
        {
            UserName = userName;
            Total = total;
        }
    }
}
