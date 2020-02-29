using System;
using Xunit;

namespace Chippo.Graphics.Tests
{
    public class ColorTests
    {
        [Fact]
        public void FromRGBA_ShouldCreate()
        {
            var color = Color.FromRGBA("#112233");
            Assert.Equal("#112233ff",color.ToString());

        }
        [Fact]
        public void FromARGB_ShouldCreate()
        {
            var color = Color.FromARGB("#221122ff");
            Assert.Equal("#1122ff22", color.ToString());

        }
    }
}
