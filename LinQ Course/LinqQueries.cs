using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Course
{
    public class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();
        public LinqQueries() { 
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }
        public IEnumerable<Book> TodaLaColeccion()
        {
            return librosCollection;
        }
        //public IEnumerable<Book> LibrosDespuesdel2000()
        //{
            // Extension method
            //return librosCollection.Where(p => p.PublishedDate.Year >= 2000);

            // Query expression
            //return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
        //}

        public IEnumerable<Book> LibrosConMasDe250PaginasYTituloContienePalabrasInAction()
        {
            // extension method
            //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

            return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        }

        public bool TodosLosLibrosTienenStatus()
        {
            return librosCollection.All(p => p.Status != string.Empty);
        }

        public bool AlgunLibroPublicado2005()
        {
            return librosCollection.Any(l => l.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> LibrosPython()
        {
            return librosCollection.Where(p => p.Status.Contains("P"));
        }

        public IEnumerable<Book> LibrosJavaPorNombreAscendente()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(o => o.Title);
        }

        public IEnumerable<Book> LibrosMasDe450PaginasDescendente()
        {
            return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(t => t.Title);
        }

        public IEnumerable<Book> TresPrimerosLibrosJavaOrdenadosPorFecha()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3);
        }

        public IEnumerable<Book> TercerYCuartoLibroConMasDe400Paginas()
        {
            return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
        }

        public IEnumerable<Item> TituloYNumeroPaginasDePrimeros3Libros()
        {
            return librosCollection.Take(3).Select(x => new Item() 
            {
                Title = x.Title, PageCount = x.PageCount
            });
        }

        //public int LibrosEntre200y500Paginas()
        //{
        //   return librosCollection.Where(x => x.PageCount >= 200 && x.PageCount <= 500).Count();
        //   Se puede hacer de ambas maneras, sin embargo esta es la practica correcta:
        //   return librosCollection.Count(x => x.PageCount >= 200 && x.PageCount <= 500);
        //}

        //Es lo mismo que Count, solo que LongCount utiliza cantidades muy grandes
        public long LibrosEntre200y500Paginas()
        {
            return librosCollection.LongCount(x => x.PageCount >= 200 && x.PageCount <= 500);
        }

        public DateTime FechaDePublicacionMenor()
        {
            return librosCollection.Min(p => p.PublishedDate);
        }

        public int LibroConMayorNumeroPaginas()
        {
            return librosCollection.Max(p => p.PageCount);
        }

        public Book LibroConMenorNumeroDePaginas()
        {
            return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
        }

        public Book LibroFechaMasReciente()
        {
            return librosCollection.MaxBy(p => p.PublishedDate);
        }

        public int SumaTodasPaginasLibrosEntre0y500()
        {
            return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
        }

        public string TitulosLibrosDespuesDel2015Concatenados()
        {
            return librosCollection.Where(p => p.PublishedDate.Year > 2015)
                .Aggregate("", (TitulosLibros, next) =>
                {
                    if (TitulosLibros != string.Empty)
                    {
                        TitulosLibros += " - " + next.Title;
                    }
                    else
                    {
                        TitulosLibros += next.Title;
                    }
                    return TitulosLibros;
                });
        }

        public double PromedioCaracteresTitulos()
        {
            return librosCollection.Average(p => p.Title.Length);
        }

        public double PromedioNumeroPaginasMayorACero()
        {
            return librosCollection.Where(p => p.PageCount > 0).Average(p => p.PageCount);
        }

        public IEnumerable<IGrouping<int,Book>> LibrosDespuesDel2000AgrupadosPorAno()
        {
            return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
        }

        public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
        {
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas ()
        {
            var LibroDespuesDel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);
            var LibrosConMasDe500Paginas = librosCollection.Where(p => p.PageCount > 500);

            return LibroDespuesDel2005.Join(LibrosConMasDe500Paginas, p => p.Title, x => x.Title, (p, x) => p);
        }
    }
}
