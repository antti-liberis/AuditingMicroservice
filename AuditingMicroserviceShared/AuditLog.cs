namespace AuditingMicroserviceShared
{
    public class AuditLog
    {
        public AuditLog(string type, string message)
        {
            Type = type;
            Message = message;
            Time = DateTime.UtcNow;
        }

        public DateTime Time { get; }
        public string Type { get; }
        public string Message { get; }
    }
}
