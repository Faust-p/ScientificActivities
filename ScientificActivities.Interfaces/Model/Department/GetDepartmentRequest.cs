using ScientificActivities.Interfaces.Extensions.Pagination;

namespace ScientificActivities.Interfaces.Model.Department;

public class GetDepartmentRequest : IPaginationRequest
{
    public long? DepartmanetId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}