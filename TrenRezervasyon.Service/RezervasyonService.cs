using System;
using System.Collections.Generic;
using TrenRezervasyonu.Core.DTOs;
using TrenRezervasyonu.Core.Entities;

namespace TrenRezervasyonu.Services;

public class RezervasyonService
{

    public RezervasyonResponse RezervasyonOlustur(RezervasyonRequest rezervasyonRequest)
    {
        var sonuc =  new RezervasyonResponse();
        sonuc.YerlesimAyrinti = new List <YerlesimAyrinti> ();  
        int rezervasyonYapilacakKisiSayisi = rezervasyonRequest.RezervasyonYapilacakKisiSayisi;
        if (rezervasyonRequest.KisilerFarkliVagonlaraYerlestirilebilir == true)
        {
            foreach ( var vagon in rezervasyonRequest.Tren.Vagonlar )
            {
                if ( rezervasyonYapilacakKisiSayisi == 0) {break; }
                int musaitKoltukSayisi = MusaitKoltuk(vagon);
                if ( musaitKoltukSayisi > 0)
                {
                    int yerlesenkisisayisi = Math.Min(rezervasyonYapilacakKisiSayisi, musaitKoltukSayisi);
                    sonuc.YerlesimAyrinti.Add( new YerlesimAyrinti
                    {
                        VagonAdi= vagon.Ad,
                        KisiSayisi = yerlesenkisisayisi,
                    }  );
                    rezervasyonYapilacakKisiSayisi -= yerlesenkisisayisi;
                }
            }
            if ( rezervasyonYapilacakKisiSayisi == 0){ sonuc.RezervasyonYapilabilir = true;}
            else
            {
                sonuc.RezervasyonYapilabilir = false;
                sonuc.YerlesimAyrinti.Clear();
            }
           
        }
        else{
            foreach ( var vagon in rezervasyonRequest.Tren.Vagonlar)
            {
                int musaitKoltukSayisi =MusaitKoltuk(vagon);
                if (musaitKoltukSayisi >= rezervasyonYapilacakKisiSayisi)
                {
                    sonuc.RezervasyonYapilabilir = true;
                    sonuc.YerlesimAyrinti.Add(new YerlesimAyrinti
                    {
                         VagonAdi = vagon.Ad,
                         KisiSayisi = rezervasyonYapilacakKisiSayisi
                    });
                    break;
                } else  
                {
                    sonuc.RezervasyonYapilabilir = false;
                    sonuc.YerlesimAyrinti.Clear();
                }
            }
        }
        return sonuc;
    }

    private int MusaitKoltuk (Vagon vagon)
    {
        int sinir =  (int) Math.Floor(vagon.Kapasite * 0.7) ; 
        int musaitKoltukSayisi = sinir - vagon.DoluKoltukAdet;

        if (musaitKoltukSayisi <= 0){return 0 ; }

        return musaitKoltukSayisi;

        
    }


}
