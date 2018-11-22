

go
use Bank_DB
go
CREATE procedure Insert_client  @name nvarchar(20), @adress nvarchar(50), @city nvarchar(20),
@number int, @email nvarchar(20), @password nvarchar(100), @purse float,@status nvarchar(50)
as begin 
INSERT into Client(name,address,city,phone_number,email,passsword,purse,status)
	values(@name,@adress,@city,@number,@email,@password,@purse,@status);
return 1;
end
if  exists (select Client.name from Client where name='7888787') print 'таблица TAB есть';  
	else print 'таблицы TAB нет'
go
create function auto_user( @name nvarchar(20), @password nvarchar(50))
returns int
as begin
Declare @a int =0;
if  exists (select Client.name from Client where name=@name and passsword=@password) set @a=1;  
	else set @a=0;
	return @a;
end
go
 select dbo.auto_user('Dima','system');



--go
--drop procedure Insert_client;
--go


exec Insert_client @name='Dima',@adress='belorusskaya',@city='Minsk',@number=32155,@email='dima32155@mail.ru',@password='system',@purse=321,@status='ready';

select * from Client;
go
set ANSI_NULLS on
go 
set quoted_identifier on
go
Create function Take_id
(
@name nvarchar(50)
)
 returns int
 as begin 
 Declare @id int;
 select @id = Client.id from Client
 where name=@name
 return @id
 end
 go
  select dbo.Take_name(1);
  select dbo.Take_id('Dima');
  go
  create proc Take_user_info @id int
  as begin 
  select * from Client where id=@id;
  end
   exec Take_user_info @id=1;
   go
CREATE procedure Update_client   @adress nvarchar(50), @city nvarchar(20),
@number int, @email nvarchar(20), @password nvarchar(100),@passport nvarchar(50), @id int
as begin 
UPDATE Client SET address=@adress,city=@city,phone_number=@number,email=@email,passsword=@password,passport=@passport WHERE id=@id
end
go
--drop function Take_purse
Create function Take_purse
(
@id int
)
 returns float
 as begin 
 Declare @purse float;
 select @purse = Client.purse from Client
 where id=@id
 return @purse
 end
 go
 create function IsEmpty (@name nvarchar(20))
returns int
as begin 
Declare @a int =0;
if  exists (select Client.name from Client where name=@name) set @a=1;  
	else set @a=0;
	return @a;
end;


----------------MANAGER-----------------
Alter table Departament
alter column id int;
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
go
create function [dbo].[auto_manager]( @name nvarchar(20), @password nvarchar(50))
returns int
as begin
Declare @a int =0;
if  exists (select Employee.name from Employee where name=@name and Employee.password=@password) set @a=1;  
	else set @a=0;
	return @a;
end
go
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create function [dbo].[Take_id_manager]
(
@name nvarchar(50)
)
 returns int
 as begin 
 Declare @id int;
 select @id = Employee.id from Employee
 where name=@name
 return @id
 end
 select dbo.Take_id_manager('Dima');
 
GO
CREATE procedure Insert_manager  @name nvarchar(20),  @city nvarchar(20),
@number int, @email nvarchar(20), @password nvarchar(100),@departament nvarchar(50)
as begin 
INSERT into Employee(name,city,phone_number,email,password,departament_name)
	values(@name,@city,@number,@email,@password,@departament);
return 1;
end
go
drop procedure Insert_manager
go


go
 create function IsEmpty_depart (@name nvarchar(20))
returns int
as begin 
Declare @a int =0;
if  exists (select Employee.name from Employee where name=@name) set @a=1;  
	else set @a=0;
	return @a;
end;
go
create procedure ManTake__info @id int
  as begin 
  select * from Employee where id=@id;
  end
 go
 CREATE procedure Update_manager    @city nvarchar(50),
@number int, @email nvarchar(50), @password nvarchar(100), @id int
as begin 
UPDATE Employee SET city=@city,phone_number=@number,email=@email,password=@password WHERE id=@id
end
go
Create procedure Insert_service @name nvarchar(20), @term int,@persent int,@id_emp int,@depart nvarchar(50),
 @restriction real, @comment nvarchar(100)
