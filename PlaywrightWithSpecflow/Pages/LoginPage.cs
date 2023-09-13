using Microsoft.Playwright;

namespace PlaywrightWithSpecflow.Pages;

public class LoginPage
{
    private IPage _page;

    public LoginPage(IPage page) => _page = page;

    private ILocator LnkLogin => _page.Locator("text=Login");
    private ILocator TxtUserName => _page.Locator("#UserName");
    private ILocator TxtPassword => _page.Locator("#Password");
    private ILocator BtnLogin => _page.Locator("text=Log in");
    private ILocator LnkEmployeeDetails => _page.Locator("text=Employee Details");
    private ILocator LnkEmployeeList => _page.Locator("text=Employee List");

    public async Task ClickLogin()
    {
        await LnkLogin.ClickAsync();
        await _page.WaitForURLAsync("**/Login");
    }

    public async Task ClickEmployeeList() => await LnkEmployeeList.ClickAsync();

    public async Task Login(string userName, string password)
    {
        await TxtUserName.FillAsync(userName);
        await TxtPassword.FillAsync(password);
        await BtnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists() => await LnkEmployeeDetails.IsVisibleAsync();
}