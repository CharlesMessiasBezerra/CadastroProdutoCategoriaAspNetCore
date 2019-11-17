CREATE DATABASE Projeto
GO
USE Projeto
GO

------------------------------------------ Criando Tabelas ---------------------------------
CREATE  TABLE Categorias
(
  Id INT IDENTITY,
  Nome VARCHAR(300),  
  PRIMARY KEY (ID)    
)


CREATE  TABLE Produtos
(
  Id INT IDENTITY,
  Nome VARCHAR(300),
  Preco money,
  IdCategoria INT,
  PRIMARY KEY (ID),
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(Id)
)
GO

------------------------------------------ Cadastro Categorias ---------------------------------
INSERT INTO  Categorias (Nome)
VALUES ('Perec�veis')
GO

INSERT INTO  Categorias (Nome)
VALUES ('Higiene Pessoal')
GO

INSERT INTO  Categorias (Nome)
VALUES ('Limpeza')
GO

INSERT INTO  Categorias (Nome)
VALUES ('Merceria')
GO
------------------------------------------ Cadastro produtos ---------------------------------
INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Alface', 4.50, 1)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Melancia', 20.00, 1)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Picanha', 50.00, 1)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Sabonete', 2.00, 2)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Creme Dental', 5.00, 2)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Desodorante', 9.90, 2)
GO


INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Sab�o em P�', 13.00, 3)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Detergente', 1.90, 3)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Desinfetante', 2.50, 3)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Caf�', 13.00, 4)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Arroz', 13.00, 4)
GO

INSERT INTO  Produtos(Nome, Preco, IdCategoria)
VALUES ('Feij�o', 4.50, 4)
GO

GO
SELECT * FROM Categorias
SELECT * FROM Produtos