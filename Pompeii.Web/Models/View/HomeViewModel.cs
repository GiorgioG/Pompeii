using System.Collections.Generic;

namespace Pompeii.Web.Models.View
{
    public class HomeViewModel
    {
        public IEnumerable<ProjectSimpleViewModel> Projects { get; set; } = new List<ProjectSimpleViewModel>();
    }
}
