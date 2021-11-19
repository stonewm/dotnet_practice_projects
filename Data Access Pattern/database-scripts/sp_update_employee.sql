
create procedure sp_update_employee
	@emp_id int,
	@name varchar(50),
	@gender varchar(50),
	@email varchar(50),
	@phone_number varchar(50),
	@city varchar(50)
as
begin
   update employees set name=@name, gender=@gender, email=@email, phone_number=@phone_number, city=@city
     where emp_id = @emp_id;
end