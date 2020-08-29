namespace api_dev_boost_auth.Models
{
    public class AppSettings
    {
        public AppSettings()
        {
        }

        public string TokenLimitMinutesExpire { get; set; }
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
        public string Emitter { get; set; }
        public string ValidOn { get; set; }
    }
}
