using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Helpers
{
    public class UserCredentialsValidator
    {
        public bool AreUserCredentialsValid(UserCredentialsDTO userCredentialsDTO)
        {
            if (IsUserNameValid(userCredentialsDTO.UserName) && IsPasswordValid(userCredentialsDTO.Password)) return true;
            return false;
        }

        public bool IsPasswordValid(string password)
        {
            //password conditions: Length 6-30, atleast one symbol, number, upperchar
            if (password == null || password.Length < 6 || password.Length > 30 || !password.Any(ch => char.IsPunctuation(ch) || char.IsSymbol(ch)) ||
                 !password.Any(ch => char.IsDigit(ch)) || !password.Any(ch => char.IsUpper(ch))) return false;
            return true;
        }

        public bool IsUserNameValid(string userName)
        {
            //username conditions: Length 3-15, Only letters and numbers
            if (userName == null || userName.Length < 3 || userName.Length > 15 || userName.Any(ch => !char.IsLetterOrDigit(ch))) return false;
            return true;
        }
    }
}
