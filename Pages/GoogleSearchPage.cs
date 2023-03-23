using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestingFramework.Pages
{
    internal class GoogleSearchPage
    {
        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement _searchdiv;


        public GoogleSearchPage()
        {
            PageFactory.InitElements(Constants.SessionVariables.driver, this);
        }

        public void SearchPageIsLoaded()
        {
            Assert.IsTrue(_searchdiv.Displayed);
        }

       

    }
}
