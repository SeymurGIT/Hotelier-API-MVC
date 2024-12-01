using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using Microsoft.CodeAnalysis.Differencing;

namespace HotelProject.WebUI.ValidationRules.GuestValidation
{
    public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator() 
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Ad boş buraxıla bilməz");
            RuleFor(s => s.Name).MinimumLength(3).WithMessage("Zəhmət olmasa, ən azı 3 simvol daxil edin.");
            RuleFor(s => s.Name).MaximumLength(17).WithMessage("Ən çox 20 simvol daxil edə bilərsiniz.");
            

            RuleFor(s => s.Surname).NotEmpty().WithMessage("Soyad boş buraxıla bilməz");
            RuleFor(s => s.Surname).MinimumLength(3).WithMessage("Zəhmət olmasa, ən azı 3 simvol daxil edin.");
            RuleFor(s => s.Surname).MaximumLength(25).WithMessage("Ən çox 25 simvol daxil edə bilərsiniz.");

            RuleFor(s => s.City).NotEmpty().WithMessage("Şəhər boş buraxıla bilməz");
            RuleFor(s => s.City).MinimumLength(3).WithMessage("Zəhmət olmasa, ən azı 3 simvol daxil edin.");
            RuleFor(s => s.City).MaximumLength(30).WithMessage("Ən çox 30 simvol daxil edə bilərsiniz.");
        }
    }
}
