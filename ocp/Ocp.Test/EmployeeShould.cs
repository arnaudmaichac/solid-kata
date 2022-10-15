using Xunit;

namespace Ocp.Test
{
    public class EmployeeShould
    {
        private const int BONUS = 100;
        private const int SALARY = 1000;

        [Fact]
        public void Not_Add_Bonus_To_The_Engineer_Pay_Amount()
        {
            Employee employee = new Engineer(SALARY, BONUS);
            Assert.Equal(SALARY, employee.PayAmount());
        }

        [Fact]
        public void Add_Bonus_To_The_Manager_Pay_Amount()
        {
            Employee employee = new Manager(SALARY, BONUS);
            Assert.Equal(SALARY + BONUS, employee.PayAmount());
        }
    }
}