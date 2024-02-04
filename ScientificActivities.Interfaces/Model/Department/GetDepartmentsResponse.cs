using ScientificActivities.Interfaces.Extensions.Pagination;

namespace ScientificActivities.Interfaces.Model.Department;

public class GetDepartmentsResponse : IPaginationResponse<DepartmentModel>
{
    public Page Page { get; set; } = new Page();

    public long Count { get; set; }

    public IReadOnlyCollection<DepartmentModel> Items { get; set; }
}