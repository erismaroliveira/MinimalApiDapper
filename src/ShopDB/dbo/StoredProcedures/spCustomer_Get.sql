CREATE PROCEDURE [dbo].[spCustomer_Get]
	@Id int
AS
BEGIN
	SELECT * FROM dbo.Customer
	WHERE Id = @Id;
END
