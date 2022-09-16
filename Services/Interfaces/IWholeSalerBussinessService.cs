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
    public interface IWholeSalerBussinessService
    {
        List<WholeSalerDto> GetAllWholeSalers();

        WholeSalerDto GetWholeSalerById(int id);

        void AddWholeSaler(WholeSalerDto wholeSalerDto);

        void Update(WholeSalerDto wholeSalerDto);

        void Delete(int id);

        WholeSalerDto GetWholeSalerByKey(Expression<Func<WholeSaler, bool>> filter = null);

        void SoftDelete(string sourceId);

        QuoteResponseDto GetQuoteDetails(QuoteRequestDto quoteRequestDto);
    }
}
