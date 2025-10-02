using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChungTrinhj.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee employee { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> employeeList { get; set; }
    }
}
