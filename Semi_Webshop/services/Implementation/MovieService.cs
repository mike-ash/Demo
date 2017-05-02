using Semi_Webshop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Semi_Webshop.services
{
    [XmlRoot("products")]
    public class MovieService : IMovieService
    {
        protected string file;
        protected List<Serie> series;

        public MovieService() { }

        public static MovieService Create(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MovieService));

            MovieService store = null;
            using (FileStream filestream = new FileStream(file, FileMode.Open))
            {
                store = (MovieService)serializer.Deserialize(filestream);
            }
            store.file = file;

            return store;
        }

        [XmlElement("product")]
        public List<Serie> Series
        {
            get { return series; }
            set { series = value; }
        }

        public Task<Serie> FindAsync(string id)
        {
            Serie serie = Series.Where(m => m.Id == id).FirstOrDefault();

            TaskCompletionSource<Serie> tcs = new TaskCompletionSource<Serie>();
            tcs.SetResult(serie);

            return tcs.Task;
        }

        public Task<IQueryable<Serie>> GetSeriesAsync()
        {
            IQueryable<Serie> result = series.AsQueryable();

            TaskCompletionSource<IQueryable<Serie>> tcs = new TaskCompletionSource<IQueryable<Serie>>();
            tcs.SetResult(result);

            return tcs.Task;

        }


        public Task<IQueryable<Serie>> GetDealsAsync()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            List<Serie> deals = new List<Serie>();

            for (int i = 0; i <= 3; i++)
                deals.Add(series[(random.Next(series.Count))]);

            IQueryable<Serie> result = deals.AsQueryable();

            TaskCompletionSource<IQueryable<Serie>> tcs = new TaskCompletionSource<IQueryable<Serie>>();
            tcs.SetResult(result);

            return tcs.Task;

        }

        //public Task<IQueryable<Serie>> CreateAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}