--1) User Details Table
CREATE table UserDetails(
	UserId int PRIMARY KEY,
    UserName varchar(100) NOT NULL,
    Password varchar(255) NOT NULL
);

--2) Note
CREATE table Note(
	NoteId int PRIMARY KEY,
    NoteMessage text,
    IsDeleted boolean NOT NULL DEFAULT 0
);

--3) NoteUserAssociation
CREATE table NoteUserAssociation(
	NoteUserAssnId int PRIMARY KEY,
	NoteId int NOT NULL,
    UserId int NOT NULL,
    UserRoleId int NOT NULL
);
ALTER TABLE NoteUserAssociation MODIFY COLUMN NoteUserAssnId INT auto_increment;

ALTER TABLE NoteUserAssociation
ADD CONSTRAINT FK_NoteId foreign key (NoteId) REFERENCES Note(NoteId);

ALTER TABLE NoteUserAssociation
ADD CONSTRAINT FK_UserId foreign key (UserId) REFERENCES UserDetails(UserId);

--4) User RoleType
	CREATE table UserRoleType(
	UserRoleTypeId int PRIMARY KEY,
	RoleTypeName varchar(100) NOT NULL);
