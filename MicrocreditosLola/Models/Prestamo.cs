using System;
using System.Collections.Generic;

namespace MicrocreditosLola.Models;

public partial class Prestamo
{
    public int Idprestamo { get; set; }

    public decimal? Cantidad { get; set; }

    public DateTime? Fecha { get; set; }

    public short? Diadecobro { get; set; }

    public int? Mesesdeprestamo { get; set; }

    public short? Intereses { get; set; }

    public int? Idcliente { get; set; }

    public virtual Cliente? IdclienteNavigation { get; set; }
}
