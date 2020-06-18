namespace JobBoard.Api.Util
{
    public interface IUserService
    {
        string GenerateToken(int idToken, int? idProfile);
    }

}
