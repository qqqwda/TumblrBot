using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            TumblrBot tbot = new TumblrBot("cursedelboom@gmail.com","");
            tbot.Driver.Navigate().GoToUrl("https://www.tumblr.com/login");
            tbot.Login();
            tbot.GoToFollowersPage();
            var followers = tbot.GetFollowers().Distinct();
            var followings = tbot.GetFollowing(0).Distinct();

            


            Console.WriteLine("----Followers-----");
            foreach (var item in followers)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine("--------End-------");
            Console.WriteLine();

            Console.WriteLine("----Following-----");
            foreach (var item in followings)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------End-------");
            Console.WriteLine();
            Console.WriteLine("----Not Following-----");
            foreach (var following in followings)
            {
                var cant = followers.Where(f => f.Equals(following));
                if (cant.Count() == 0)
                {
                    Console.WriteLine(following);
                }

            }
            Console.WriteLine("---------END-----------");
            Console.WriteLine();
            Console.WriteLine("----Following back-----");
            foreach (var following in followings)
            {
                var cant = followers.Where(f => f.Equals(following));
                if (cant.Count() == 1)
                {
                    Console.WriteLine(following);
                }

            }
            Console.WriteLine("---------END-----------");
            Console.ReadLine();

            //InstagramBot bot = new InstagramBot("normiemes777","");
            //bot.Driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/?source=auth_switcher");
            //bot.Login();
            //bot.DarLike("instachile");

            //string gecko = @"C:\Users\cvargas\Desktop\";
            //IWebDriver Bot = new FirefoxDriver(gecko);
            //Bot.Navigate().GoToUrl("https://www.instagram.com/");
        }

        public class InstagramBot
        {
            string gecko = @"C:\Users\cvargas\Desktop\";
            public string Username { get; set; }
            public string Password { get; set; }
            public IWebDriver Driver { get; set; }
            public InstagramBot(string username, string password)
            {
                this.Username = username;
                this.Password = password;
                this.Driver = new FirefoxDriver(gecko);
            }

            public void Login()
            {
                var usernameElement = Driver.FindElement(By.XPath("//input[@name='username']"));
                usernameElement.Clear();
                usernameElement.SendKeys(this.Username);

                var passwordElement = Driver.FindElement(By.XPath("//input[@name='password']"));
                passwordElement.Clear();
                passwordElement.SendKeys(this.Password);

                Driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            }

            public void DarLike(String hashtag)
            {
                Driver.Navigate().GoToUrl("https://www.instagram.com/explore/tags/" + hashtag);
                var list = Driver.FindElements(By.TagName("a"));
                Console.WriteLine();
               // foreach (var item in list)
                //{
                   //string link = item.GetAttribute("href");
                   //Console.WriteLine(link.ToString());
                   //Driver.Navigate().GoToUrl(link);

                    
                    //var a = Driver.FindElement(By.XPath("//a[@href]"));
                    //Console.WriteLine(a.GetAttribute("href"));
                //}

                for (int i = 1; i < list.Count; i++)
                {
                    string link = list[i].GetAttribute("href");
                    Driver.Navigate().GoToUrl(link);
                }





            }
                
        }
    }
}
