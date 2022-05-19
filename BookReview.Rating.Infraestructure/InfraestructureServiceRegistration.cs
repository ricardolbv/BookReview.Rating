using BookReview.Rating.Application.Contracts.Bus;
using BookReview.Rating.Infraestructure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Rating.Infraestructure
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services)
        {

            return services;
        }
    }
}
