namespace SelfHostProject.Services
{
    public interface IValuesService
    {
        string[] GetValues();
        string GetValue(int index);
    }
}