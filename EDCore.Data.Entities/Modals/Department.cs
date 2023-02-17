namespace EDCore.Data.Entities.Modals;

public partial class Department : BaseClass
{
    public string? Name { get; set; }

    public string? Hod { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
