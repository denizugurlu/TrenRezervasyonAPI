using System;
using FluentValidation;
using TrenRezervasyonu.Core.DTOs;

namespace TrenRezervasyonu.Validations;

public class RezervasyonRequestValidator : AbstractValidator<RezervasyonRequest>
{
        public RezervasyonRequestValidator()
    {
        RuleFor (x => x.RezervasyonYapilacakKisiSayisi).GreaterThan(0).WithMessage("Rezervasyon yapılacak kişi sayısı 0'dan büyük olmalıdır.");
        RuleFor(x => x.Tren.Vagonlar).NotEmpty().WithMessage("Trende en az bir vagon olmalıdır.").When(x=>x.Tren !=null);
        
        

    }

}
