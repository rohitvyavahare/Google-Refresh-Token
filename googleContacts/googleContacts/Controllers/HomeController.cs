using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.GData.Extensions.Apps;
using Google.GData.Client;
using Google.Contacts;
using System.Net;
using System.Text;

namespace googleContacts.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {


            string str;
            string clientId = "";
            string clientSecret = "";
            string redirectUri = "";
            string scopes = "https://www.google.com/m8/feeds/";
            string url = null ;

            OAuth2Parameters parameters = new OAuth2Parameters
            {
                ClientId = clientId,
                ClientSecret = clientSecret,
                RedirectUri = redirectUri,
                Scope = scopes,
                AccessType = "offline",
                ApprovalPrompt = "force"

            };

            if ((str = Request["code"]) != null)
            {

                parameters.AccessCode = str;
                OAuthUtil.GetAccessToken(parameters);
                System.IO.File.WriteAllText(@"C:\Users\rohit\temp.txt", parameters.RefreshToken);
                StringBuilder sb = new StringBuilder();
                sb.Append("Access_Token:");
                sb.Append(parameters.AccessToken);
                ViewBag.Message = sb.ToString();
                return View();
            }
            else
            {
                string text = null;
                try
                {
                    text = System.IO.File.ReadAllText(@"C:\Users\rohit\temp.txt");
                }
                catch (Exception e)
                {

                }
                finally
                {
                    if (text == null)
                    {
                       url = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
                    }
                    else
                    {
                        parameters.RefreshToken = text;
                        OAuthUtil.RefreshAccessToken(parameters);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Access_Token:");
                        sb.Append(parameters.AccessToken);
                        url = sb.ToString();
                    }
                    
                    ViewBag.Message = url;
                    
                }
                return View();
            }
            
            
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}