using System.Collections.Generic;

namespace AutofacWebApi
{
    public interface IPrognoseRepository
    {
        List<Prognose> GetPrognoses();
    }
}