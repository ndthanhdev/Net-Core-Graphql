using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphiqlNetCore.Graphql;
using GraphQL.Types;
using GraphiqlNetCore.Graphql.Queries;
using GraphQL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphiqlNetCore
{
    [Route("[controller]")]
    public class GraphQlController : Controller
    {
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            var schema = new Schema { Query = new StarWarsQuery() };

            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = schema;
                x.Query = query.Query;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
