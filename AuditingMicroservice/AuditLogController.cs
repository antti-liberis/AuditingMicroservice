using AuditingMicroserviceShared;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMicroservice
{
    [ApiController]
    [Route("[controller]")]
    public class AuditLogController
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public List<AuditLog> GetAllAuditLogs()
        {
            return _auditLogService.GetAllAuditLogs();
        }

        [HttpPost]
        public void CreateAuditLog(AuditLog auditLog)
        {
            _auditLogService.CreateAuditLog(auditLog);
        }
    }
}
