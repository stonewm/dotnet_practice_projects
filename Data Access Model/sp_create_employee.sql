create procedure sp_create_employee
	@emp_id int,
	@name varchar(50),
	@gender varchar(50),
	@email varchar(50),
	@phone_number varchar(50),
	@city varchar(50)
as
begin
    insert into employees (emp_id, [name], gender, email, phone_number, city)
	  values (@emp_id,@name, @gender, @email, @phone_number, @city);
End

exec dbo.sp_create_employee 1001, 'Stone', 'F', 'stone@qq.com', '13800', 'Wuhan';