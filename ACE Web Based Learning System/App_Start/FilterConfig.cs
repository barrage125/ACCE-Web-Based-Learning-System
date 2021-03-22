using System.Web;
using System.Web.Mvc;

namespace ACE_Web_Based_Learning_System
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
