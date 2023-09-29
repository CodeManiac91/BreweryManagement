using DataAccess;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBrewerBussinessService
    {
        List<BrewerDto> GetAllBrewers();

        BrewerDto GetBrewerById(int id);

        void AddBrewer(BrewerDto brewerDto);

        void Update(BrewerDto brewerDto);

        void Delete(int id);

        BrewerDto GetBrewerByKey(Expression<Func<Brewer, bool>> filter = null);

        void SoftDelete(Int64 identificationNumber);
    }
}
