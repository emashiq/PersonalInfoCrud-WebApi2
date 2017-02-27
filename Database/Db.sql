
Use master
create Database PersonalInfo
go 
use PersonalInfo
go
Create Table Info
(
SL int Identity(1,1) primary key,
Name Varchar(200) not null,
Age int not null,
DOB date not null,
[Address] varchar(300) not null,
[Status] varchar(200) not null,
DataInsertTime datetime not null DEFAULT GETDATE()
)

