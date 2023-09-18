namespace EGN.Test
{
    #region USings
    using Xunit;
    using Euroins.Tools.Validators;
    #endregion

    public class Tests
    {
        #region Props
        private EgnValidator _validator = new();
        private static IEnumerable<object[]> ValidEGN() => new List<object[]>
            {
                {  new object[] { "9206183026", "M" , "Lovech"} },
                {  new object[] { "1248167543", "M" , "Stara Zagora"} },
                {  new object[] { "7541010940", "M" , "Varna"} }
            };

        private static IEnumerable<object[]> InValidEGN() => new List<object[]>
            {
                {  new object[] { "96183026" } },
                {  new object[] { "725241629268" } },
                {  new object[] { "0000000000" } },
                {  new object[] { "9999999999" } },
                {  new object[] { "1q2w3e4r5t" } },
                {  new object[] { "qwertyuiop" } }
             };
        #endregion

        [Theory]
        [MemberData(nameof(ValidEGN))]
        public void ValidateValidEgn(string egn, string sex, string town)
        {
            bool result = _validator.IsValid(egn);
            Assert.True(result);
        }

        [Theory]
        [MemberData(nameof(ValidEGN))]
        public void GetInfoValidEgn(string egn, string sex, string town)
        {
            EgnValidator.EGNInfo info = _validator.Parse(egn);
            Assert.Equal(info.Sex, sex);
            Assert.Equal(info.Region, town);
        }

        [Theory]
        [MemberData(nameof(InValidEGN))]
        public void ThrowInValidEgn(string egn)
        {
            bool result = _validator.IsValid(egn);
            Assert.False(result);
        }
    }
}