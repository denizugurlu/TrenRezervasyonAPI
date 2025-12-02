using System;
using System.Collections.Generic;

namespace TrenRezervasyonu.Core.Entities;

public class Tren
{
    public string Ad { get; set; } = "";
    public List<Vagon> Vagonlar { get; set; } = new List<Vagon>();
}


