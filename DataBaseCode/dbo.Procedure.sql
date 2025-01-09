CREATE PROCEDURE [dbo].[Procedure]
	@EmpNo int ,
	@Name varchar(50),
	@Basic  decimal(18,2),
	@DeptNo int
AS
	insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)
RETURN 0
