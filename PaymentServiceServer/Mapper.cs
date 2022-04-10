namespace PaymentServiceServer
{
    public class Mapper
    {
        private static Mapper? instance;
        public static Mapper Instance { get => instance ??= new Mapper(); }   
        
        private AutoMapper.Mapper mapper;

        private Mapper()
        {
            mapper = new AutoMapper.Mapper(new AutoMapper.MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Transaction, TransactionViewModel>()
                    .ForMember(t => t.Image, opt => opt.MapFrom(src => src.Image))
                    .ForMember(t => t.Money, opt => opt.MapFrom(src => src.AmountMoney))
                    .ForMember(t => t.Date, opt => opt.MapFrom(src => src.Date))
                    .ForMember(t => t.Description, opt => opt.MapFrom(src => src.Description));

                cfg.CreateMap<BankCard, BankCardViewModel>()
                    .ForMember(t => t.Number, opt => opt.MapFrom(src => src.Number));
            }));
        }


        public static T Map<T>(object? source) =>
             Instance.mapper.Map<T>(source);
    }
}

