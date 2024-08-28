using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

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
            jokes.MapGet("/long", GetLongJokes);
            jokes.MapGet("/rating/{rating}", GetJokesByRating);
            jokes.MapDelete("/{id}", DeleteJoke);
            jokes.MapPost("/", AddAJoke);
            jokes.MapGet("/reset", Reset);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static IResult AddAJoke(Joke entity)
        {

            var result = JokeData.AddJoke(entity);
            return result != null ? TypedResults.Created($"https://localhost:7083/jokes/{result.Id}",result) : TypedResults.BadRequest();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult GetAllJokes()
        {
            return TypedResults.Ok(JokeData.GetJokes());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static IResult Reset()
        {
            JokeData.Seed();
            return TypedResults.Ok("Successfully Reset!");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetAJoke(int id)
        {
            var result = JokeData.GetById(id);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetRandomJoke()
        {
            var result = JokeData.GetRandomJoke();
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetLongJokes()
        {
            var result = JokeData.GetLongJokes();
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult DeleteJoke(int id)
        {
            var result = JokeData.GetById(id);
            if(result == null)
            {
                return TypedResults.NotFound();
            }

            int deleted = JokeData.DeleteJoke(id);
            return deleted > 0 ? TypedResults.Ok(result) : TypedResults.NotFound();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static IResult GetJokesByRating(int rating)
        {
            var result = JokeData.GetByRating(rating);
            return result != null ? TypedResults.Ok(result) : TypedResults.NotFound();
        }
    }
}
