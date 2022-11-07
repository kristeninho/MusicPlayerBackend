using MusicPlayerBackend.Models;
using MusicPlayerBackend.Models.DTOs;

namespace MusicPlayerBackend.Helpers
{
    public class Validator
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
        public bool IsAlbumDTOValid(AlbumDTO entity)
        {
            if (entity == null
                || entity.CoverImage == null
                || entity.Id.ToString() == "00000000-0000-0000-0000-000000000000"
                || IsUserNameValid(entity.UserName)
                || entity.Duration.Length < 4
                || entity.Songs.Count < 1
                || entity.Name == null // maybe unnecessary
                || entity.Name.Length < 1
                || DateTime.Compare(DateTime.Now, entity.UploadDate) < 0
                || !AreSongDTOsValid(entity.Id, entity.Songs)
                ) return false;
            return true;
        }
        public bool AreSongDTOsValid(Guid albumId, List<SongDTO> songs)
        {
            foreach (var song in songs)
            {
                if (!IsSongDTOValid(song, albumId)) return false;                
            }
            return true;
        }
        public bool IsSongDTOValid(SongDTO song, Guid albumId)
        {
            if (song.Id.ToString() == "00000000-0000-0000-0000-000000000000"
                    || song.AlbumId != albumId
                    || song.Duration.Length < 4
                    || song.Name.Length < 1
                    || song.SongFile == null
                    || DateTime.Compare(DateTime.Now, song.UploadDate) < 0) return false;
            return true;
        }
    }
}
