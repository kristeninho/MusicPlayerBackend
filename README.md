# MusicPlayerBackend
C# 6.0 ASP.NET Core project done using Test Driven Development and Repository Pattern. Also uses XUnit, Moq, Azure SQL, Azure Blob storage, JWT auth and will eventually be dockerized. (WIP)

Started this project using TDD, but stopped before starting with JWT auth. Nevertheless all tests will be done sooner or later.

# Quick overview
This is a backend for a Music Player application, where user can upload albums/music and listen to their work.

# Current logic: 
- Anyone can create an account for himself/herself. Password will be hashed and salted.
- User logs into his account and will generate JWT.
- Using JWT the user can access all the endpoints. (Information about the endpoints is in the controllers)
- All of the request go through a validator, which checks if the request body is correct.
- From Program.cs you can choose whether to use local DB or Azure SQL DB by enabling the correct one.
- The azure secrets are kept in a secret appsettings
- When adding an Album or Song the blob of image and song will be uploaded to Azure Blob Storage "images" or "songs" container and will save the name of the container file into the database. By that name the file will later queried from the storage. Currently the solution only supports .mp3 and .jpg files. 
- When adding an album and you don't send an image, it will use some default image.
- When adding a song and you don't specify an album, it will send it to a generic "DEMOS" album.

# Logic changes to be done
- Accounts will only be creatable manually by an admin to limit users on the application.
- Allow more file formats like .WAV for audio and many different for images.

