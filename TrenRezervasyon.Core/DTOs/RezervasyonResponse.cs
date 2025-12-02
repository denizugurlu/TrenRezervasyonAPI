using System;
using System.Collections.Generic;

namespace TrenRezervasyonu.Core.DTOs;

public class RezervasyonResponse
{
public bool RezervasyonYapilabilir { get; set; }
    public List<YerlesimAyrinti> YerlesimAyrinti { get; set; } = new List<YerlesimAyrinti>();
}
