using System;

namespace GoXelaDelivery
{
    public class Incidencia
    {
        public string Codigo { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public Entrega EntregaRelacionada { get; set; }

        public Incidencia(string codigo, string tipo, string descripcion, Entrega entregaRelacionada)
        {
            Codigo = codigo;
            Tipo = tipo;
            Descripcion = descripcion;
            EntregaRelacionada = entregaRelacionada;
            Fecha = DateTime.Now;
            Estado = "Registrada";
        }
    }
}