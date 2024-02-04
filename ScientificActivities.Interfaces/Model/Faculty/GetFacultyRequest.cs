using ScientificActivities.Interfaces.Extensions.Pagination;

namespace ScientificActivities.Interfaces.Model.Faculty;

public class GetFacultyRequest : IPaginationRequest
{
    public Page Page { get; set; } = new Page();
}