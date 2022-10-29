using CalibrationTracking.Desktop.Base;
using System.Linq;

namespace CalibrationTracking.Desktop.Main.ViewModels
{
    public class DashboardViewModel :  BaseViewModel
    {
        public int TotalPlayers { get; set; } = 12;
        public int TotalTeams { get; set; } = 12;
        public int TotalGoals { get; set; } = 13;
       
    }
}
