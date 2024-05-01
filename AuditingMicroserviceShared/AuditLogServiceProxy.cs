using System.Net.Http.Json;

namespace AuditingMicroserviceShared
{
    public class AuditLogServiceProxy : IAuditLogService
    {
        private readonly string _baseUrl;
        public AuditLogServiceProxy(String baseUrl) 
        {
            _baseUrl = baseUrl;
        }
        public async Task CreateAuditLog(AuditLog auditLog)
        {
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            var response = await httpClient.PostAsJsonAsync("/AuditLog", auditLog);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new AuditLogRejectedException("Create audit log failed");
            }
        }

        public Task DeleteAuditLog(AuditLog auditLog)
        {
            throw new NotImplementedException();
        }

        public List<AuditLog> GetAllAuditLogs()
        {
            throw new NotImplementedException();
        }
    }
}
