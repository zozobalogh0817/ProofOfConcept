using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Logging;
using Serialize.Linq.Serializers;

namespace WebApplication
{
    [ODataRoutePrefix("person")]
    public class Controller : ODataController
    {
        private readonly ILogger<Controller> _logger;

        public Controller(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("")]
        public Task<IEnumerable<person>> GetList(ODataQueryOptions<person> options)
        {
            var proxy = (IQueryable)Enumerable.Empty<person>().AsQueryable();
            proxy = (IQueryable) options.ApplyTo(proxy);
            // var serializer = new ExpressionSerializer(new JsonSerializer());
            // _logger.LogInformation(serializer.SerializeText(proxy.Expression));

            var array = new List<person>()
            {
                new person
                {
                    personid = 1,
                    name = "Laci",
                    addresses = new List<address>()
                    {
                        new address
                        {
                            id = 0,
                            number = 18,
                            street = "huba utca"
                        },
                        new address
                        {
                            id = 1,
                            number = 18,
                            street = "huba utca"
                        },
                        new address
                        {
                            id = 2,
                            number = 18,
                            street = "huba utca"
                        }
                    }
                },
                new person
                {
                    name = "Zoli",
                    personid = 1,
                    addresses = new List<address>
                    {
                        new address
                        {
                            id = 3,
                            number = 35,
                            street = "Mandarin utaca"
                        }
                    }
                }
            };

            var queryable = (IQueryable<person>) options.ApplyTo(array.AsQueryable());


            return Task.FromResult(queryable.AsEnumerable());
        }
    }
}