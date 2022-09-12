using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBrewerService
    {
        List<BrewerDto> GetAllBrewers();

        BrewerDto GetBrewerById(int id);

        void AddBrewer(BrewerDto brewerDto);

        void Update(int id, BrewerDto brewerDto);

        void Delete(int id);
    }
}
