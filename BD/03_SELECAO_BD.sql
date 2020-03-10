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
