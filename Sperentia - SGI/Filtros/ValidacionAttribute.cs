using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sperientia___SGI.Filtros
{

    public class ValidacionAttribute : Attribute, IFilterFactory
    {
        public bool IsReusable => false;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetRequiredService<Validacion>();
            return serviceProvider.GetRequiredService<ValidarAdmin>();
        }
    }

}
