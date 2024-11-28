using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEMB_BLAB.Function
{
    public static class TagHelper
    {
        //public static string GenerateId()
        //{
        //    Random rnd = new Random();
        //    rnd.Next(10000, 99999);
        //    return "SKILL-ISSUE-" + rnd.Next();
        //}
        public static string IsActive(this IHtmlHelper helper, string controller, string action)
        {
            ViewContext context = helper.ViewContext;

            RouteValueDictionary values = context.RouteData.Values;

            string _controller = values["controller"].ToString();

            string _action = values["action"].ToString();

            if ((action == _action) && (controller == _controller))
            {
                return "active";
            }
            else
            {
                return "";
            }
        }

        public static string IsMenuopen(this IHtmlHelper helper, string controller, string action)
        {
            ViewContext context = helper.ViewContext;

            RouteValueDictionary values = context.RouteData.Values;
            string _controller = values["controller"].ToString();

            string _action = values["action"].ToString();
            if ((action == _action) && (controller == _controller))
            {
                return "menu-open";
            }
            else
            {
                return "";
            }
        }
    }


}
