namespace Ocp
{
    public class Manager : Employee
    {
        public Manager(int salary, int bonus)
            : base(salary, bonus)
        {
        }

        public override int PayAmount()
        {
            return salary + bonus;
        }
    }
}
