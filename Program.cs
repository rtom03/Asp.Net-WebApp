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
                await context.Response.WriteAsync($"The Staffs are: {employee.Name} {employee.Position} {employee.Salary}\r\n");
            }
        }
        else if (context.Request.Path.StartsWithSegments("/bank-details"))
        {
            var bankDetails = EmployeeBankDetailsRepository.getBankDetails();

            foreach (var bankdetails in bankDetails)
            {
                await context.Response.WriteAsync($"The Staffs are: {bankdetails.BankName}  {bankdetails.AccNumber}\r\n");
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


public class Employee
{
    public int EmployeId { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(int employeeid, string name, string position, double salary)
    {
        EmployeId = employeeid;
        Name = name;
        Position = position;
        Salary = salary;
    }


}


public class EmployeeBankDetailsRepository
{
    private static List<EmployeeBankDetails> bankdetailsValue = new List<EmployeeBankDetails>
    {
        new EmployeeBankDetails("UBA",1562514263, 745362938262),
        new EmployeeBankDetails("UBA",1562514263, 745362938262),
    };

    public static List<EmployeeBankDetails> getBankDetails() => bankdetailsValue;
}



public class EmployeeBankDetails
{
    public string BankName { get; set; }
    public int AccNumber { get; set; }
    public double BankBVN { get; set; }

    public EmployeeBankDetails(string bankName, int accNumber, double bankBvn)
    {
        BankName = bankName;
        AccNumber = accNumber;
        BankBVN = bankBvn;
    }

}