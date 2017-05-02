using System.Web.Configuration;

namespace Semi_Webshop.services
{
    public class SettingsService : ISettingsService
    {
        protected int? pageSize = null;
        public int PageSize
        {
            get
            {
                if (!pageSize.HasValue)
                {
                    int pageSizeAux;
                    if (int.TryParse(WebConfigurationManager.AppSettings["settings:paginationPageSize"], out pageSizeAux))
                        pageSize = pageSizeAux;
                    else
                        pageSize = 10;
                }

                return pageSize.Value;
            }
        }
    }
}