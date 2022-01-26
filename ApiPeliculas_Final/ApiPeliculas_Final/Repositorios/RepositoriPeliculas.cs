using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPeliculas_Final.Modelos;

namespace ApiPeliculas.Repositorios
{

    public class RepositoriPeliculas
    {

        private readonly PeliculasApiContext _context;

        public RepositoriPeliculas()
        {
            _context = new PeliculasApiContext();
        }

        public IEnumerable<Peliculas2> ObtenerPelicula()
        {
            return _context.Peliculas2s;
        }

        public Peliculas2 ObtenerPelicula(int id)
        {
            var pelicula = _context.Peliculas2s.Where(peli => peli.Id == id);

            return pelicula.FirstOrDefault();
        }


        public void Agregar(Peliculas2 nuevapelicula)
        {
            var entity = nuevapelicula;
            _context.Peliculas2s.Add(entity);
            var colums = _context.SaveChanges();
            if (colums <= 0)
                throw new Exception("No se pudo Registrar la pelicula");
            return;

        }

        public void ActualizarPelicula(int id, Peliculas2 actualizarpelicula)
        {
            if (id <= 0 || actualizarpelicula == null)
            {
                throw new ArgumentException("Falta Informacion :c");
            }
            var mdpelicula = ObtenerPelicula(id);

            mdpelicula.NombrePelicula = actualizarpelicula.NombrePelicula;
            mdpelicula.Director = actualizarpelicula.Director;
            mdpelicula.Genero = actualizarpelicula.Genero;
            mdpelicula.Puntuacion = actualizarpelicula.Puntuacion;
            mdpelicula.Rating = actualizarpelicula.Rating;
            mdpelicula.FechaPublicacion = actualizarpelicula.FechaPublicacion;
            _context.Update(mdpelicula);
            var columns = _context.SaveChanges();
            return;

        }

        public void BorrarPelicula(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("No existe una pelicula con esa id ingresada");
            }
            var mdpelicula = ObtenerPelicula(id);
            _context.Remove(mdpelicula);
            var columns = _context.SaveChanges();
            return;

        }



    }
}
