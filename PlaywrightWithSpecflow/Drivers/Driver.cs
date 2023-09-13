using Microsoft.Playwright;

namespace PlaywrightWithSpecflow.Drivers
{
    public class Driver : IDisposable
    {
        private IBrowser? _browser;
        private readonly Task<IPage> _page;

        public IPage Page
        {
            get => _page.Result;
        }

        private Driver()
        {
            _page = SetUpPlaywright();
        }

        private async Task<IPage> SetUpPlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()
            {
                Headless = false
            });
            return await _browser.NewPageAsync();
        }

        public void Dispose()
        {
            _browser?.CloseAsync();
        }
    }
}