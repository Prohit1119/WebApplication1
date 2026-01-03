using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCoreTagHelpers1.Models
{
    public class Country
    {
        public string City { get; set; }

     public   List<SelectListItem> LstCity { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value="C1",Text="Delhi"},
                  new SelectListItem { Value = "C2", Text = "Kolkata" },
          new SelectListItem { Value = "C3", Text = "Mumbai"  },
      new SelectListItem { Value = "C4", Text = "Chennai"  },
      new SelectListItem { Value = "C5", Text = "Bengaluru"  },
      new SelectListItem { Value = "C6", Text = "Hyderabad"}

        };
    }
}
