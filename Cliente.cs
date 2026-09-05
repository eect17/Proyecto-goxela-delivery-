using System;

namespace GoXelaDelivery
{
    public class Cliente : Persona
    {
        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                }
                else
                {
                    Console.WriteLine("La dirección no puede estar vacía.");
                }
            }
        }

        private string correo;
        public string Correo
        {
            get { return correo; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    correo = value;
                }
                else
                {
                    Console.WriteLine("El correo no puede estar vacío.");
                }
            }
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine($"Correo: {correo}");
        }

        public void AcctualizarInfo(string nombre, string codigo, string telefono, string direccion, string correo)
        {
            if (ValidarInfo(nombre, codigo, telefono))
            {
                Nombre = nombre;
                Codigo = codigo;
                Telefono = telefono;
                Direccion = direccion;
                Correo = correo;
            }
            else
            {
                Console.WriteLine("Error: No se puede actualizar la información. Los campos no pueden estar vacíos.");
            }
        }
    }
}