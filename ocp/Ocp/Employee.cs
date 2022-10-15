namespace Ocp
{
    public class Employee
    {
        private int salary;
        private int bonus;
        private EmployeeType type;

        public Employee(int salary, int bonus, EmployeeType type)
        {
            this.salary = salary;
            this.bonus = bonus;
            this.type = type;
        }

        public int PayAmount()
        {
            switch (type)
            {
                case EmployeeType.ENGINEER:
                    return salary;

                case EmployeeType.MANAGER:
                    return salary + bonus;

                default:
                    return 0;
            }
        }

    }
}