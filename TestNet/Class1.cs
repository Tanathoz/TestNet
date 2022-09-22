using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;

namespace TestNet
{
    public class Class1
    {
        private IWebDriver driver = null;
        public bool resultado = false;
   
        [SetUp]
        public void Inicializar()
        {
            driver = IniciarNavegador();
        }

        [Test]
        public void AddOption()
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
