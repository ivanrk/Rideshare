namespace Rideshare.Service.Contracts.Forum
{
    public interface IHtmlService
    {
        string Sanitize(string htmlContent);
    }
}
