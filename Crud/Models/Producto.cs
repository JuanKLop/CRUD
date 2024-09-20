using System;
using System.Collections.Generic;

namespace Crud.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
