using Microsoft.EntityFrameworkCore;
using Uni.Web.API.Common;
using Uni.Web.API.Common.Messaging;
using Uni.Web.API.Database;

namespace Uni.Web.API.Features.Schools.Commands.GetSchools;

internal sealed class Handler(ApplicationDbContext context) : ICommandHandler<Command, List<Response>>
{
    public async Task<ServiceResponse<List<Response>>> Handle(Command command, CancellationToken cancellationToken)
    {
        try
        {
            var students = context.Students.AsQueryable();

            if (command.StudentId.HasValue)
            {
                students = students.Where(s =>
                    s.Id == command.StudentId.Value);
            }

            if (!string.IsNullOrWhiteSpace(command.RegNumber))
            {
                students = students.Where(s =>
                    s.RegNumber == command.RegNumber);
            }

            if (!string.IsNullOrWhiteSpace(command.Email))
            {
                students = students.Where(s =>
                    s.Email == command.Email);
            }

            if (command.DepartmentId.HasValue)
            {
                students = students.Where(s =>
                    s.DepartmentId == command.DepartmentId.Value);
            }

            if (!string.IsNullOrWhiteSpace(command.EntrySession))
            {
                students = students.Where(s =>
                    s.EntrySession == command.EntrySession);
            }

            if (command.CurrentLevel.HasValue)
            {
                students = students.Where(s =>
                    s.CurrentLevel == command.CurrentLevel.Value);
            }

            // Student -> Department -> School
            var response = await (
                    from student in students
                    join department in context.Departments
                        on student.DepartmentId equals department.Id
                    join school in context.Schools
                        on department.SchoolId equals school.Id
                    select new Response(
                        school.Id,
                        school.Name,
                        school.Abbr))
                .Distinct()
                .ToListAsync(cancellationToken);

            if (response.Count == 0)
            {
                return new ServiceResponse<List<Response>>
                {
                    Success = false,
                    Message = "No school found for the given student information."
                };
            }

            return new ServiceResponse<List<Response>>
            {
                Data = response
            };
        }
        catch (Exception ex)
        {
            string message = $"{ex.Message} - [{ex.GetBaseException().Message}]";
            Console.WriteLine(message);
            return new ServiceResponse<List<Response>>
            {
                Success = false,
                Message = message
            };
        }
    }
}
