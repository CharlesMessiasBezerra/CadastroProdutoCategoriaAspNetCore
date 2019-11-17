-- Cria Login com Senha
CREATE LOGIN Usuario
    WITH PASSWORD = 'abc123456';
GO

-- Cria usuario para Login
CREATE USER Usuario FOR LOGIN Usuario;
GO


EXEC master..sp_addsrvrolemember @loginame = N'Usuario', @rolename = N'sysadmin'
GO