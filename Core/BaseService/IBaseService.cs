namespace Core.BaseService
{
    public interface IBaseService
    {
        public int IsEven(DateOnly date);
        public bool IsValidForSubmit(DateOnly date);
    }
}
