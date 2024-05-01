using AuditingMicroservice;
using AuditingMicroserviceShared;
using FluentAssertions;
using Xunit;

namespace AuditingMicroserviceTest;

public class AuditLogServiceTest
{
    [Fact]
    public async Task Create_Audit_Logs_To_The_Collection()
    {
        var auditLogService = new AuditLogService();

        await auditLogService.CreateAuditLog(new AuditLog("test", "test message"));
        var auditLogs = auditLogService.GetAllAuditLogs();

        auditLogs.Count.Should().Be(1);
    }
    
    [Fact]
    public async Task When_Getting_All_Audit_Logs_Returns_Empty()
    {
        var auditLogService = new AuditLogService();

        var auditLogs = auditLogService.GetAllAuditLogs();

        auditLogs.Should().BeEmpty();
    }

    [Fact]
    public async Task Delete_Audit_Log_Deletes_That_Audit_Log_From_The_Collection()
    {
        var auditLogService = new AuditLogService();
        var auditLog = new AuditLog("test", "test message");
        
        await auditLogService.CreateAuditLog(auditLog);
        var auditLogs = auditLogService.GetAllAuditLogs();

        auditLogs.Should().Contain(auditLog);

        await auditLogService.DeleteAuditLog(auditLog);
        var auditLogsAfterDelete = auditLogService.GetAllAuditLogs();

        auditLogsAfterDelete.Should().NotContain(auditLog);
    }
    
    [Fact]
    public async Task Delete_Audit_Log_Throws_If_Log_Doesnt_Exist_In_Collection()
    {
        var auditLogService = new AuditLogService();
        var auditLog = new AuditLog("test", "test message");
        
        var expectedException = await Assert.ThrowsAsync<ArgumentException>(async () => await auditLogService.DeleteAuditLog(auditLog));

        expectedException.Message.Should().Contain("not found");
        expectedException.Message.Should().Contain(auditLog.Message);
        expectedException.Message.Should().Contain(auditLog.Type);
    }
}
