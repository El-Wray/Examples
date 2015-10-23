namespace SelfHostProject.Services
{
    internal class ValuesService : IValuesService
    {
        private readonly string[] _values = { "Hello", "You", "world", "!" };

        public string[] GetValues()
        {
            return _values;
        }

        public string GetValue(int index)
        {
            return index >= 0 && index < _values.Length ? _values[index] : string.Empty;
        }
    }
}