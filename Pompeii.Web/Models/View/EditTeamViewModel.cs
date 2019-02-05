using System;
using System.ComponentModel.DataAnnotations;

namespace Pompeii.Web.Models.View
{
    public class EditTeamViewModel
    {
        [Required]
        [StringLength(32,MinimumLength = 3)]
        public string Name { get; set; }
    }

}
