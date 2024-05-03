using System;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {

            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsin.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsin.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmını Boş Geçemezsin.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvanı Kısmını Boş Geçemezsin.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen 2 karakterden fazla giriş yapınız !");
            RuleFor(x => x.WriterName).MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriş yapınız !");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen 2 karakterden fazla giriş yapınız !");
            RuleFor(x => x.WriterSurName).MaximumLength(20).WithMessage("Lütfen 20 karakterden az giriş yapınız !");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Lütfen 2 karakterden fazla giriş yapınız !");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Lütfen 100 karakterden az giriş yapınız !");
          


        }
    }
}

