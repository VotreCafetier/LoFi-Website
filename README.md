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
- Remove unnessessary rows when return data
- Create delete function in api (where you just unlist the user)
- READ, CREATE, UPDATE User
- Create Password hasher
- READ Location
- READ Types
- READ Items/Item{ID}
- Create transactions (Inside user)
- Create a login table which shows the ip, the login
- Add SpotifyID
- Add YoutubeID

# API Routes
## Public
/api/Items\
/api/Item{ID}\
/api/Locations\
/api/Types\
/api/User/Register\
/api/User/Login 

## Private
/api/User{ID}/Items\
/api/User{ID}/Buy{ItemID}\
/api/User{ID}/Update


# Security
## How it will work
No session nor token, it will be a cookie id which is ran against the db



