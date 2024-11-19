using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail  boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi  boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih  boş geçilemez lütfen tarih seçimi yapınız!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen isim alanına en az 5 karakter veri girişi yapınız").MaximumLength(50).WithMessage("Lütfen isim alanına en fazla 50 kareter veri girişi yapınız.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen açıklama alanına en fazla 500 karakter veri girişi yapınız.");

            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
        }
    }
}
