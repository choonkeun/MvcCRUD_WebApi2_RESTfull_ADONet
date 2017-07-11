using System.Web;
using System.Web.Mvc;

namespace MvcCRUD_RESTFull_Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
