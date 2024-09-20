using System;
using System.Collections.Generic;

namespace Crud.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public int? Idusuario { get; set; }

    public int? Idproducto { get; set; }

    public int? CantidadProductos { get; set; }

    public decimal? PrecioTotal { get; set; }

    public virtual Producto? IdproductoNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
