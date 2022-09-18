namespace Domain.Utils
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        public static void ValidateNotNullOrWhiteSpace(this string value, string propertyName)
        {
            if (value.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException();
            }
        }
            
    }
}
