namespace DataRepo.Interfaces;

public interface IHttpService
{
    public Task<string> GetAsync(string url, Dictionary<string, string> parameters);
}
