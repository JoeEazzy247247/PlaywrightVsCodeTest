using Microsoft.Playwright;

public class HomePage{
    private readonly IPage page;

    public HomePage(IPage page)
    {
        this.page = page;
    }

#region Locators
    private ILocator elements => page.Locator(".card", new() {
            HasTextString = "Elements"
        });


#endregion Locators



#region Methods
    public async Task ClickElements()=> await elements.ClickAsync();

#endregion Methods
}