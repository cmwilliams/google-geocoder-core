using System.Threading.Tasks;
using Xunit;

namespace GoogleGeoCoderCore.Tests
{
    public class GoogleGeocodeTests
    {
        [Fact]
        public async Task Should_Return_Lat_And_Long()
        {
            var geocoder = new GoogleGeocodeService();
            var result = await geocoder.GeocodeLocation("Atlanta, GA");
            Assert.NotNull(result.Latitude);
            Assert.NotNull(result.Longitude);
        }

        [Fact]
        public async Task Should_Return_Default_Values_For_Lat_And_Long()
        {
            var geocoder = new GoogleGeocodeService();
            var result = await geocoder.GeocodeLocation("dfgfdgfdgfdgdfgdfgdfg");
            Assert.Equal(0, result.Latitude);
            Assert.Equal(0,result.Longitude);
        }
    }
}
