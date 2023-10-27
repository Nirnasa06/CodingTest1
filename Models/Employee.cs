namespace CodingTest1.Models
{
    public abstract class Employee
    {
        protected const int WorkYearDays = 260;
        private float _vacationDays = 0;

        public float VacationDays => _vacationDays;

        public abstract float VacationDaysPerWorkDay { get; }

        public void Work(int daysWorked)
        {
            if (daysWorked < 0 || daysWorked > WorkYearDays)
                throw new ArgumentException("Days worked should be between 0 and 260.");

            _vacationDays += daysWorked * VacationDaysPerWorkDay;
        }

        public void TakeVacation(float days)
        {
            if (days < 0 || days > _vacationDays)
                throw new ArgumentException("Cannot take more vacation days than available.");

            _vacationDays -= days;
        }
    }

    public class HourlyEmployee : Employee
    {
        public override float VacationDaysPerWorkDay => 10f / WorkYearDays;
    }

    public class SalariedEmployee : Employee
    {
        public override float VacationDaysPerWorkDay => 15f / WorkYearDays;
    }

    public class Manager : SalariedEmployee
    {
        public override float VacationDaysPerWorkDay => 30f / WorkYearDays;
    }


}


