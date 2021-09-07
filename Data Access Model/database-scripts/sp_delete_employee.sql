create procedure sp_delete_employee
	@emp_id int
as
begin
    delete from employees where emp_id = @emp_id;
end