as begin
Insert into Service(name,term,percent_t,id_employee,departament,restriction,date_create,comment)
values(@name,@term,@persent,@id_emp,@depart,@restriction,GETDATE(), @comment);
return 1;
end;
drop procedure Insert_service
 go
create function Take_service_id(@name nvarchar(20))
returns int
as begin 
Declare @id int
select @id = Service.id from Service
 where name=@name
 return @id
end;
go
insert into Purse_log(date_operatoin)
values(GetDate());

select name from Bank_DB.dbo.Service order by name desc;
go
alter proc take_name_serv @dep nvarchar(50)
as begin
select name from Bank_DB.dbo.Service where departament=@dep order by name desc ;
end
go

create proc take_name_serv_1 
as begin
select name from Bank_DB.dbo.Service  order by name desc ;
end
go
drop proc take_name_serv_1;
go
 create proc Take_service_info @name nvarchar(20)
 as begin
 select * from Service where name = @name;
 end;
 go
  CREATE TABLE History_Service(
	[id] [int]  NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[term] [int] NOT NULL,
	[percent_t] [int] NOT NULL,
	[id_employee] [int] NOT NULL,
	[departament] [nvarchar](50) NOT NULL,
	[restriction] [real] NOT NULL,
	[date_create] [datetime] NOT NULL,
	[comment] [nvarchar](100) NULL,
	date_delete datetime,
	id_employee_exe int
	)
--	drop table Bank_DB.dbo.History_Service
  exec Take_service_info @name='dima';
  go
  create proc delete_service @name nvarchar(20),@id int
  as begin
  insert into Bank_DB.dbo.History_Service (id,name,term,percent_t,id_employee,departament,restriction,date_create,comment,date_delete,id_employee_exe)
  values((select id from Service where name=@name),(select name from Service where name=@name),(select term from Service where name=@name),(select percent_t from Service where name=@name),
  (select id_employee from Service where name=@name),(select departament from Service where name=@name),(select restriction from Service where name=@name),(select date_create from Service where name=@name),
  (select comment from Service where name=@name),GetDate(),@id);
  delete from Service where name=@name;
  end;
  go
  --exec delete_service @name='sadgsfg', @id=1;
 
  --drop proc delete_service;
  go
  create proc Add_conract_user @id_service int, @id_client int,
  @status nvarchar(31),@amount real,@pay real,@debt real
  as begin
  insert into Bank_DB.dbo.Contract(id_service,id_client,status_contract,amount,pay,date_filing,debt)
  values(@id_service,@id_client,@status,@amount,@pay,GETDATE(),@debt)
  end;
  go
  --drop proc Add_conract_user
 -- TEACHER.TEACHER_NAME[факультет/кафедра/преподаватель/@код]
	--	from TEACHER inner join PULPIT
	--		on TEACHER.PULPIT = PULPIT.PULPIT
	--			where TEACHER.PULPIT = 'ИСиТ' for xml path, root('Список_преподавателей_кафедры_ИСиТ');
create proc my_contract @id_client int
as begin
select * from Contract where id=@id_client;
end;
go
create proc take_name_serv_bef_id 
@id int
as begin
 select Service.name from Service inner join Contract
 on Service.id=Contract.id_service
 where Contract.id_client=@id
end;
go
--drop proc take_name_serv_bef_id 
exec take_name_serv_bef_id @id=1
go
Create proc take_contr_info @id_service int,@id_client int
as begin
select * from Contract where id_service=@id_service and id_client=@id_client;
end
exec take_contr_info @id_service=10,@id_client=1
go
--drop proc Add_purse
delete from Money_transaction
go
create proc Add_purse
@clieint_id int,
@purse real,
@name_oper nvarchar(30),
@after real
 as begin  
 begin try
	 begin tran  
	 Set NOCOUNT ON 
	   -- начало  явной транзакции
update Client set purse=@after where Client.id=@clieint_id;
insert into Money_transaction(client_id,before_operation,after_operation,date_operatoin,resource)
values(@clieint_id,@purse,@after,GETDATE(),@name_oper)
	   commit tran
	   return 2;
	   Set NOCOUNT OFF
	   end try  
