

namespace Core.Models
{
    public class UsersReports
    {
       

        public string UserName { get; set; }
        public int Total { get; set; }
        public int FirstMeasure { get; set; }
        public int SecondMeasure { get; set; }
        public int ThirdMeasure { get; set; }
        public int FourthMeasure { get; set; }
        public int FiveMeasure { get; set; }

        public UsersReports()
        {
            
        }
        public UsersReports(string userName, int total)
        {
            UserName = userName;
            Total = total;
        }

        public UsersReports(string userName, int total, int firstMeasure, int secondMeasure, 
                             int thirdMeasure, int fourthMeasure, int fiveMeasure)
        {
            UserName = userName;
            Total = total;
            FirstMeasure = firstMeasure;
            SecondMeasure = secondMeasure;
            ThirdMeasure = thirdMeasure;
            FourthMeasure = fourthMeasure;
            FiveMeasure = fiveMeasure;
        }
    }
}
