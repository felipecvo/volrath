namespace Volrath {
  using System;
  using System.Security.Cryptography;
  using System.Text;
  using System.Linq;
  using ActiveRecord.net;
  using ActiveRecord.net.Attributes;
  using ActiveRecord.net.Validation;
  using System.Web;
  using System.Web.Security;

  [ValidatesPresenceOf(PropertyName = "Name")]
  [ValidatesPresenceOf(PropertyName = "Email")]
  [ValidatesPresenceOf(PropertyName = "PasswordHash")]
  [Serializable]
  public class User : ActiveRecordBase<User> {
    public User() {
      this.BeforeSave += new CallbackHandler(User_BeforeSave);
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    [CustomProperty]
    public string Password { get; set; }
    public string PasswordHash { get; internal set; }
    public int Status { get; set; }
    public DateTime PasswordExpires { get; set; }
    public int LoginFailedAttempts { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    bool User_BeforeSave(object sender) {
      if (!string.IsNullOrEmpty(Password)) {
        PasswordHash = EncodePassword(Password);
      }
      return true;
    }

    private static string EncodePassword(string password) {
      byte[] bytes = Encoding.Unicode.GetBytes(password);
      byte[] src = Convert.FromBase64String(Settings.SaltBase64);
      byte[] dst = new byte[src.Length + bytes.Length];
      Buffer.BlockCopy(src, 0, dst, 0, src.Length);
      Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
      HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
      byte[] inArray = algorithm.ComputeHash(dst);
      return Convert.ToBase64String(inArray);
    }

    /// <summary>
    /// Validate user credentials against database.
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns>if it is valid, return true, otherwise false.</returns>
    public static bool Validate(string login, string password) {
      var hash = EncodePassword(password);

      var user = (from u in User.db
                  where u.Email == login && u.PasswordHash == hash
                  select u).Single();

      return user != null;
    }

    public static bool DoLogin(string login, string password) {
      var hash = EncodePassword(password);

      var user = (from u in User.db
                  where u.Email == login && u.PasswordHash == hash
                  select u).Single();

      var rememberMe = !string.IsNullOrEmpty(HttpContext.Current.Request.Form["rememberMe"]);

      if (user != null) {
        var activity = new UserActivity() {
          Ip = GetIP(),
          OccurrenceDate = DateTime.Now,
          UserId = user.Id,
          Activity = (int)ActivityEnum.Login
        };
        activity.Save();

        SetAuthCookie(user, rememberMe);
      }

      var url = HttpContext.Current.Request.Params["continue"];
      if (!string.IsNullOrEmpty(url)) {
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.StatusCode = 302;
        HttpContext.Current.Response.RedirectLocation = HttpUtility.UrlDecode(url);
        HttpContext.Current.Response.End();
      }
      return user != null;
    }

    public static void DoLogout() {
      string str = string.Empty;
      if (HttpContext.Current.Request.Browser["supportsEmptyStringInCookieValue"] == "false") {
        str = "NoCookie";
      }
      HttpCookie cookie = new HttpCookie("SID", str);
      cookie.Domain = Settings.CookieDomain;
      cookie.Path = "/";
      cookie.Expires = new DateTime(1990, 10, 12); ;

      HttpContext.Current.Response.Cookies.Remove("SID");
      HttpContext.Current.Response.Cookies.Add(cookie);
    }

    private static void SetAuthCookie(User user, bool rememberMe) {
      var ticket = new FormsAuthenticationTicket(1, "SID", DateTime.Now, DateTime.Now.AddMonths(1), rememberMe, user.Id.ToString(), "/");
      var data = FormsAuthentication.Encrypt(ticket);

      HttpCookie cookie = new HttpCookie("SID", data);
      cookie.Domain = Settings.CookieDomain;
      cookie.Path = ticket.CookiePath;
      if (ticket.IsPersistent) {
        cookie.Expires = ticket.Expiration;
      }

      HttpContext.Current.Response.Cookies.Add(cookie);
    }

    private static string GetIP() {
      if (HttpContext.Current != null) {
        var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ip == null) {
          ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        return ip;
      }
      return null;
    }
  }
}
