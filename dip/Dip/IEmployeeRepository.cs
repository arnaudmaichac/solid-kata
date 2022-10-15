namespace Dip
{
    public interface IEmployeeRepository
    {
        List<Employee> FindEmployeesBornOn(DateTime monthDay);
    }
}