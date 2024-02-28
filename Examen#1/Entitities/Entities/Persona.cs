using System;
using System.Collections.Generic;

namespace Entitities.Entities;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Propietario> Propietarios { get; set; } = new List<Propietario>();
}