begin catch 
if @@trancount > 0
rollback tran
return -1;
end catch ; 
end
 ----------
 go
 exec Add_purse @clieint_id=1,@purse=40, @name_oper='99',@after=200
go
--drop proc Take_money_trans_info
 create proc Take_money_trans_info @id int
 as begin 
 select *  from Money_transaction where Money_transaction.client_id=@id order by date_operatoin desc;
 end;
go
--drop function Take_count_contract
go
 create function Take_count_contract(@id_client int,@id_service int)
returns int
as begin 
Declare @coun int
select @coun = count(Contract.id_service) from Contract where id_client=@id_client and id_service=@id_service and status_contract !='end';
 return @coun
end;
go
select dbo.Take_count_contract(1,10)
go
create proc take_name_serv_bef_status 
@status nvarchar(20), @dep nvarchar(50)
as begin
 select Service.name , Contract.id_client from Service inner join Contract
 on Service.id=Contract.id_service
 where Contract.status_contract=@status and Service.departament=@dep order by Contract.date_filing desc
end;
go
--drop proc take_request_info
 go
alter proc take_request_info @name nvarchar(20), @id_client int
as begin
select Contract.amount, Contract.pay,Contract.date_filing, Client.name,Client.id, Service.percent_t,Service.restriction,
Service.term,Contract.id,Client.purse,Contract.end_date from Contract inner join Client
on Contract.id_client=Client.id
inner join Service
on Contract.id_service=Service.id
where Contract.id_client=@id_client and Service.name=@name;
end
 exec take_request_info @name='12x Credit',@id_client=1
 --drop proc update_contract_decline
 go
 create proc update_contract_decline @id_contr int, @id_client int
 as begin 
 update Contract set status_contract='decline' where id_client=@id_client and id=@id_contr;
 update Client set status='decline' where id=@id_client;
 end
 go

 exec update_contract_decline @id_contr=3, @id_client=1
 --SELECT 'year', DATEADD(year,1,getdate())  
 go
 --drop proc Add_active_contract_credit
 create proc Add_active_contract_credit
 @id_contr int,
 @id_client int,
 @id_employee int,
 @after real,
 @term int,
 @purse real,
 @name_oper nvarchar(50)
 as begin  
 begin try
	 begin tran  
	 Set NOCOUNT ON 
	   -- начало  явной транзакции
 update Contract set status_contract='active',start_date=GETDATE(),end_date=(DATEADD(MONTH,@term,getdate())),id_employee=@id_employee where id_client=@id_client and id=@id_contr;
update Client set purse=@after,status='new' where Client.id=@id_client;
insert into Money_transaction(client_id,before_operation,after_operation,date_operatoin,resource)
values(@id_client,@purse,@after,GETDATE(),@name_oper)
	   commit tran
	   return 1;
	   Set NOCOUNT OFF
	   end try  
begin catch 
if @@trancount > 0
rollback tran
return -1;
end catch ; 
end
go
 create function IsStatus (@name nvarchar(20))
returns int
as begin 
Declare @a int =0;
if  exists (select client.status from Client where name=@name and status!='ready') set @a=1;  
	else set @a=0;
	return @a;
end;
go
select Bank_DB.dbo.IsStatus('Dima')
go
create proc Update_status_user @name nvarchar(50)
as begin 
update Client set status='ready' where name=@name;
end
go
--------------------
exec update_contract_decline @id_contr=3, @id_client=1
 --SELECT 'year', DATEADD(year,1,getdate())  
 go
 --drop proc To_full_pay_contract_credit
 create proc To_full_pay_contract_credit
 @id_service int,
 @id_client int,
 @after real,
 @before real,
 @name_oper nvarchar(50),
 @pay float
 as begin  
 begin try
	 begin tran  
	 Set NOCOUNT ON 
	   -- начало  явной транзакции
