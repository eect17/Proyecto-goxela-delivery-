class repartidor : persona
{
    private string licencia;
    public string Licencia
    {
        get { return licencia; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                licencia = value;
            }
            else
            {
                Console.WriteLine("La licencia no puede estar vacía.");
            }
        }
    }

    private string TipoLicencia;
    public string TipoLicenciaProp
    {
        get { return TipoLicencia; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                TipoLicencia = value;
            }
            else
            {
                Console.WriteLine("El tipo de licencia no puede estar vacío.");
            }
        }
    }

    private string estadoentrega;
    public string EstadoEntrega
    {
        get { return estadoentrega; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                estadoentrega = value;
            }
            else
            {
                Console.WriteLine("El estado de entrega no puede estar vacío.");
            }
        }
    }

    private int entregasrealizadas;
    public int EntregasRealizadas
    {
        get { return entregasrealizadas; }
        set
        {
            if (value >= 0)
            {
                entregasrealizadas = value;
            }
            else
            {
                Console.WriteLine("El número de entregas realizadas no puede ser negativo.");
            }
        }
    }

    private double calificacion;
    public double Calificacion
    {
        get { return calificacion; }
        set
        {
            if (value >= 0 && value <= 5)
            {
                calificacion = value;
            }
            else
            {
                Console.WriteLine("La calificación debe estar entre 0 y 5.");
            }
        }
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Licencia: {Licencia}");
        Console.WriteLine($"Tipo de Licencia: {TipoLicenciaProp}");
        Console.WriteLine($"Estado de Entrega: {EstadoEntrega}");
        Console.WriteLine($"Entregas Realizadas: {EntregasRealizadas}");
        Console.WriteLine($"Calificación: {Calificacion}");
    }
    public void AsignarEntrega(string estadoEntrega)
    {
        EstadoEntrega = estadoEntrega;
    }

    public void ActualizarCalificacion(double nuevaCalificacion)
    {
        if (nuevaCalificacion >= 0 && nuevaCalificacion <= 5)
        {
            Calificacion = nuevaCalificacion;
        }
        else
        {
            Console.WriteLine("La calificación debe estar entre 0 y 5.");
        }
    }

}