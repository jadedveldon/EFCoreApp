namespace EDCore.Data.Entities.ViewModels;

public class EmployeeViewModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Gender { get; set; } = null!;

    public string? Religion { get; set; }

    public bool? IsActive { get; set; }

    public int? Deptid { get; set; }
}
