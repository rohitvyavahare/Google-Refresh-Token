# Google-Refresh-Token

Use Google Refresh token to access user information without authenticating user each time
I have created a simple project which does following things:
•	When we want to get user data/information from Google
•	We don't want to authenticate user each time.
•	So, I have created a sample example, using C# MVC, Javascript project.
•	If you want to use it, First register your app in google console and get client id and secret id.
•	Fill client id and secret id variables in HomeController.cs page.
•	Now, If you run it for the first time it will ask you to authenticate from google and then it will import your Google contacts. I am saving refresh token obtain from authentication in file, but you can use database, file is only for example purpose.
•	Now, once I have refresh token second time if you want to get user contacts then it use that refresh token to get contact and user don’t need to authenticate.
•	There are many example in PHP but I was not able to find anything in C#.


