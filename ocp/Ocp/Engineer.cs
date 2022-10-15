namespace Ocp
{
    public class Engineer : Employee
    {
        public Engineer(int salary, int bonus)
            : base(salary, bonus)
        {
        }

        public override int PayAmount()
        {
            return salary;
        }
    }
}
