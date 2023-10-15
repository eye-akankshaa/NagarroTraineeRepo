namespace BookEvents.Models
{
    public interface ISignUpUserModel
    {
        string ConfirmPassword { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}