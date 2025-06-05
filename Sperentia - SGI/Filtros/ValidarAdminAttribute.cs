using Microsoft.AspNetCore.Mvc.Filters;

namespace Sperientia___SGI.Filtros
{
    public class ValidarAdminAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<ValidarAdmin>();
        }
    }

}
