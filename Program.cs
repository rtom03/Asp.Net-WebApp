var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (context.Request.Method == "GET")
    {
        if (context.Request.Path.StartsWithSegments("/"))
        {
            await context.Response.WriteAsync($"The method is: {context.Request.Method}");
        }
        else if (context.Request.Path.StartsWithSegments("/employees"))
        {
            //await context.Response.WriteAsync($"The method is: {context.Request.Method}");
            var employeeData = EmployeeRepository.GetEmployees();

            foreach (var employee in employeeData)
            {
                await context.Response.WriteAsync($"The Staffs are: {employee.Name}\r\n  {employee.Position}\r\n {employee.Salary}");
            }
        }
    }
});
app.Run();


static class EmployeeRepository
{
    private static List<Employee> employess = new List<Employee>
        {
        new Employee(1,"John Doe","Marketing Executive",60000),
        new Employee(1,"John Doe","Marketing Executive",60000),
        new Employee(1,"John Doe","Marketing Executive",60000),
        new Employee(1,"John Doe","Marketing Executive",60000)
};
    public static List<Employee> GetEmployees() => employess;
}


public class Employee {
    public int EmployeId{ get; set; }
    public string Name { get; set; }
    public string Position{ get; set; }
    public double Salary { get; set; }

    public Employee(int employeeid, string name, string position, double salary)
    {
        EmployeId = employeeid;
        Name = name;
        Position = position;
        Salary = salary;

    }


}