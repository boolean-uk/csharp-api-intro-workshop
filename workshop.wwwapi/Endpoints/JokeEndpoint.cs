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
            jokes.MapGet("/{id}", GetAJoke);
            jokes.MapGet("/random", GetRandomJoke);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllJokes()
        {
            return TypedResults.Ok(JokeData.GetJokes());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetAJoke(int id)
        {
            var result = JokeData.GetAJoke(id);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetRandomJoke()
        {
            var result = JokeData.GetRandomJoke();
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

    }
}
