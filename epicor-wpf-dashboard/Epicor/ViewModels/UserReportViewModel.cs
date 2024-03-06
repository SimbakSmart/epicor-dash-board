

using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using CommunityToolkit.Mvvm.ComponentModel;
using Core.Models;
using System.Collections.Generic;
using Infraestructure.Interfaces;
using Infraestructure.Services;
using System.Linq;

namespace Epicor.ViewModels
{
    public class UserReportViewModel : ObservableObject
    {
        public List<UsersReports> ListRange { get; private set; }
        public ISeries[] Series { get; private set; }
        public Axis[] XAxes { get; private set; }
        private List<UsersReports> _list = null;
        private ColumnSeries<double> _userSeries;

      //  private ObservableObject<List<UsersReports>> _listRange= null;

        public UserReportViewModel()
        {
            LoadBarGraph();
            GetRange();
        }
        private void LoadBarGraph()
        {
             IUserServices  us = new UserServices();
            _list = us.TotalOpenReportsByUsers();

            _userSeries = new ColumnSeries<double>()
            {
                Name = "Reportes Activos",
                Values = _list.Select(user => (double)user.Total).ToList(),
                Padding = 1,
                MaxBarWidth = double.PositiveInfinity,
             
            };


            Axis _axis = new Axis()
            {
                Labels = _list.Select(user => user.UserName).ToList(),
                LabelsAlignment = LiveChartsCore.Drawing.Align.Start,
                IsVisible = false
            };

            Series = new ISeries[] { _userSeries };
            XAxes = new Axis[] { _axis };
           


        }
        private void GetRange()
        {
            IUserServices us = new UserServices();
            ListRange = us.TotalOpenReportsByUsersAndRange();

        }



    }
}
