using NUnit.Framework;

namespace WbTstr.UnitTests._Auxiliaries
{
    public static class AssertString
    {
        public static void NotNullOrEmpty(string value)
        {
            Assert.False(string.IsNullOrEmpty(value));
        }

        public static void NotNullOrWhiteSpace(string value)
        {
            Assert.False(string.IsNullOrWhiteSpace(value));
        }
    }
}
