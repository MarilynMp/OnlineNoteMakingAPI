--1) Delete User Notes Association

delimiter $$
CREATE PROCEDURE usp_DeleteNoteUserAssociation(
	NoteUserAssociationId int
)
BEGIN

	DELETE 
    FROM NUA
    USING `NoteUserAssociation` AS NUA
    WHERE NUA.NoteUserAssnId = NoteUserAssociationId;
    
    SELECT row_count();
END;$$

--2) Get Notes For User
delimiter $$
CREATE PROCEDURE usp_GetNotesForUser(
	UserId int
)
BEGIN

	SELECT N.NoteId, N.NoteMessage, NUA.UserId, NUA.UserRoleId
    FROM NoteUserAssociation NUA
    JOIN Note N
    ON NUA.NoteId = N.NoteId
    WHERE NUA.UserId = UserId;
    
END;$$

--3) Delete Note
CREATE PROCEDURE usp_DeleteNote(
	NoteId int
)
BEGIN

	DELETE 
    FROM NUA
    USING `NoteUserAssociation` AS NUA
    WHERE NUA.NoteId = NoteId;
	
    DELETE
    FROM N
    using `Note` AS N
    WHERE N.NoteId = NoteId;
    
    SELECT row_count();
END;$$

--4) update note
delimiter $$
CREATE PROCEDURE usp_UpdateNote(
	NoteId int,
    NoteMessage text
)
BEGIN
	UPDATE Note N
    SET N.NoteMessage = NoteMessage
    WHERE N.NoteId = NoteId;
    
    SELECT row_count();
END;$$

--5) Add Association between user and note
delimiter $$
CREATE PROCEDURE usp_AddNoteUserAssociation(
	NoteId int,
    UserId int,
    UserRoleId int
)
BEGIN

	IF NOT EXISTS(SELECT NoteUserAssnId FROM NoteUserAssociation N WHERE N.NoteId = NoteId AND N.UserId = UserId LIMIT 1) THEN
	BEGIN
		INSERT INTO NoteUserAssociation(NoteId,UserId,UserRoleId)
		VALUES(NoteId,UserId,UserRoleId);
    END;
    ELSE
    BEGIN
		UPDATE NoteUserAssociation NUA
        SET NUA.UserRoleId = UserRoleId
		WHERE NUA.NoteId = NoteId AND NUA.UserId = UserId;
    END;
	END IF;
END$$

--6) usp_AddNote
delimiter $$
CREATE PROCEDURE usp_AddNote(
	NoteMessage Text
)
BEGIN
	INSERT INTO Note(NoteMessage)
    VALUES(NoteMessage);
    
    SELECT @@identity;
END;$$

--7) Get User Roles
delimiter $$
CREATE PROCEDURE usp_GetUserRoles()
BEGIN

	SELECT * 
    FROM UserRoleType;
    
END;$$

--8) Get Users for Note
delimiter $$
CREATE PROCEDURE usp_GetUsersForNote(
	NoteId int
)
BEGIN

	SELECT NUA.NoteId, NUA.NoteUserAssnId, NUA.UserId, U.UserName, UR.RoleTypeName, UR.UserRoleTypeId
    FROM NoteUserAssociation NUA
    JOIN UserDetails U
    ON NUA.UserId = U.UserId
    JOIN UserRoleType UR
    ON NUA.UserRoleId = UR.UserRoleTypeId
    WHERE NUA.NoteId = NoteId;
    
END;$$

--9) CheckIfUserExistsForCreds
delimiter $$
CREATE PROCEDURE usp_CheckIfUserExistsForCreds(
	UserName varchar(100),
    UserPassword varchar(255)
)
BEGIN
	SELECT true AS isValidCred 
    FROM UserDetails UD
    WHERE UD.UserName = UserName AND UD.Password = MD5(UserPassword)
    LIMIT 1;
END;$$

--10) Add User 
delimiter $$
CREATE PROCEDURE usp_AddUser(
	UserName varchar(100),
    UserPassword varchar(255)
)
BEGIN
	INSERT INTO UserDetails(UserName,Password)
    VALUES(UserName,MD5(UserPassword));
END;$$

--11) usp_GetUserDetailsByName

delimiter $$
CREATE PROCEDURE usp_GetUserDetailsByName(
	UserName varchar(100)
)
BEGIN
	SELECT *
    FROM UserDetails UD
    WHERE UD.UserName = UserName
    LIMIT 1;
END;$$

--12) usp_GetUserDetailsById
delimiter $$
CREATE PROCEDURE usp_GetUserDetailsById(
	UserIdentifier int
)
BEGIN
	SELECT *
    FROM UserDetails
    WHERE UserId = UserIdentifier
    LIMIT 1;
END;$$

--13) Get All Users
delimiter $$
CREATE PROCEDURE usp_GetAllUserDetails()
BEGIN
	SELECT *
    FROM UserDetails;
END;$$ 
