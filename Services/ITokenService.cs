namespace FirstAPI.Services;

public interface ITokenService
{
    string GenerateToken(string username);
}