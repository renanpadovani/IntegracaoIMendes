using AutoMapper;

namespace IntegracaoIMendes.Domain.Repositories
{
    public class Repository
    {
        public IMapper mapper;

        public Repository()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Cenarios, CenariosDto>();
                //cfg.CreateMap<CenariosDto, Cenarios>();
            });

            mapper = config.CreateMapper();
        }
    }
}
