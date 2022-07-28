using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace UserApi
{
    public  class ActionFilter :Attribute, IActionFilter
    {
        private string v;

        public ActionFilter(string v)
        {
            this.v = v;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var param = context.HttpContext.Request.Headers["Role"];
            if (param == v)
            {
                return;

            }
            else
            {
                context.Result=new BadRequestObjectResult("Bad Key");
                return;

            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
