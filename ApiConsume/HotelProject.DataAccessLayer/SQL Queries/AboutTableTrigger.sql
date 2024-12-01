SELECT * FROM Abouts

--Room Increase Trigger
CREATE TRIGGER RoomIncrease
ON Rooms 
AFTER INSERT
As
UPDATE Abouts SET RoomCount = RoomCount+1 

--RoomDecrease Trigger

CREATE TRIGGER RoomDecrease 
ON Rooms
AFTER DELETE
As
Update Abouts SET RoomCount = RoomCount - 1

--Staff Increase Trigger
CREATE TRIGGER StaffIncrease 
ON Staffs
AFTER INSERT
As 
Update Abouts SET StaffCount = StaffCount+1

--Staff Decrease Trigger
CREATE TRIGGER StaffDecrease 
ON Staffs
AFTER DELETE	
As 
Update Abouts SET StaffCount = StaffCount-1

--Guest Increase Trigger
CREATE TRIGGER GuestIncrease
ON Guests
AFTER INSERT
AS
UPDATE Abouts SET CustomerCount = CustomerCount+1

--Guest Decrease Trigger
CREATE TRIGGER GuestDecrease
ON Guests
AFTER DELETE	
AS
UPDATE Abouts SET CustomerCount = CustomerCount-1


