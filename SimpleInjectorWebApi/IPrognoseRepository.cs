using System.Collections.Generic;

namespace SimpleInjectorWebApi
{
    public interface IPrognoseRepository
    {
        List<Prognose> GetPrognoses();
    }
}