INSERT INTO iLocation (iLocationName)
VALUES 
('Floor'),
('Wall')
;
INSERT INTO iType(iTypeName)
VALUES 
('Furniture'),
('Room'),
('Animal')
;
INSERT INTO lUser (uName,uEmail,uPWD,uWallet,uTimeListened,uBackgroundHex)
VALUES 
('Cafetier', 'cafetier57@icloud.com', 'Abc123$', 1500, 14, 'FFE6E6'),
('JohnDoe', 'jdoe@exemple.com', 'Abc123$', 16, 1, 'FFF'),
('Cafetier', 'jane.doe@icloud.com', 'Abc123$', 1500, 14, 'FFE6E6'),
('Cafetier', 'abc@icloud.com', 'Abc123$', 1500, 14, 'FFE6E6')
;
INSERT INTO Item (iName, iPrice, iDescription, iDiscount, iSizeX, iSizeY, iLocationID, iTypeID, iImage)
VALUES 
('Cat', 1400, 'The human finest companion', 
0, 0, 0, 1, 3, 'Help.jpg'),
('Wood Desk', 200, 'Normal wood desk. A bit used but gets the job done', 
0, 2, 3, 1, 1, 'Help.jpg'),
('Woman painting', 50, 'Painting of a woman. Not much more to say', 
15, 2, 2, 2, 1, 'Help.jpg')
;
INSERT INTO lTransaction (ITEMID, USERID)
VALUES 
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 2),
(3, 4)
;