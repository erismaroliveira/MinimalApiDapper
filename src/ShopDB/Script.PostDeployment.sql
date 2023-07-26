if not exists (Select 1 from dbo.Customer)
begin
	insert into dbo.Customer (FirstName, LastName)
	values ('Erismar', 'Oliveira'), ('Natália', 'Nascimento'), ('Isabella', 'Victoria'), ('Anna', 'Eloah');
end