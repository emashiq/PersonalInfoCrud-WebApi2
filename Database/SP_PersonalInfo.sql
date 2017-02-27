--Insert procedure
Create procedure SP_AddPersonalInfo
@Name Varchar(200),
@Age int,
@DOB date,
@Address varchar(300),
@Status varchar(200),
@Sl int out
as
Begin 
Insert into Info(Name,Age,DOB,Address,Status,DataInsertTime) values(@Name,@Age,@DOB,@Address,@Status,GETDATE())
Select @Sl = SCOPE_IDENTITY()
end 


--Update procedure
Create procedure SP_UpdatePersonalInfo
@Name Varchar(200),
@Age int,
@DOB date,
@Address varchar(300),
@Status varchar(200),
@DataInsertTime datetime ,
@Sl int 

as
Begin
UPDATE info set
Name=@Name,Age=@Age,DOB=@DOB,Address=@Address,Status=@Status,DataInsertTime=GetDate()
where Sl=@Sl
end

--Delete procedure
 Create procedure SP_DeletePersonalInfo
(
@SL int
)
As
Begin 
Delete From Info where SL = @SL
End

--select procedure
Create procedure SP_SelectPersonalInfo
(
@Name varchar(200) = ''
)
As
Begin
Select * From Info 
End