update Client set purse=@after where Client.id=@id_client;
insert into Money_transaction(client_id,before_operation,after_operation,date_operatoin,resource)
values(@id_client,@before,@after,GETDATE(),@name_oper)
update Contract set status_contract='end', debt=0 where id_client=@id_client and id_service=@id_service;
	   commit tran
	   return 1;
	   Set NOCOUNT OFF
	   end try  
begin catch 
if @@trancount > 0
rollback tran
return -1;
end catch ; 
end
go
----------------------------------
create proc To_part_pay_contract_credit
 @id_service int,
 @id_client int,
 @after float,
 @before float,
 @name_oper nvarchar(50),
 @debt float
 as begin  
 begin try
	 begin tran  
	 Set NOCOUNT ON 
	   -- начало  явной транзакции
update Client set purse=@after where Client.id=@id_client;
insert into Money_transaction(client_id,before_operation,after_operation,date_operatoin,resource)
values(@id_client,@before,@after,GETDATE(),@name_oper)
update Contract set  debt=@debt where id_client=@id_client and id_service=@id_service;
	   commit tran
	   return 1;
	   Set NOCOUNT OFF
	   end try  
begin catch 
if @@trancount > 0
rollback tran
return -1;
end catch ; 
end
go
create proc Add_conract_user_contr @id_service int, @id_client int,
  @status nvarchar(31),@amount real,@pay real,@debt real
  as begin
  insert into Bank_DB.dbo.Contract(id_service,id_client,status_contract,amount,pay,date_filing,debt)
  values(@id_service,@id_client,@status,@amount,@pay,GETDATE(),@debt)
  end;

  go
  ------------------------------
 create proc Add_active_contract_conrib
 @id_contr int,
 @id_client int,
 @id_employee int,
 @after real,
 @term int,
 @purse real,
 @name_oper nvarchar(50)
 as begin  
 begin try
	 begin tran  
	 Set NOCOUNT ON 
	   -- начало  явной транзакции
 update Contract set status_contract='active',start_date=GETDATE(),end_date=(DATEADD(MONTH,@term,getdate())),id_employee=@id_employee where id_client=@id_client and id=@id_contr;
update Client set purse=@after,status='new' where Client.id=@id_client;
insert into Money_transaction(client_id,before_operation,after_operation,date_operatoin,resource)
values(@id_client,@purse,@after,GETDATE(),@name_oper)
	   commit tran
	   return 1;
	   Set NOCOUNT OFF
	   end try  
begin catch 
if @@trancount > 0
rollback tran
return -1;
end catch ; 
end
go
select (DATEADD(MONTH,1,getdate()))

----------------------
go
exec take_request_info @name='"',@id_client=" + info.id_client + "
go

 create function Check_end_date ()
 returns int
as begin
Declare @a int =0;
if  exists (select * from Contract where end_date<GETDATE()and status_contract='active' ) set @a=1;  
	else set @a=0;
	return @a;
end
go
select dbo.Check_end_date()
--drop function Check_end_date
------------------
go
--drop proc Topay_contract_contr
create proc Topay_contract_contr
 @id_service int,
 @id_client int,
 @after float,
 @before float,
 @name_oper nvarchar(50)
 as begin  
 begin try
	 begin tran  
	 Set NOCOUNT ON 
	   -- начало  явной транзакции
update Client set purse=@after where Client.id=@id_client;
insert into Money_transaction(client_id,before_operation,after_operation,date_operatoin,resource)
values(@id_client,@before,@after,GETDATE(),@name_oper)
update Contract set  status_contract='end' where id_client=@id_client and id=@id_service;
	   commit tran
	   return 1;
	   Set NOCOUNT OFF
	   end try  
begin catch 
if @@trancount > 0
rollback tran
return -1;
end catch ; 
end
go
--
----
--drop function Take_contr_full_pay
go
create function Take_contr_full_pay(
@id_client int,
@id_contract int)
returns int
as begin
Declare @a int=0;
if exists (select * from Contract where id=@id_contract and id_client=@id_client and end_date<GETDATE() ) set @a=1
else set @a=0
return @a
end

select dbo.Take_contr_full_pay(1,16)




 
















 