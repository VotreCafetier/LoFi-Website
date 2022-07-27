-- This database is optimized for postgres
DROP 
  TABLE IF EXISTS lTransaction;
DROP 
  TABLE IF EXISTS Item;
DROP 
  TABLE IF EXISTS lUser;
DROP 
  TABLE IF EXISTS iLocation;
DROP 
  TABLE IF EXISTS iType;


-- Create DB
CREATE TABLE iLocation (
  iLocationID BIGSERIAL NOT NULL, 
  iLocationName VARCHAR NOT NULL, 
  PRIMARY KEY(iLocationID), 
  UNIQUE(iLocationName)
);
CREATE TABLE iType(
  iTypeID BIGSERIAL NOT NULL, 
  iTypeName VARCHAR NOT NULL, 
  PRIMARY KEY(iTypeID), 
  UNIQUE(iTypeName)
);
CREATE TABLE lUser(
  USERID BIGSERIAL NOT NULL, 
  CookieID CHAR(128),
  uName VARCHAR NOT NULL, 
  uEmail VARCHAR NOT NULL, 
  uPWD VARCHAR NOT NULL, 
  uWallet BIGINT NOT NULL DEFAULT 0, 
  uTimeListened FLOAT NOT NULL DEFAULT 0, 
  uBackgroundHex VARCHAR(7) NOT NULL DEFAULT 'FFE6E6', 
  uDateCreated TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, 
  uLastLogin TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, 
  uLastNameChange TIMESTAMP, 
  uLastEmailChange TIMESTAMP, 
  uLastPWDChange TIMESTAMP, 
  isOnline BOOLEAN DEFAULT FALSE,
  isBanned BOOLEAN DEFAULT FALSE,

  PRIMARY KEY(USERID), 
  UNIQUE(uName, uEmail)
);
CREATE TABLE Item(
  ITEMID BIGSERIAL NOT NULL, 
  iName VARCHAR NOT NULL, 
  iPrice BIGINT NOT NULL, 
  iDescription TEXT, 
  iDateCreated TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, 
  iDiscount SMALLINT NOT NULL DEFAULT 0, 
  iSizeX SMALLINT NOT NULL, 
  iSizeY SMALLINT NOT NULL, 
  iRotation SMALLINT NOT NULL DEFAULT 0, 
  iPosition SMALLINT, 
  iImage VARCHAR NOT NULL,
  
  iLocationID BIGINT NOT NULL, 
  iTypeID BIGINT NOT NULL, 
  PRIMARY KEY(ITEMID), 
  FOREIGN KEY (iLocationID) REFERENCES iLocation (iLocationID), 
  FOREIGN KEY (iTypeID) REFERENCES iType (iTypeID), 
  UNIQUE(iName)
);
CREATE TABLE lTransaction(
  TransactionID BIGSERIAL NOT NULL, 
  ITEMID BIGINT NOT NULL, 
  USERID BIGINT NOT NULL, 
  TransactionDate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, 
  PRIMARY KEY(TransactionID), 
  FOREIGN KEY (ITEMID) REFERENCES Item (ITEMID), 
  FOREIGN KEY (USERID) REFERENCES lUser (USERID)
);
-- indexes (only foreign, unique is auto)
CREATE INDEX FK_Item ON Item (iLocationID, iTypeID);
CREATE INDEX FK_Transaction ON lTransaction (ITEMID, USERID);
