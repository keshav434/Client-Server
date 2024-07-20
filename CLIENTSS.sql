create database clients;
CREATE TABLE Users_Tab (
LoginSlNo INT(200),
UserID varchar(200)  NOT NULL,
Surname varchar(200) NULL,
 FornameSlNo INT(200),
title varchar(200),
PositionSlNo INT(200),
PhoneSlNo INT(200),
EmailSlNo INT(200),
LocationSlNo INT(200),


  PRIMARY KEY (UserID),
  CONSTRAINT PK_userlogins foreign key (LoginSlNo) REFERENCES Login_Tab1 (LoginSlNo),
CONSTRAINT PK_userforname FOREIGN KEY (FornameSlNo) REFERENCES Fornames_Tab(FornameSlNo),
CONSTRAINT PK_userposition FOREIGN KEY (PositionSlNo) REFERENCES Positions_Tab(PositionSlNo),
CONSTRAINT PK_userphone FOREIGN KEY (PhoneSlNo) REFERENCES Phone_Tab(PhoneSlNo),
CONSTRAINT PK_useremail FOREIGN KEY (EmailSlNo) REFERENCES Emails_Tab(EmailSlNo),
CONSTRAINT PK_userlocation FOREIGN KEY (LocationSlNo) REFERENCES Location_Tab(LocationSlNo)
);

INSERT INTO Users_Tab VALUES (01,'101','Premsagar',01,'Mr', 01,01,01, 01); 
INSERT INTO Users_Tab  VALUES (02,'102','Maxweller',02,'Mr', 02,02, 02, 02); 
INSERT INTO Users_Tab  VALUES (03,'103','Waterloo',03,'Mrs', 03,03, 03, 03); 
INSERT INTO Users_Tab  VALUES (04,'104','Dixon',04,'Mr',04,04, 04, 04); 
INSERT INTO Users_Tab  VALUES (05,'105','Hunter',05,'Mr',05,05, 05, 05); 
INSERT INTO Users_Tab  VALUES (06,'106','Jakeson',06,'Mr',06,06, 06, 06); 
INSERT INTO Users_Tab  VALUES (07,'107','Paul',07,'Mrs',07,07, 07, 07); 
INSERT INTO Users_Tab  VALUES (08,'108','Gupta',08,'Mr',08,08,08, 08); 
INSERT INTO Users_Tab  VALUES (09,'109','Scot',09,'Mr', 09,09, 09, 09); 
INSERT INTO Users_Tab  VALUES (10,'110','Taylor',10,'Mr', 10,10, 10, 10); 

CREATE TABLE Login_Tab1 (

  LoginSlNo INT NOT NULL,
  Login_ID  VARCHAR(500) ,
  CONSTRAINT loginid_regchk CHECK( NOT REGEXP_LIKE(Login_ID, '[()&:%/?!]')),
  PRIMARY KEY (LoginSlNo)
);  


INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 01, '1223'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 02, '1531'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 03, '1276'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 04, '1543'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 05, '1531'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 06, '1864'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 07, '1355'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 08, '1223'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 09, '1234'); 
INSERT INTO Login_Tab1 ( LoginSlNo, Login_ID) values ( 10, '1229'); 

CREATE TABLE Positions_Tab (
  
   PositionSlNo  INT(100) NOT NULL,
   Positionc  VARCHAR(500),
  PRIMARY KEY (PositionSlNo)
); 


INSERT INTO Positions_Tab values ('01','Student');
INSERT INTO Positions_Tab values ('02','Lecturer of computer science');
INSERT INTO Positions_Tab  values ('03','Lecturer of computer science');
INSERT INTO Positions_Tab  values ('04','Student');
INSERT INTO Positions_Tab  values ('05','Student');
INSERT INTO Positions_Tab  values ('06','Student');
INSERT INTO Positions_Tab  values ('07','Student');
INSERT INTO Positions_Tab  values ('08','Student');
INSERT INTO Positions_Tab  values ('09','Lecturer of computer science');
INSERT INTO Positions_Tab values ('10','Student');



CREATE TABLE Emails_Tab (
  
   EmailSlNo  INT(100),
   Email_id VARCHAR(100),
   PRIMARY KEY (EmailSlNo)
);


INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('01','K.Premsagar@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('02','S.Maxweller@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('03','L.Waterloo@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('04','J.Dixon@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('05','H.Hunter@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('06','M.Jackson@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('07','S.paul@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('08','B.Gupta@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('09','M.Scout@hull.ac.uk');
INSERT INTO Emails_Tab ( EmailSlNo, Email_id) values ('10','B.Taylor@hull.ac.uk');

CREATE TABLE Fornames_Tab (
 
   FornameSlNo INT(100),
   Forname  VARCHAR(100),
   PRIMARY KEY (FornameSlNo)
); 
select* from Fornames_Tab;
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('01','Keshav');
INSERT INTO Fornames_Tab (FornameSlNo, Forname) values ('02','Sam');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('03','Louisa');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('04','John');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('05','Harry');
INSERT INTO Fornames_Tab (FornameSlNo, Forname) values ('06','Micheal');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('07','Samantha');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('08','Brad');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('09','Mike');
INSERT INTO Fornames_Tab ( FornameSlNo, Forname) values ('10','Bareny');

CREATE TABLE Location_Tab (
  
   LocationSlNo INT(100),
   Location VARCHAR(100),
   PRIMARY KEY (LocationSlNo)
 
); 

INSERT INTO Location_Tab ( LocationSlNo, Location) values ('01','London');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('02','In RB-336');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('03','In RB-456');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('04','Manchester');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('05','York');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('06','Preston');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('07','Beverley');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('08','Bradfort');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('09','In RB-123');
INSERT INTO Location_Tab ( LocationSlNo, Location) values ('10','London');

CREATE TABLE Phone_Tab(

    PhoneSlNo INT(100),
    Phone VARCHAR(100),
       PRIMARY KEY (PhoneSlNo)
   ); 

INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('01','+44 1234 46 5222');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('02','+44 8643 46 5222');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('03','+44 4325 76 5222');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('04','+44 4482 46 5892');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('05','+44 1579 46 6324');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('06','+44 1482 46 4934');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('07','+44 1998 56 5222');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('08','+44 7993 46 5222');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('09','+44 1992 46 3295');
INSERT INTO Phone_Tab ( PhoneSlNo,  Phone) values ('10','+44 1480 24 9831');

Select * from Location_Tab;
select * from Users_Tab;
select* from Users_Tab;
select* from Login_Tab1;
select* from Phone_Tab;
select* from Location_Tab;
select* from  Emails_Tab;
select* from Positions_Tab;