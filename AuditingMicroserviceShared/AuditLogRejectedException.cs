using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMicroserviceShared
{
    public class AuditLogRejectedException: Exception
    {
        public AuditLogRejectedException(string message) : base(message)
        {
        }
    }
}
