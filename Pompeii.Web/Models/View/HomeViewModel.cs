using System.Collections.Generic;

namespace Pompeii.Web.Models.View
{
    public class HomeViewModel
    {
        public string Name { get; set; } = "Test!!!";

        public IEnumerable<TeamViewModel> Teams { get; set; } = new List<TeamViewModel>();
    }
}
