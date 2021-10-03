using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IoTSharp.Handlers
{
    //主要用于测试，绕过其他验证规则
    public class IotSharpAuthorizationHandler : AuthorizationHandler<IotSharpAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IotSharpAuthorizationRequirement requirement)
        {
            context.Succeed(requirement);
            foreach (var pendingRequirement in context.PendingRequirements)
            {
                context.Succeed(pendingRequirement);
            }
            return Task.CompletedTask;
        }
    }

    public class IotSharpAuthorizationRequirement : IAuthorizationRequirement
    {

    }
}