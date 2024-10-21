using FluentValidation;

namespace DelCars.Application.ViewModels
{
    public class CarViewModel
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Plate { get; set; }
    }

    public class CarViewModelValidator : AbstractValidator<CarViewModel>
    {
        public CarViewModelValidator()
        {
            RuleFor(carViewModel => carViewModel.Mark)
                .NotEmpty()
                .WithMessage("A marca é obrigatória");

            RuleFor(carViewModel => carViewModel.Model)
                .NotEmpty()
                .WithMessage("O modelo é obrigatório");

            RuleFor(carViewModel => carViewModel.Year)
                .NotEmpty()
                .WithMessage("O ano é obrigatório");

            RuleFor(carViewModel => carViewModel.Color)
                .NotEmpty()
                .WithMessage("A cor é obrigatória");

            RuleFor(carViewModel => carViewModel.Plate)
                .NotEmpty()
                .WithMessage("A placa é obrigatória");
        }
    }
}
