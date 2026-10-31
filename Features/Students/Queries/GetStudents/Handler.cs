using Microsoft.EntityFrameworkCore;
using Uni.Web.API.Common;
using Uni.Web.API.Common.Messaging;
using Uni.Web.API.Database;

namespace Uni.Web.API.Features.Students.Queries.GetStudents;

internal sealed class Handler(ApplicationDbContext context) : IQueryHandler<Query, List<Response>>
{
    public async Task<ServiceResponse<List<Response>>> Handle(Query query, CancellationToken cancellationToken)
    {
        var students = context.Students.AsQueryable();

        if (query.DepartmentId.HasValue)
        {
            students = students.Where(s =>
                s.DepartmentId == query.DepartmentId.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.EntrySession))
        {
            students = students.Where(s =>
                s.EntrySession == query.EntrySession);
        }

        if (query.CurrentLevel.HasValue)
        {
            students = students.Where(s =>
                s.CurrentLevel == query.CurrentLevel.Value);
        }
        
        var response = await students
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
            .ToListAsync(cancellationToken);

        return new ServiceResponse<List<Response>>
        {
            Data = response
        };
    }
}
