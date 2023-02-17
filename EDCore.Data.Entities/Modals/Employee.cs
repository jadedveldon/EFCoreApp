namespace EDCore.Data.Entities.Modals;

public partial class Employee : BaseClass
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string? Gender { get; set; }

    public string? Religion { get; set; }

    public bool? IsActive { get; set; }

    public int? Deptid { get; set; }
    //public bool IsSuccess { get; set; } = true;

    public virtual Department? Dept { get; set; }
}
