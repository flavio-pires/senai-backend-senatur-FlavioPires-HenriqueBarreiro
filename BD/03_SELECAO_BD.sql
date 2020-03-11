USE Senatur_Manha;
GO

SELECT * FROM TiposUsuario
SELECT * FROM Usuarios
SELECT * FROM Cidades
SELECT * FROM Pacotes

--Listar todos os usuários mostrando o título do tipo de usuário.
SELECT Email, Senha, TiposUsuario.Titulo FROM Usuarios INNER JOIN TiposUsuario ON Usuarios.IdTipoUsuario = TiposUsuario.IdTipoUsuario;

--Listar os pacotes e mostrar o nome da cidade.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, Cidades.NomeCidade FROM Pacotes INNER JOIN Cidades ON Pacotes.IdCidade = Cidades.IdCidade;


--Listar somente os Pacotes Ativos.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, IdCidade FROM Pacotes WHERE Ativo = 1; 

--Listar somente os Pacotes Inativos.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, IdCidade FROM Pacotes WHERE Ativo = 0;

--Listar somente os Pacotes para uma determinada cidade.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, Cidades.NomeCidade FROM Pacotes INNER JOIN Cidades ON Pacotes.IdCidade = Cidades.IdCidade
WHERE Cidades.IdCidade = 1;

--Listar os Pacotes com ordenação por preço, do mais barato para o mais caro.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, IdCidade FROM Pacotes ORDER BY Valor DESC;

--Listar os Pacotes com ordenação por preço, do mais caro para o mais barato.
SELECT NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, IdCidade FROM Pacotes ORDER BY Valor ASC;