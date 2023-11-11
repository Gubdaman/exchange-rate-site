using AutoMapper;
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
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Unit * double.Parse(src.Text, serverCulture)));            
        }
    }
}
