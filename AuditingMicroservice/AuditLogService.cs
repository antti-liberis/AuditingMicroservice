using AuditingMicroserviceShared;

namespace AuditingMicroservice
{
    public class AuditLogService : IAuditLogService
    {
        private readonly List<AuditLog> auditLogs = new List<AuditLog>();

        public List<AuditLog> GetAllAuditLogs()
        {
            return auditLogs;
        }

        public async Task CreateAuditLog(AuditLog auditLog)
        {
            auditLogs.Add(auditLog);
        }

        public async Task DeleteAuditLog(AuditLog auditLog)
        {
            auditLogs.FirstOrDefault(log => log == auditLog);
        }
    }
}
