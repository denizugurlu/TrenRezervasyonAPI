using System;
using TrenRezervasyonu.Core.Entities;

namespace TrenRezervasyonu.Core.DTOs;

public class RezervasyonRequest
{
  public required Tren Tren { get; set; }
    public int RezervasyonYapilacakKisiSayisi  { get; set;}
    public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
}
