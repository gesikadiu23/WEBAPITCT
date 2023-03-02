using FirstWebProj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public static List<Movie> dbMovies = new List<Movie>();

        public static List<Rating> dbRatings = new List<Rating>();

        [HttpPost("ShtoFilm")]
        public void AddMovie(Movie movie)
        {
            movie.Id = dbMovies.Count() + 1;
            dbMovies.Add(movie);
        }


        [HttpGet("MerrMeTeVleresuar")]
        public List<Movie> GetBestRatedMovies(int numberOfMovies) 
        {
            return dbMovies.OrderByDescending(a => a.Rating).ThenBy(a => a.ReleaseDate).Take(numberOfMovies).ToList();
        }


        [HttpGet("FillojneMe")]
        public List<Movie> StartingWith(char c)
        {
            return dbMovies.Where(a => a.Name.StartsWith(c)).ToList();  
        }





        [HttpPut("EditoMovie")]
        public void EditMovie(int id, Movie m)
        {
            Movie movieToUpdate = dbMovies.Where(a => a.Id == id).FirstOrDefault();

            movieToUpdate.Name = m.Name;
            movieToUpdate.ReleaseDate = m.ReleaseDate;
            movieToUpdate.Genre = m.Genre;
            movieToUpdate.Rating = m.Rating;
        }



        [HttpDelete("FshiMovie")]
        public void DeleteMovie(int id)
        {
            // marrim referencen e objektit me id nga lista, fshijme referencen e atij objekti
            // m eshte referenca e objektit te marre, ne momentin qe fshijme "m" kemi fshire objektin nga lista
            Movie m =  dbMovies.Where(a => a.Id== id).FirstOrDefault();

            dbMovies.Remove(m);
        }



    }
}
