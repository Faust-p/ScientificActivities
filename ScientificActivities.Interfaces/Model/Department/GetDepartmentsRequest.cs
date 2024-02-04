using ScientificActivities.Interfaces.Extensions.Pagination;

namespace ScientificActivities.Interfaces.Model.Department;

public class GetDepartmentsRequest : IPaginationRequest
{
    public long? FacultyId { get; set; } = null;

    public Page Page { get; set; } = new Page();
}