using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;

namespace Semi_Webshop.Models
{
    public class ProductHelper //Json I/O helper
    {
        internal Movie Create()
        {
            Movie movie = new Movie
            {
                ReleaseDate = DateTime.Now
            };

            return movie;
        }

        /// <summary>
        /// Retrieves the list of products.
        /// </summary>
        /// <returns></returns>
        internal List<Movie> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/series.json");

            var json = System.IO.File.ReadAllText(filePath);

            var movies = JsonConvert.DeserializeObject<List<Movie>>(json);

            return movies;
        }

        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Movie Save(Movie movie)
        {
            // Read in the existing products
            var movies = this.Retrieve();

            // Assign a new Id
            var maxId = movies.Max(p => p.Id);
            movie.Id = maxId + 1;
            movies.Add(movie);

            WriteData(movies);
            return movie;
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        internal Movie Save(int id, Movie movie)
        {
            // Read in the existing products
            var movies = this.Retrieve();

            // Locate and replace the item
            var itemIndex = movies.FindIndex(p => p.Id == movie.Id);
            if (itemIndex > 0)
            {
                movies[itemIndex] = movie;
            }
            else
            {
                return null;
            }

            WriteData(movies);
            return movie;
        }

        private bool WriteData(List<Movie> movies)
        {
            // Write out the Json
            var filePath = HostingEnvironment.MapPath(@"~/App_Data/series.json");

            var json = JsonConvert.SerializeObject(movies, Formatting.Indented);
            System.IO.File.WriteAllText(filePath, json);

            return true;
        }
    }
}