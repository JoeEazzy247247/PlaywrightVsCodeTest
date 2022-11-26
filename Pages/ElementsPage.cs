using Microsoft.Playwright;

public class ElementsPage{
    private readonly IPage page;

    public ElementsPage(IPage page)
    {
        this.page = page;
    }

    #region Locators
    private ILocator headertext => page.GetByText("Elements").First;
    private ILocator textBox(string option) => page.GetByRole(AriaRole.Listitem)
    .Filter(new() { HasTextString = $"{option}" });
    #endregion Locators

    #region Methods
    public async Task<string> GetHeadertxt()=> await headertext.InnerTextAsync();
    public async Task ClickTextBox(string option)=> await textBox(option).ClickAsync();
    #endregion Methods
}