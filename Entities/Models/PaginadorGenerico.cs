﻿namespace Fuchonet.Entities.Models
{
    public class PaginadorGenerico<T> where T : class
    {
        
        public int PaginaActual { get; set; }
        /// <summary>
        /// Número de registros de la página devuelta.
        /// </summary>
        public int RegistrosPorPagina { get; set; }
        /// <summary>
        /// Total de registros de consulta.
        /// </summary>
        public int TotalRegistros { get; set; }
        /// <summary>
        /// Total de páginas de la consulta.
        /// </summary>
        public int TotalPaginas { get; set; }
        /// <summary>
        /// Texto de búsqueda de la consuta actual.
        /// </summary>
        public string BusquedaActual { get; set; }
        /// <summary>
        /// Columna por la que esta ordenada la consulta actual.
        /// </summary>
        public string OrdenActual { get; set; }
        /// <summary>
        /// Tipo de ordenación de la consulta actual: ASC o DESC.
        /// </summary>
        public string TipoOrdenActual { get; set; }
        /// <summary>
        /// Resultado devuelto por la consulta a la tabla Customers
        /// en función de todos los parámetros anteriores.
        /// </summary>
        public IEnumerable<T> Resultado { get; set; }
    }
}
