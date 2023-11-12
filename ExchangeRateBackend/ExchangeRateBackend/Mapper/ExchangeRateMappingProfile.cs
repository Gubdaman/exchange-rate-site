using AutoMapper;
using ExchangeRateBackend.Models.Database;
using ExchangeRateBackend.Models.MNB;
using ExchangeRateBackend.Models.RequestResponse;
using ExchangeRateBackend.Models.Service;
using System.Globalization;

namespace ExchangeRateBackend.Mapper
{
    public class ExchangeRateMappingProfile : Profile
    {
        public static CultureInfo serverCulture = new CultureInfo("hu-HU");
        public ExchangeRateMappingProfile()
        {
            CreateMap<ExchangeRate, ExchangeRateResponse>().ReverseMap();
            CreateMap<Rate, ExchangeRate>()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Curr))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => double.Parse(src.Text, serverCulture) / src.Unit));
            CreateMap<SavedExchangeRate, SaveExchangeRateResponse>();
            CreateMap<SavedExchangeRate, SavedExchangeRateModel>().ReverseMap();
            CreateMap<LoginData, LoginDataRequest>().ReverseMap();
        }
    }
}
