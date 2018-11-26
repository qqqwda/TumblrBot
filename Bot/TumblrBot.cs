using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.IE;

namespace Bot
{
    public class TumblrBot
    {
        string gecko = @"C:\Users\cvargas\Desktop\";
        public string Username { get; set; }
        public string Password { get; set; }
        public IWebDriver Driver { get; set; }

        public List<String> ListaFollowing { get; set; }
        public TumblrBot(string username, string password)
        {
            this.Password = password;
            this.Username = username;
            this.Driver = new FirefoxDriver(gecko);
            this.ListaFollowing = new List<string>();

        }

        public void Login()
        {
            var usernameElement = Driver.FindElement(By.XPath("//input[@name='determine_email']"));
            usernameElement.Clear();
            usernameElement.SendKeys(this.Username);

            Driver.FindElement(By.XPath("//button[@id='signup_forms_submit']")).Click();
            Driver.FindElement(By.XPath("//a[@class='forgot_password_link']")).Click();
            
            var PasswordElement = Driver.FindElement(By.XPath("//input[@id='signup_password']"));
            
            PasswordElement.SendKeys(this.Password);
            Driver.FindElement(By.XPath("//button[@id='signup_forms_submit']")).Click();
        }

        public void GoToFollowersPage()
        {
            Driver.Navigate().GoToUrl("https://www.tumblr.com/blog/rrtyiu/followers");

        }

        public List<String> GetFollowers()
        {
            var item = Driver.FindElement(By.XPath("//div[@class='followers']"));
            Console.WriteLine(item.GetAttribute("innerHTML"));
            var items = item.FindElements(By.XPath("//a[@class='avatar']"));
            List<String> Lista = new List<string>();
            foreach (var follower in items)
            {
                string href = follower.GetAttribute("href");
                Lista.Add(href);
                Console.WriteLine(href);
            }

            return Lista;
        }

        public List<String> GetFollowing(int pag)
        {
            Driver.Navigate().GoToUrl("https://www.tumblr.com/following/"+pag);
            var item = Driver.FindElement(By.XPath("//div[@id='left_column']"));
            var items = item.FindElements(By.XPath("//a[@class='avatar']"));
            foreach (var following in items)
            {
                string href = following.GetAttribute("href");
                ListaFollowing.Add(href);
                Console.WriteLine(href);
            }
            int next = pag + 25;
            if (next < 300) { 
            GetFollowing(next);
                 }
            return ListaFollowing;
        }
    }
}
