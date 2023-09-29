using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class AuditService : IAuditService
    {
        public TEntity PopulateAuditFields<TEntity>(TEntity entity, int brewerId, bool isModified = false) where TEntity : class
        {
            if (!isModified)
            {
                entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
                entity.GetType().GetProperty("CreatedBy").SetValue(entity, brewerId);
                entity.GetType().GetProperty("ModifiedBy").SetValue(entity, brewerId);
            }
            else
            {
                entity.GetType().GetProperty("ModifiedDate").SetValue(entity, DateTime.Now);
                entity.GetType().GetProperty("ModifiedBy").SetValue(entity, brewerId);
            }

            return entity;
        }
    }
}
