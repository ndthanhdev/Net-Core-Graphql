using GraphiqlNetCore.Graphql.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphiqlNetCore.Graphql.Queries
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery()
        {
            Field<DroidType>("hero", resolve: context => new Droid { Id = 1, Name = "R2-D2" });
            Field<PersonType>("person", resolve: context => new Person { Id = 1, Name = "Mr Happy", Age = 32 });

            // Field<PersonType>("person", resolve: context => new Person { Id = 5, FirstName = "Joe", Surname = "Woodward", Age = 32 });
        }
    }
}
