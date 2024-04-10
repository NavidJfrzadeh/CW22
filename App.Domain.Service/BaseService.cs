using Core.BaseService;

namespace App.Domain.Service
{
    public class BaseService : IBaseService
    {
        public int IsEven(DateOnly date)
        {
            var Day = date.DayOfWeek;

            //return Day switch
            //{
            //    DayOfWeek.Sunday => false,
            //    DayOfWeek.Monday => true,
            //    DayOfWeek.Tuesday => false,
            //    DayOfWeek.Wednesday => true,
            //    DayOfWeek.Thursday => false,
            //    DayOfWeek.Friday => false,
            //    DayOfWeek.Saturday => true,
            //    _ => false
            //};

            switch (Day)
            {
                case DayOfWeek.Sunday:
                    return 1;
                case DayOfWeek.Monday:
                    return 2;
                case DayOfWeek.Tuesday:
                    return 1;
                case DayOfWeek.Wednesday:
                    return 2;
                case DayOfWeek.Thursday:
                    return 1;
                case DayOfWeek.Friday:
                    return 0;
                case DayOfWeek.Saturday:
                    return 2;
                default:
                    return 0;
            }
        }

        public bool IsValidForSubmit(DateOnly CarProduceDate) => CarProduceDate > new DateOnly().AddDays(-5);
    }
}
