
create procedure sp_list_all_employees
as
begin
    select * from employees order by emp_id;
end

create procedure sp_find_employee_by_id
    @emp_id int
as
begin
    select * from employees where emp_id=@emp_id;
end

create procedure sp_find_employee_by_name
    @name varchar(50)
as
begin
    select * from employees where [name] like '%' + @name + '%';
end
