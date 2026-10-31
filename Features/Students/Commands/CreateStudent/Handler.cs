using Microsoft.EntityFrameworkCore;
using Uni.Web.API.Features.Students;
using Uni.Web.API.Common;
using Uni.Web.API.Common.Messaging;
using Uni.Web.API.Database;

namespace Uni.Web.API.Features.Students.Commands.CreateStudent;

internal sealed class Handler(ApplicationDbContext context) : ICommandHandler<Command, Guid>
{
    public async Task<ServiceResponse<Guid>> Handle(Command command, CancellationToken cancellationToken)
    {
        try
        {
            if (await context.Students.AnyAsync(s => s.RegNumber == command.RegNumber, cancellationToken))
            {
                return new ServiceResponse<Guid>
                {
                    Success = false,
                    Message = "A student with this registration number already exists."
                };
            }

            var student = new Student
            {
                Id = Guid.NewGuid(),
                RegNumber = command.RegNumber,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                EntrySession = command.EntrySession,
                CurrentLevel = command.Currentevel,
                DepartmentId = command.DepartmentId
            };

            context.Students.Add(student);
            await context.SaveChangesAsync(cancellationToken);

            return new ServiceResponse<Guid>
            {
                Data = student.Id
            };
        }
        catch (Exception ex)
        {
            string message = $"{ex.Message} - [{ex.GetBaseException().Message}]";
            Console.WriteLine(message);
            return new ServiceResponse<Guid>
            {
                Success = false,
                Message = message
            };
        }
    }
}