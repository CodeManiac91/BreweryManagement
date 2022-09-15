using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAuditService
    {
        TEntity PopulateAuditFields<TEntity>(TEntity entity,int brewerId, bool isModified = false) where TEntity : class;
    }
}
