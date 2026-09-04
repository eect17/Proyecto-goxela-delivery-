class persona
{
    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                nombre = value;
            }
            else
            {
                Console.WriteLine("El nombre no puede estar vacío.");
            }
        }

    }

    private string codigo;
    public string Codigo
    {
        get { return codigo; }
        set
        {
           
            if (!string.IsNullOrEmpty(value))
            {
                codigo = value;
            }
            else
            {
                Console.WriteLine("El código no puede estar vacío.");
            }
        }
    }

    private string telefono;
    public string Telefono
    {
        get { return telefono; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                telefono = value;
            }
            else
            {
                Console.WriteLine("El teléfono no puede estar vacío.");
            }
        }
    }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Teléfono: {Telefono}");
    }

    public static bool ValidarInfo(string nombre, string codigo, string telefono)
    {
        if (!string.IsNullOrEmpty(nombre)  && !string.IsNullOrEmpty(codigo) && !string.IsNullOrEmpty(telefono))
        {
            return false;
        }
        return true;
    }
}