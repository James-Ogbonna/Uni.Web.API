using Uni.Web.API.Common;
using Uni.Web.API.Common.Messaging;
using Uni.Web.API.Database;

namespace Uni.Web.API.Features.Students.Commands.DeleteStudent;

public sealed class Handler(ApplicationDbContext context) : ICommandHandler<Command>
    {
        public async Task<ServiceResponse> Handle(Command command, CancellationToken cancellationToken)
        {
            try
            {
                var student = await context.Students.FindAsync(command.StudentId, cancellationToken);
                if (student is null)
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Student not found."
                    };
                }
                
                context.Students.Remove(student);
                await context.SaveChangesAsync(cancellationToken);
                return new ServiceResponse
                {
                    Message = "Student deleted successfully."
                };
            }
            catch (Exception ex)
            {
                string message = $"{ex.Message} - [{ex.GetBaseException().Message}]";
                Console.WriteLine(message);
                return new ServiceResponse
                {
                    Success = false,
                    Message = message
                };
            }
        }
    }
