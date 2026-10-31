using Microsoft.EntityFrameworkCore;
using Uni.Web.API.Common;
using Uni.Web.API.Common.Messaging;
using Uni.Web.API.Database;

namespace Uni.Web.API.Features.Students.Queries.GetStudentById;

internal sealed class Handler(ApplicationDbContext context) : IQueryHandler<Query, Response>
{
    public async Task<ServiceResponse<Response>> Handle(Query query, CancellationToken cancellationToken)
    {
        var response = await context.Students
            .Where(s => s.Id == query.StudentId)
            .Select(student => new Response(
                student.Id, 
                student.RegNumber, 
                student.FirstName, 
                student.LastName, 
                student.DateOfBirth, 
                student.Email, 
                student.PhoneNumber, 
                student.EntrySession, 
                student.CurrentLevel, 
                student.DepartmentId))
            .SingleOrDefaultAsync(cancellationToken);

        if (response is null)
        {
            return new ServiceResponse<Response>
            {
                Success = false,
                Message = "Student not found."
            };
        }

        return new ServiceResponse<Response>
        {
            Data = response
        };
    }
}


