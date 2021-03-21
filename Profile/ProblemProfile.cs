using AutoMapper;
using Amazon.Suporte.ViewModel;
using Amazon.Suporte.Model;
namespace Amazon.Suporte.Profiles
{
    public class ProblemProfile : Profile
    {
        public ProblemProfile()
        {
            CreateMap<ProblemRequest,Problem>();
            CreateMap<Problem, ProblemResponse>();
        }
    }
}
