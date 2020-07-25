namespace Rideshare.Services.Forum
{
    public interface IHtmlService
    {
        string Sanitize(string htmlContent);
    }
}
