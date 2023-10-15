namespace BookEvents.Models
{
    public interface ISignInModel
    {
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }
    }
}