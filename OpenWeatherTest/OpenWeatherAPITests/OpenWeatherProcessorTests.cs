using Moq;
using OpenWeatherAPI;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        OpenWeatherProcessor _owp = OpenWeatherProcessor.Instance;
        [Fact]
        public async Task GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
           ApiHelper.InitializeClient();
            _owp.ApiKey = null;
            await Assert.ThrowsAsync<ArgumentException>(() => _owp.GetOneCallAsync());
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException()
        {
            ApiHelper.InitializeClient();
            _owp.ApiKey = null;
            await Assert.ThrowsAsync<ArgumentException>(() =>  _owp.GetCurrentWeatherAsync());
        }


        [Fact]
        public async Task GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            
            ApiHelper.ApiClient = null;
            _owp.ApiKey = "salut";
            await  Assert.ThrowsAsync<ArgumentException>(() =>  _owp.GetOneCallAsync());
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {

            ApiHelper.ApiClient = null;
            _owp.ApiKey = "salut";
            await Assert.ThrowsAsync<ArgumentException>(() => _owp.GetCurrentWeatherAsync());
        }
    }
}
