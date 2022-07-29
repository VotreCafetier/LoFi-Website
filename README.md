# This is the lofi project
## Using
### Front
- React
- Three.js
Theme https://bootswatch.com/lumen/

### Back
- C# Net Core


## Left todo [FRONT]
- Fix package vulnerability
- Add a 3d scene
- Add a Room
- Add a player
- Send 2 request for password
  - First request will only be the plain password, then return the hashed password
  - Second request send all info with hashed password


## Left todo [BACK]
- Create all routes
- READ, CREATE, UPDATE User
- Create Password hasher
- READ Location
- READ Types
- READ Items/Item{ID}
- Create transactions (Inside user)
- Create a login table which shows the ip, the login
- Add SpotifyID
- Add YoutubeID

# All API Routes
/Items_
/Item{ID}_
/Locations_
/Types_

[Show only connected user]/User{ID}/Items_
[Show only connected user]/User{ID}/Buy{ItemID}_
[Show only connected user]/User{ID}/Update_
/User/Register_
/User/Login_


# Security
## How it will work
No session nor token, it will be a cookie id which is ran against the db



