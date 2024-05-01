using AuditingMicroserviceShared;

namespace AuditingMicroserviceShared
{
    public interface IAuditLogService
    {
        Task CreateAuditLog(AuditLog auditLog);

        List<AuditLog> GetAllAuditLogs();

        Task DeleteAuditLog(AuditLog auditLog);
    }
}
