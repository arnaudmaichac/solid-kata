namespace Ocp
{
    public abstract class Employee
    {
        protected int salary;
        protected int bonus;

        public Employee(int salary, int bonus)
        {
            this.salary = salary;
            this.bonus = bonus;
        }

        public abstract int PayAmount();
    }
}