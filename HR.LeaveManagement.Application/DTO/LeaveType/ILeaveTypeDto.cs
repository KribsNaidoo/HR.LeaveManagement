namespace HR.LeaveManagement.Application.DTO.LeaveType
{
    public interface ILeaveTypeDto
    {
        public int DefaultDays { get; set; }
        public string Name { get; set; }
    }
}