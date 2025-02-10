
using LinQ_Course;

LinqQueries queries = new LinqQueries();

// Toda la colección
//ImprimirValores(queries.TodaLaColeccion());

// Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

// Libros con mas de 250 paginas y contienen las palabras in Action
//ImprimirValores(queries.LibrosConMasDe250PaginasYTituloContienePalabrasInAction());

//Todos los libros tienen Status
//Console.WriteLine($"Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Libros publicados en 2005
//Console.WriteLine($"Existe algún libro publicado en el 2005: {queries.AlgunLibroPublicado2005()}");

// Libros que son de Python
//ImprimirValores(queries.LibrosPython());

// Libros ordenados ascendentemente que sean de Java
//ImprimirValores(queries.LibrosJavaPorNombreAscendente());

// Libros ordenados descendentemente que tengan mas de 450 paginas
//ImprimirValores(queries.LibrosMasDe450PaginasDescendente());

// Los 3 primeros libros de Java publicados recientemente
//ImprimirValores(queries.TresPrimerosLibrosJavaOrdenadosPorFecha());


// 3 y 4 libros con mas de 400 paginas
//ImprimirValores(queries.TercerYCuartoLibroConMasDe400Paginas());

// Titulo y primeros 3 libros
//ImprimirValores(queries.TituloYNumeroPaginasDePrimeros3Libros());

// Libros entre 200 y 500 paginas
//Console.WriteLine($"Cantidad de libros: {queries.LibrosEntre200y500Paginas()}");

// Libro con fecha de publicacion menor
//Console.WriteLine($"Fecha de publicacion menor: {queries.FechaDePublicacionMenor()}");

// Libro con mayor cantidad de paginas
//Console.WriteLine($"El libro con mayor cantidad de paginas contiene: {queries.LibroConMayorNumeroPaginas()} paginas");

// Libro con menor cantidad de paginas
//var libroMenorPag = queries.LibroConMenorNumeroDePaginas();
//Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");

// Libro con fecha de publicacion mas reciente
//var LibroFechaMasReciente = queries.LibroFechaMasReciente();
//Console.WriteLine($"{LibroFechaMasReciente.Title} - {LibroFechaMasReciente.PublishedDate.ToShortDateString()}");

// Suma Libros entre 0 y 500 Paginas
//Console.WriteLine($"Suma de libros entre 0 y 500 paginas: {queries.SumaTodasPaginasLibrosEntre0y500()}");

// Libros publicados despues del 2015
//Console.WriteLine(queries.TitulosLibrosDespuesDel2015Concatenados());

// Promedio Numero de caracteres en los titulos
//Console.WriteLine(queries.PromedioCaracteresTitulos());

// Promedio Numero de Paginas mayor a cero
//Console.WriteLine(queries.PromedioNumeroPaginasMayorACero());

// Libros publicados despues del 2000 y agrupados por año
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAno());

// Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookUp = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookUp, 'M');

// Libros filtrados con clausula JOIN
ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Paginas());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> listadelibros)
{
    foreach (var grupo in listadelibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char,Book> ListaDeLibros, char letra)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in ListaDeLibros[letra])
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
}



// Mi solución antes de ver la clase-------------------------------------------------
//Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");

//var LibrosDespues2000 = queries.TodaLaColeccion().Where(l => l.PublishedDate.Year >= 2000).ToList();

//LibrosDespues2000.ForEach(l => Console.WriteLine("{0, -60} {1, 15} {2, 15}", l.Title, l.PageCount ,l.PublishedDate.Year));


