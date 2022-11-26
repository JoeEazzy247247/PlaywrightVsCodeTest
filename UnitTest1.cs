using Microsoft.Playwright;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PlaywrightTests;

public class Tests
{
    IWebDriver driver;
    IPlaywright playwright;
    IBrowser browser;
    IPage page;

    // [SetUp]
    // public void Setup()
    // {
    //     driver = new ChromeDriver();
    //     driver.Navigate().GoToUrl("https://demoqa.com");
    // }

    [SetUp]
    public async Task Setup2()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new(){
            Headless = false
        });
        page = await browser.NewPageAsync(new(){
            ViewportSize = new(){
                Width = 1920,
                Height = 1080
            }
        });
        await page.GotoAsync("https://demoqa.com");
    }

    // [Test]
    // public async Task Test1()
    // {
    //     var components = 
    //     driver.FindElements(By.CssSelector(".card"));
    //     foreach(IWebElement ele in components){
    //         if(ele.Text == "Elements")ele.Click();
    //         break;
    //     }
    //     await Task.Delay(2000);
    // }

    [Test]
    public async Task Playtest1(){
        await page.Locator(".card", new() {
            HasTextString = "Elements"
        }).ClickAsync();
                await page.GetByText("Elements").First.ClickAsync();

        var headerText = await page.GetByText("Elements").First.InnerTextAsync();
        Assert.That(headerText, Is.EqualTo("Elements"));

        await page.GetByRole(AriaRole.Listitem).Filter(new() { HasTextString = "Upload and Download" }).ClickAsync();

        await page.GetByLabel("Select a file").SetInputFilesAsync(new[] { "Testdata\\testfile.txt" });

        await page.GetByRole(AriaRole.List).Locator("#item-5").ClickAsync();

        await page.GetByRole(AriaRole.Listitem).Filter(new() { HasTextString = "Web Tables" }).ClickAsync();

        await page.GetByPlaceholder("Type to search").FillAsync("Cierra");

        await page.Locator("#basic-addon2 svg").ClickAsync();
        await Task.Delay(3000);
    }

    // [TearDown]
    // public void CloseBrowser(){driver.Quit();}
}