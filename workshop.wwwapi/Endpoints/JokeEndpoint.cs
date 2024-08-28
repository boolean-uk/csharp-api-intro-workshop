using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;

namespace workshop.wwwapi.Endpoints
{
    public static class JokeEndpoint
    {
        public static void ConfigureJokeEndpoint(this WebApplication app)
        {
            var jokes = app.MapGroup("jokes");
            jokes.MapGet("/", GetAllJokes);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllJokes()
        {
            return TypedResults.Ok(JokeData.GetJokes());
        }
    }
}
