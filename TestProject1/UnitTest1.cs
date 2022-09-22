using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    public class Tests
    {
        private IWebDriver driver = null;
        public bool resultado = false;
        [SetUp]
        public void Setup()
        {
            driver = IniciarNavegador();
        }

        [Test]
        public void Test1()
        {
            IWebElement InputAdd = driver.FindElement(By.Id("sampletodotext"));
            IWebElement BtnAdd = driver.FindElement(By.Id("addbutton"));
            if (InputAdd.Displayed)
            {
                InputAdd.SendKeys("mi nuevo item");
                BtnAdd.Click();
            }

            IWebElement SpanOpcion = driver.FindElement(By.XPath("//span[contains(text(),'mi nuevo item')]"));
            if (SpanOpcion.Displayed)
            {
                resultado = true;
            }
            Thread.Sleep(2000);
            Assert.IsTrue(resultado);
        }


        [Test]
        public void ClickOption()
        {
            IReadOnlyList<IWebElement> Items = driver.FindElements(By.TagName("input"));
            foreach (IWebElement e in Items)
            {
                Console.WriteLine(e.Text);
                if (e.Text.Equals("Third Item"))
                {
                    e.Click();
                    break;
                }
            }
            IWebElement checkThird = driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[3]/input"));

            // ThirdItem.Click();
            if (checkThird.Selected)
            {
                resultado = true;
            }
            Thread.Sleep(2000);
            Assert.IsTrue(resultado);
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
            Console.WriteLine("Close Browser");
        }


        public IWebDriver IniciarNavegador()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(25);
            driver.Navigate().GoToUrl("https://lambdatest.github.io/sample-todo-app/");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            return driver;
        }


    }
}