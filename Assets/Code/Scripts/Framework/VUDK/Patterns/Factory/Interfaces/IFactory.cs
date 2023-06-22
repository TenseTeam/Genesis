namespace VUDK.Patterns.Factory.Interfaces
{
    public interface IFactory<T>
    {
        abstract T Construct();
    }
}