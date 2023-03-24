using System;
using System.Collections.Generic;

namespace MicrocreditosLola.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidop { get; set; }

    public string? Apellidom { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
