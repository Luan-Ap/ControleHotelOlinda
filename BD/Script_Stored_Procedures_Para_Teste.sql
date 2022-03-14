USE BD_CONTROLE_HOTEL_TESTE
GO

-- CRIAÇÃO DE UMA STORED PROCEDURE PARA LISTAR CLIENTES
CREATE PROCEDURE SP_LISTAR_CLIENTES AS
BEGIN
	SELECT	c.Codigo AS [Cod_Cliente],
			c.Nome,
			c.Sobrenome,
			c.Cpf AS [CPF],
			c.Rg AS [RG],
			c.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			Format(c.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
            Format(c.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			c.Ativo AS [Ativo_Cliente]
	FROM Cliente c
	INNER JOIN Endereco e ON e.Codigo = c.Cod_Endereco
	WHERE c.Ativo = 1
END
GO

-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CONSULTAR CLIENTES PELO CÓDIGO
CREATE PROCEDURE SP_CLIENTE_COD (
	@COD UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	c.Codigo AS [Cod_Cliente],
			c.Nome,
			c.Sobrenome,
			c.Cpf AS [CPF],
			c.Rg AS [RG],
			c.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			Format(c.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
            Format(c.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			c.Ativo AS [Ativo_Cliente]
	FROM Cliente c
	INNER JOIN Endereco e ON e.Codigo = c.Cod_Endereco
	WHERE c.Ativo = 1 AND c.Codigo = @COD
END
GO

EXECUTE SP_CLIENTE_COD '5C70AD3B-7328-471B-AB03-275F95B324E1'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CONSULTAR CLIENTES PELO CPF
CREATE PROCEDURE SP_CLIENTE_CPF(
	@Cpf VARCHAR(11)
) AS
BEGIN
	SELECT	c.Codigo AS [Cod_Cliente],
			c.Nome,
			c.Sobrenome,
			c.Cpf AS [CPF],
			c.Rg AS [RG],
			c.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			Format(c.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
            Format(c.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			c.Ativo AS [Ativo_Cliente]
	FROM Cliente c
	INNER JOIN Endereco e ON e.Codigo = c.Cod_Endereco 
	WHERE c.Cpf = @Cpf AND c.Ativo = 1
END
GO

-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CONSULTAR CLIENTES PELO NOME E SOBRENOME
CREATE PROCEDURE SP_CLIENTE_NOME(
	@Nome VARCHAR(150),
	@Sobrenome VARCHAR(150)
) AS
BEGIN
	SELECT	c.Codigo AS [Cod_Cliente],
			c.Nome,
			c.Sobrenome,
			c.Cpf AS [CPF],
			c.Rg AS [RG],
			c.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			Format(c.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
            Format(c.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			c.Ativo AS [Ativo_Cliente]
	FROM Cliente c
	INNER JOIN Endereco e ON e.Codigo = c.Cod_Endereco 
	WHERE c.Nome = @Nome AND c.Sobrenome = @Sobrenome AND c.Ativo = 1
END
GO


-- CRIAÇÃO SE UMA STORED PROCEDURE PARA CADASTRAR ENDEREÇOS
CREATE PROCEDURE SP_CADASTRAR_ENDERECO(
	@Cod UNIQUEIDENTIFIER,
	@Endereco VARCHAR(150),
	@Num VARCHAR(6),
	@Cep VARCHAR(8),
	@Tel VARCHAR(11),
	@Estado CHAR(2),
	@Ativo BIT
)AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Endereco(Codigo, Endereco, Numero, Cep, Telefone, Estado, Ativo) VALUES
		(@Cod, @Endereco, @Num, @Cep, @Tel, @Estado, @Ativo);
END

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXEC SP_CADASTRAR_ENDERECO @Cod = @IN, @Endereco = 'Rua AAA', @Num = '345', @Cep = '06381200', @Tel = '1123450987', @Estado = 'SP', @Ativo = 1
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CADASTRAR CLIENTES
CREATE PROCEDURE SP_CADASTRAR_CLIENTE(
	@Cod UNIQUEIDENTIFIER,
	@Nome VARCHAR(150),
	@Sobrenome VARCHAR(150),
    @Cpf VARCHAR(11),
    @Rg VARCHAR(9),
	@Email VARCHAR(150),
	@Cod_Endereco UNIQUEIDENTIFIER,
	@Data_Nascimento DATE,
	@Data_Cadastro DATE,
	@Ativo BIT
) AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Cliente(Codigo, Nome, Sobrenome, Cpf, Rg, Email, Cod_Endereco, Data_Nascimento, Data_Cadastro, Ativo) VALUES 
			(@Cod, @Nome, @Sobrenome, @Cpf, @Rg, @Email, @Cod_Endereco, @Data_Nascimento, @Data_Cadastro, @Ativo);
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXEC SP_CADASTRAR_CLIENTE @Cod = @IN, @Nome = 'Juca', @Sobrenome = 'Andrade', @Cpf = '37894291237', @Rg = '459812034', @Email = 'juca@email.com', @Cod_Endereco = 'FD7BD07D-ECBC-4091-8AB6-9CB3562BBF3A', @Data_Nascimento = '1995-05-20', @Data_Cadastro = '2021-02-10', @Ativo = 1
GO


-- CRAIÇÃO DE UMA STORED PROCEDURE PARA LISTAR FUNCIONARIOS
CREATE PROCEDURE SP_LISTAR_FUNCIONARIOS AS
BEGIN
	SELECT	f.Codigo AS [Cod_Func],
			f.Nome,
			f.Sobrenome,
			f.Cpf AS [CPF],
			f.Rg AS [RG],
			f.Ctps AS [CTPS],
			f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			f.Salario,
			f.Cargo,
			FORMAT(f.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
			FORMAT(f.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			f.Ativo AS [Ativo_Func]
            FROM Funcionario f
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE f.Ativo = 1
END
GO

EXECUTE SP_LISTAR_FUNCIONARIOS
GO


-- CRIAÇÃO DE UMA PROCEDURE PARA SELECIONAR FUNCIONÁRIOS POR COD
CREATE PROCEDURE SP_LISTAR_FUNCIONARIO_COD(
	@Cod UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	f.Codigo AS [Cod_Func],
			f.Nome,
			f.Sobrenome,
			f.Cpf AS [CPF],
			f.Rg AS [RG],
			f.Ctps AS [CTPS],
			f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			f.Salario,
			f.Cargo,
			FORMAT(f.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
			FORMAT(f.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			f.Ativo AS [Ativo_Func]
            FROM Funcionario f
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE f.Ativo = 1 AND f.Codigo = @Cod
END
GO

EXECUTE SP_LISTAR_FUNCIONARIO_COD '21A6DDAB-5827-42F3-8938-5D68DFE14591'
GO


-- CRIAÇÃO DE UMA PROCEDURE PARA SELECIONAR FUNCIONÁRIOS POR CPF
CREATE PROCEDURE SP_LISTAR_FUNCIONARIO_CPF(
	@Cpf VARCHAR(11)
) AS
BEGIN
	SELECT	f.Codigo AS [Cod_Func],
			f.Nome,
			f.Sobrenome,
			f.Cpf AS [CPF],
			f.Rg AS [RG],
			f.Ctps AS [CTPS],
			f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			f.Salario,
			f.Cargo,
			FORMAT(f.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
			FORMAT(f.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			f.Ativo AS [Ativo_Func]
            FROM Funcionario f
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE f.Ativo = 1 AND f.Cpf = @Cpf
END
GO

EXECUTE SP_LISTAR_FUNCIONARIO_CPF '16161616161'
GO


-- CRIAÇÃO DE UMA PROCEDURE PARA SELECIONAR FUNCIONÁRIOS POR NOME E SOBRENOME
CREATE PROCEDURE SP_LISTAR_FUNCIONARIO_NOME(
	@Nome VARCHAR(150),
	@Sobrenome VARCHAR(150)
) AS
BEGIN
	SELECT	f.Codigo AS [Cod_Func],
			f.Nome,
			f.Sobrenome,
			f.Cpf AS [CPF],
			f.Rg AS [RG],
			f.Ctps AS [CTPS],
			f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
			f.Salario,
			f.Cargo,
			FORMAT(f.Data_Nascimento, 'dd-MM-yyyy') AS [Nascimento],
			FORMAT(f.Data_Cadastro, 'dd-MM-yyyy') AS [Cadastro],
			f.Ativo AS [Ativo_Func]
            FROM Funcionario f
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE f.Ativo = 1 AND f.Nome = @Nome AND f.Sobrenome = @Sobrenome
END
GO

EXECUTE SP_LISTAR_FUNCIONARIO_NOME @Nome = 'Marcos', @Sobrenome = 'Oliveira'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CADASTRAR FUNCIONARIOS
CREATE PROCEDURE SP_CADASTRAR_FUNCIONARIO(
	@Cod UNIQUEIDENTIFIER,
    @Nome VARCHAR(150),
	@Sobrenome VARCHAR(150),
	@Cpf VARCHAR(11),
    @Rg VARCHAR(9),
    @Ctps VARCHAR(15),
	@Email VARCHAR(150),
    @Cod_Endereco UNIQUEIDENTIFIER,
    @Salario FLOAT,
    @Cargo VARCHAR(150),
    @Data_Nascimento DATE,
	@Data_Cadastro DATE,
	@Ativo BIT
) AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Funcionario(Codigo, Nome, Sobrenome, Cpf, Rg, Ctps, Email, Cod_Endereco, Cargo, Salario, Data_Nascimento, Data_Cadastro, Ativo) VALUES 
			(@Cod, @Nome, @Sobrenome, @Cpf, @Rg, @Ctps, @Email, @Cod_Endereco, @Cargo, @Salario, @Data_Nascimento, @Data_Cadastro, @Ativo);
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_CADASTRAR_FUNCIONARIO @Cod = @IN, @Nome = 'Marcos', @Sobrenome = 'Oliveira', @Cpf = '35489129364' , @Rg = '462019467', @Ctps = '64728394612SP', @Email = 'marcos@email.com', @Cod_Endereco = '9FC37690-8DE7-4196-ABCE-C00D4E3BE27D', @Cargo = 'Recepcionista', @Salario = 3000, @Data_Nascimento = '1990-03-15', @Data_Cadastro = '2021-01-10', @Ativo = 1
GO


-- CRAIÇÃO DE UMA STORED PROCEDURE PARA LISTAR FUNCIONARIOS_USUARIOS
CREATE PROCEDURE SP_LISTAR_FUNCIONARIOS_USUARIOS AS
BEGIN
	SELECT	fu.Codigo AS[Codigo],
            f.Nome AS[Nome],
			f.Sobrenome AS[Sobrenome],
            f.Cpf AS[CPF],
            f.Rg AS[RG],
            f.Ctps AS[CTPS],
            f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
            f.Salario,
            f.Cargo, 
            Format(f.Data_Nascimento, 'dd-MM-yyyy') AS[Nascimento],
            Format(f.Data_Cadastro, 'dd-MM-yyyy') AS[Cadastro],
            fu.Usuario,
            fu.Senha,
            fu.Nivel_Acesso AS [Acesso],
			fu.Ativo AS [Ativo_Func]
            FROM Funcionario f
            INNER JOIN Funcionario_Usuario fu ON f.Codigo = fu.Codigo
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE fu.Ativo = 1
END
GO

EXECUTE SP_LISTAR_FUNCIONARIOS_USUARIOS
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CADASTRAR FUNCIONARIOS_USUARIOS
CREATE PROCEDURE SP_CADASTRAR_FUNCIONARIO_USUARIO(
	@Cod UNIQUEIDENTIFIER,
	@Usuario VARCHAR(150),
	@Senha VARCHAR(150),
	@Nivel INT,
	@Ativo BIT
) AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Funcionario_Usuario(Codigo, Usuario, Senha, Nivel_Acesso, Ativo) VALUES 
			(@Cod, @Usuario, @Senha, @Nivel, @Ativo);
END
GO


EXECUTE SP_CADASTRAR_FUNCIONARIO_USUARIO @Cod = 'EE850BC9-3E2D-40C1-8211-6238D85ED1A7', @Usuario = 'marcos@email.com', @Senha = 'marcos123', @Nivel = 1, @Ativo = 1
GO



-- CRIAÇÃO DE UMA PROCEDURE PARA SELECIONAR FUNCIONÁRIOS_USUÁRIOS POR COD
CREATE PROCEDURE SP_LISTAR_FUNCIONARIO_USUARIO_COD(
	@Cod UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	fu.Codigo AS[Codigo],
            f.Nome AS[Nome],
			f.Sobrenome AS[Sobrenome],
            f.Cpf AS[CPF],
            f.Rg AS[RG],
            f.Ctps AS[CTPS],
            f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
            f.Salario,
            f.Cargo, 
            Format(f.Data_Nascimento, 'dd-MM-yyyy') AS[Nascimento],
            Format(f.Data_Cadastro, 'dd-MM-yyyy') AS[Cadastro],
            fu.Usuario,
            fu.Senha,
            fu.Nivel_Acesso AS [Acesso],
			fu.Ativo AS [Ativo_Func]
            FROM Funcionario f
            INNER JOIN Funcionario_Usuario fu ON f.Codigo = fu.Codigo
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE fu.Ativo = 1 AND f.Codigo = @Cod
END
GO


EXECUTE SP_LISTAR_FUNCIONARIO_USUARIO_COD @Cod = 'EE850BC9-3E2D-40C1-8211-6238D85ED1A7'
GO



-- CRIAÇÃO DE UMA PROCEDURE PARA SELECIONAR FUNCIONÁRIOS_USUÁRIOS POR LOGIN
CREATE PROCEDURE SP_FUNCIONARIO_USUARIO_LOGIN(
	@Usuario VARCHAR(150),
	@Senha VARCHAR(150)
) AS
BEGIN
	SELECT	fu.Codigo AS[Codigo],
            f.Nome AS[Nome],
			f.Sobrenome,
            f.Cpf AS[CPF],
            f.Rg AS[RG],
            f.Ctps AS[CTPS],
            f.Email,
			e.Codigo AS [Cod_Endereco],
			e.Endereco,
			e.Numero,
			e.Cep AS [CEP],
			e.Telefone,
			e.Estado,
			e.Ativo AS [Ativo_Endereco],
            f.Salario,
            f.Cargo, 
            Format(f.Data_Nascimento, 'dd-MM-yyyy') AS[Nascimento],
            Format(f.Data_Cadastro, 'dd-MM-yyyy') AS[Cadastro],
            fu.Usuario,
            fu.Senha,
            fu.Nivel_Acesso AS [Acesso],
			fu.Ativo AS [Ativo_Func]
            FROM Funcionario f
            INNER JOIN Funcionario_Usuario fu ON f.Codigo = fu.Codigo
			INNER JOIN Endereco e ON e.Codigo = f.Cod_Endereco
            WHERE fu.Ativo = 1 AND fu.Usuario = @Usuario AND fu.Senha = @Senha
END
GO

EXECUTE SP_FUNCIONARIO_USUARIO_LOGIN @Usuario = 'marcos@email.com', @Senha = 'marcos123'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA LISTAR OS TIPOS DE QUARTO
CREATE PROCEDURE SP_LISTAR_TIPO_QUARTOS AS
BEGIN
	SELECT	tp.Codigo AS [Cod_Tipo],
			tp.Tipo,
			tp.Max_Acompanhantes,
			tp.Valor,
			tp.Ativo AS [Ativo_Tipo]
			FROM Tipo_Quarto tp
			WHERE tp.Ativo = 1
			ORDER BY tp.Valor
END
GO

EXECUTE SP_LISTAR_TIPO_QUARTOS
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR TIPO DE QUARTO PELO CÓDIGO
CREATE PROCEDURE SP_SELECIONAR_TIPO_QUARTO_CODIGO(
	@Cod UNIQUEIDENTIFIER
)AS
BEGIN
	SELECT	tp.Codigo AS [Cod_Tipo],
			tp.Tipo,
			tp.Max_Acompanhantes,
			tp.Valor,
			tp.Ativo AS [Ativo_Tipo]
			FROM Tipo_Quarto tp
			WHERE tp.Ativo = 1 AND tp.Codigo = @Cod
			ORDER BY tp.Valor
END
GO

EXECUTE SP_SELECIONAR_TIPO_QUARTO_CODIGO @Cod = 'A1A5123E-EC15-4942-AFFF-74769A6CA4CE'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA LISTAR QUARTOS
CREATE PROCEDURE SP_LISTAR_QUARTOS AS
BEGIN
	SELECT	q.Codigo AS [Cod_Quarto],
			q.Num_Quarto AS [Num],
			q.Cod_Tipo_Quarto AS [Cod_Tipo],
			q.Descricao,
			FORMAT(q.Data_Cadastro, 'dd-MM-yyyy') AS [Data_Cadastro],
			q.Ativo AS [Ativo_Quarto]
			FROM Quarto q
			WHERE q.Ativo = 1
			ORDER BY q.Num_Quarto ASC
END
GO

EXECUTE SP_LISTAR_QUARTOS
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA LISTAR QUARTOS PELO TIPO
CREATE PROCEDURE SP_LISTAR_QUARTOS_TIPO(
	@Tipo VARCHAR(30)
)AS
BEGIN
	SELECT	q.Codigo AS [Cod_Quarto],
			q.Num_Quarto AS [Num],
			q.Cod_Tipo_Quarto AS [Cod_Tipo],
			q.Descricao,
			FORMAT(q.Data_Cadastro, 'dd-MM-yyyy') AS [Data_Cadastro],
			q.Ativo AS [Ativo_Quarto]
			FROM Quarto q
			INNER JOIN Tipo_Quarto tq ON tq.Codigo = q.Cod_Tipo_Quarto
			WHERE q.Ativo = 1 AND tq.Tipo = @Tipo
			ORDER BY q.Num_Quarto ASC
END
GO

EXECUTE SP_LISTAR_QUARTOS_TIPO @Tipo = 'Single'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR QUARTO PELO CÓDIGO
CREATE PROCEDURE SP_SELECIONAR_QUARTO_COD(
	@Cod UNIQUEIDENTIFIER
)AS
BEGIN
	SELECT	q.Codigo AS [Cod_Quarto],
			q.Num_Quarto AS [Num],
			q.Cod_Tipo_Quarto AS [Cod_Tipo],
			q.Descricao,
			FORMAT(q.Data_Cadastro, 'dd-MM-yyyy') AS [Data_Cadastro],
			q.Ativo AS [Ativo_Quarto]
			FROM Quarto q
			WHERE q.Ativo = 1 AND q.Codigo = @Cod
			ORDER BY q.Num_Quarto ASC
END
GO

EXECUTE SP_SELECIONAR_QUARTO_COD @Cod = '6C40F524-315A-4A75-89D3-44CD1E49D5E6'
GO


-- CRIAÇÃO DE UMA PROCEDURE PARA CADASTRAR QUARTOS
CREATE PROCEDURE SP_CADASTRAR_QUARTO(
	@Cod UNIQUEIDENTIFIER,
    @Num_Quarto INT,
	@Descricao VARCHAR(250),
    @Cod_Tipo_Quarto UNIQUEIDENTIFIER,
    @Data_Cadastro DATE,
	@Ativo BIT
)AS
BEGIN
	INSERT INTO Quarto(Codigo, Num_Quarto, Cod_Tipo_Quarto, Descricao, Data_Cadastro, Ativo) VALUES 
			(@Cod, @Num_Quarto, @Cod_Tipo_Quarto, @Descricao, @Data_Cadastro, @Ativo);
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_CADASTRAR_QUARTO @Cod = @IN, @Num_Quarto = 16, @Descricao = 'Quarto Single com uma cama de solteiro', @Cod_Tipo_Quarto = 'A1A5123E-EC15-4942-AFFF-74769A6CA4CE', @Data_Cadastro = '2021-01-01', @Ativo = 1
GO

-- CRIAÇÃO DE UM PROCEDURE PARA CONSULTAR OFERTAS DE QUARTOS
CREATE PROCEDURE SP_CONSULTAR_OFERTAS(
	@Cod UNIQUEIDENTIFIER,
	@Inicio DATE,
	@Fim DATE
) AS
BEGIN
	SELECT	q.Codigo AS [Cod_Quarto],
			q.Num_Quarto AS [Num],
			q.Cod_Tipo_Quarto AS [Cod_Tipo],
			q.Descricao,
			FORMAT(q.Data_Cadastro, 'dd-MM-yyyy') AS [Data_Cadastro],
			q.Ativo AS [Ativo_Quarto]
			FROM Quarto q
			WHERE q.Ativo = 1 AND q.Cod_Tipo_Quarto = @Cod AND
			q.Num_Quarto NOT IN (SELECT DISTINCT q.Num_Quarto 
												 FROM Reserva r 
												 INNER JOIN Quarto q ON r.Cod_Quarto = q.Codigo 
												 WHERE	r.Status_Reserva = 'Ativa' AND 
														r.Data_Entrada BETWEEN @Inicio AND @Fim OR
														r.Data_Saida BETWEEN @Inicio AND @Fim AND
														q.Cod_Tipo_Quarto = @Cod)
														ORDER BY q.Num_Quarto ASC;

END
GO

EXEC SP_CONSULTAR_OFERTAS @Cod = '1f4518d2-da8f-4b44-a6b4-1bc77b9e01ce', @Inicio = '2021-01-01', @Fim = '2021-01-05'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA REALIZAR RESERVAS
CREATE PROCEDURE SP_REALIZAR_RESERVA(
	@Cod UNIQUEIDENTIFIER,
    @Cod_Cliente UNIQUEIDENTIFIER,
    @Cod_Quarto UNIQUEIDENTIFIER,
    @Num_Acomp INT,
    @Data_Entrada DATE,
    @Data_Saida DATE,
    @Data_Reserva DATE,
	@Total_Diaria FLOAT,
	@Pagto VARCHAR(10),
	@Status_Reserva VARCHAR(10),
	@Ativo BIT
) AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Reserva(Codigo, Cod_Cliente, Cod_Quarto, Num_Acompanhantes, Data_Entrada, Data_Saida, Data_Reserva, Total_Diaria, Status_Reserva, Ativo) VALUES 
			(@Cod, @Cod_Cliente, @Cod_Quarto, @Num_Acomp, @Data_Entrada, @Data_Saida, @Data_Reserva, @Total_Diaria, @Status_Reserva, @Ativo);
	INSERT INTO Registro_Pagamento(Codigo, Cod_Reserva, Valor, Forma_Pagto, Data_Pagto, Ativo) VALUES
			(NEWID(), @Cod, @Total_Diaria, @Pagto, @Data_Reserva, @Ativo);
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_REALIZAR_RESERVA @Cod = @IN, @Cod_Cliente = '098AE8D2-2137-495B-8217-28E213CA4FF1', @Cod_Quarto = '04C39A60-BE8D-4495-8B91-569871617A53', @Num_Acomp = '0', @Data_Entrada = '2021-02-23', @Data_Saida = '2021-02-26', @Data_Reserva = '2021-02-20', @Pagto = 'Credito', @Total_Diaria = 300, @Status_Reserva = 'Concluida', @Ativo = 1
GO

-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR TODAS AS RESERVAS
CREATE PROCEDURE SP_SELECIONAR_RESERVAS AS
BEGIN
	SELECT	r.Codigo AS [Cod_Reserva],
			r.Cod_Cliente AS [Cod_Cliente],
			r.Cod_Quarto AS [Cod_Quarto],
			r.Num_Acompanhantes AS [Num_Acomp],
			Format(r.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			Format(r.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			r.Total_Diaria AS [Total],
			Format(r.Data_Reserva, 'dd-MM-yyyy') AS [Reserva],
			r.Status_Reserva AS [Status],
			r.Ativo AS [Ativo_Reserva]
			FROM Reserva r
			ORDER BY r.Status_Reserva,
					 r.Data_Entrada ASC;
END
GO


EXECUTE SP_SELECIONAR_RESERVAS
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR TODAS AS RESERVAS POR STATUS
CREATE PROCEDURE SP_SELECIONAR_RESERVAS_STATUS(
	@Status VARCHAR(10)
) AS
BEGIN
	SELECT	r.Codigo AS [Cod_Reserva],
			r.Cod_Cliente AS [Cod_Cliente],
			r.Cod_Quarto AS [Cod_Quarto],
			r.Num_Acompanhantes AS [Num_Acomp],
			Format(r.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			Format(r.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			r.Total_Diaria AS [Total],
			Format(r.Data_Reserva, 'dd-MM-yyyy') AS [Reserva],
			r.Status_Reserva AS [Status],
			r.Ativo AS [Ativo_Reserva]
			FROM Reserva r
			WHERE r.Status_Reserva = @Status
			ORDER BY r.Data_Entrada ASC;
END
GO

EXECUTE SP_SELECIONAR_RESERVAS_STATUS @Status = 'Concluida'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR RESERVAS PELO COD.
CREATE PROCEDURE SP_SELECIONAR_RESERVA_COD(
	@Cod UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	r.Codigo AS [Cod_Reserva],
			r.Cod_Cliente AS [Cod_Cliente],
			r.Cod_Quarto AS [Cod_Quarto],
			r.Num_Acompanhantes AS [Num_Acomp],
			Format(r.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			Format(r.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			r.Total_Diaria AS [Total],
			Format(r.Data_Reserva, 'dd-MM-yyyy') AS [Reserva],
			r.Status_Reserva AS [Status],
			r.Ativo AS [Ativo_Reserva]
			FROM Reserva r
			WHERE r.Codigo = @Cod;
END
GO

EXECUTE SP_SELECIONAR_RESERVA_COD @Cod = '2FFEA260-F9FA-4C59-8285-FA79EE63EF34'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CANCELAR RESERVA SEM MULTA
CREATE PROCEDURE SP_CANCELAR_RESERVA(
	@Cod UNIQUEIDENTIFIER
)AS
BEGIN
	UPDATE Reserva SET Ativo = 0, Status_Reserva = 'Cancelada' WHERE Codigo = @Cod;
	UPDATE Registro_Pagamento SET Ativo = 0 WHERE Cod_Reserva = @Cod;
END
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CANCELAR RESERVA COM MULTA
CREATE PROCEDURE SP_CANCELAR_RESERVA_MULTA(
	@Cod_Registro UNIQUEIDENTIFIER,
	@Cod_Reserva UNIQUEIDENTIFIER,
	@Multa FLOAT,
	@Pagto VARCHAR(10),
	@Data_Reserva DATE,
	@Ativo BIT
)AS
BEGIN
	UPDATE Reserva SET Ativo = 0, Status_Reserva = 'Cancelada' WHERE Codigo = @Cod_Reserva;
	UPDATE Registro_Pagamento SET Ativo = 0 WHERE Cod_Reserva = @Cod_Reserva;
	INSERT INTO Registro_Pagamento(Codigo, Cod_Reserva, Valor, Forma_Pagto, Data_Pagto, Ativo) VALUES
			(NEWID(), @Cod_Reserva, @Multa, @Pagto, @Data_Reserva, @Ativo);
END
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR RESERVA PARA CHECK-IN
CREATE PROCEDURE SP_SELECIONAR_RESERVA_CHECKIN(
	@Cpf VARCHAR(11)
)AS
BEGIN
	SELECT	r.Codigo AS [Cod_Reserva],
			r.Cod_Cliente AS [Cod_Cliente],
			r.Cod_Quarto AS [Cod_Quarto],
			r.Num_Acompanhantes AS [Num_Acomp],
			Format(r.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			Format(r.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			r.Total_Diaria AS [Total],
			Format(r.Data_Reserva, 'dd-MM-yyyy') AS [Reserva],
			r.Status_Reserva AS [Status],
			r.Ativo AS [Ativo_Reserva]
			FROM Reserva r
			INNER JOIN Cliente c ON r.Cod_Cliente = c.Codigo
			WHERE c.Cpf = @Cpf AND r.Status_Reserva = 'Ativa'
END
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA FAZER CHECK-IN
CREATE PROCEDURE SP_FAZER_CHECKIN(
	@Cod UNIQUEIDENTIFIER,
	@Cod_Reserva UNIQUEIDENTIFIER,
	@Ativo BIT
) AS
BEGIN
	INSERT INTO Check_In(Codigo, Cod_Reserva, Ativo) VALUES
			(@COD, @Cod_Reserva, @Ativo);
	UPDATE Reserva SET Status_Reserva = 'Concluida' WHERE Codigo = @Cod_Reserva;
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_FAZER_CHECKIN @Cod = @IN, @Cod_Reserva = '2FFEA260-F9FA-4C59-8285-FA79EE63EF34', @Ativo = 1
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA LISTAR PRODUTOS
CREATE PROCEDURE SP_SELECIONAR_PRODUTOS AS
BEGIN
	SELECT	p.Codigo,
			p.Nome,
			p.Tipo_Produto AS [Tipo],
			p.Quantidade AS [Qtd],
			p.Valor,
			FORMAT(p.Data_Cadastro, 'dd-MM-yyyy') AS[Cadastro],
			p.Ativo AS [Ativo_Prod]
			FROM Produto p
			WHERE p.Ativo = 1
			ORDER BY p.Tipo_Produto
END
GO

EXECUTE SP_SELECIONAR_PRODUTOS
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR PRODUTOS POR TIPO
CREATE PROCEDURE SP_SELECIONAR_PRODUTOS_TIPO(
	@Tipo VARCHAR(20)
) AS
BEGIN
	SELECT	p.Codigo,
			p.Nome,
			p.Tipo_Produto AS [Tipo],
			p.Quantidade AS [Qtd],
			p.Valor,
			FORMAT(p.Data_Cadastro, 'dd-MM-yyyy') AS[Cadastro],
			p.Ativo AS [Ativo_Prod]
			FROM Produto p
			WHERE p.Ativo = 1 AND p.Tipo_Produto = @Tipo
END
GO

EXECUTE SP_SELECIONAR_PRODUTOS_TIPO @Tipo = 'Serviço'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR PRODUTO PELO CÓDIGO
CREATE PROCEDURE SP_SELECIONAR_PRODUTOS_COD(
	@Cod UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	p.Codigo,
			p.Nome,
			p.Tipo_Produto AS [Tipo],
			p.Quantidade AS [Qtd],
			p.Valor,
			FORMAT(p.Data_Cadastro, 'dd-MM-yyyy') AS[Cadastro],
			p.Ativo AS [Ativo_Prod]
			FROM Produto p
			WHERE p.Ativo = 1 AND p.Codigo = @Cod
END
GO

EXECUTE SP_SELECIONAR_PRODUTOS_COD @Cod = 'B690A1E3-CD7A-4A5B-ADB4-58FC3BCA9A65'
GO

-- CRIAÇÃO DE UMA STORED PROCEDURE PARA INSERIR PRODUTOS
CREATE PROCEDURE SP_INSERIR_PRODUTO(
	@Cod UNIQUEIDENTIFIER,
    @Nome VARCHAR(150),
    @Quantidade INT,
    @Valor FLOAT,
    @Data_Cadastro DATE,
	@Tipo_Produto VARCHAR(20),
	@Ativo BIT
)AS
BEGIN
	INSERT INTO Produto(Codigo, Nome, Tipo_Produto, Valor, Quantidade, Data_Cadastro, Ativo) VALUES
			(@Cod, @Nome, @Tipo_Produto, @Valor, @Quantidade, @Data_Cadastro, @Ativo);
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_INSERIR_PRODUTO @Cod = @IN, @Nome = 'Barra de Chocolate Cacau', @Tipo_Produto = 'Mercadoria', @Valor = 5.5, @Quantidade = 50, @Data_Cadastro = '2021-01-01', @Ativo = 1
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA INICIAR HOSPEDAGEM
CREATE PROCEDURE SP_INICIAR_HOSPEDAGEM(
	@Cod UNIQUEIDENTIFIER,
	@Cod_Cliente UNIQUEIDENTIFIER,
    @Cod_Quarto UNIQUEIDENTIFIER,
    @Data_Entrada DATE,
    @Data_Saida DATE,
	@Ativo BIT
)AS
BEGIN
	INSERT INTO Hospedagem(Codigo, Cod_Cliente, Cod_Quarto, Data_Entrada, Data_Saida, Ativo) VALUES
			(@Cod, @Cod_Cliente, @Cod_Quarto, @Data_Entrada, @Data_Saida, @Ativo)
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_INICIAR_HOSPEDAGEM @Cod = @IN, @Cod_Cliente = '098AE8D2-2137-495B-8217-28E213CA4FF1', @Cod_Quarto = '04C39A60-BE8D-4495-8B91-569871617A53', @Data_Entrada = '23-02-2021', @Data_Saida = '26-02-2021', @Ativo = 1
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR TODAS AS HOSPEDAGENS
CREATE PROCEDURE SP_SELECIONAR_HOSPEDAGENS AS
BEGIN
	SELECT	h.Codigo AS [Cod_Hosp],
			h.Cod_Cliente,
			h.Cod_Quarto,
			FORMAT(h.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			FORMAT(h.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			h.Consumo_Total AS [Consumo],
			h.Ativo AS [Ativo_Hospe]
			FROM Hospedagem h
			ORDER BY h.Data_Entrada DESC
END
GO

EXECUTE SP_SELECIONAR_HOSPEDAGENS
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA SELECIONAR TODAS AS HOSPEDAGENS POR STATUS
CREATE PROCEDURE SP_SELECIONAR_HOSPEDAGENS_STATUS(
	@Ativo BIT
) AS
BEGIN
	SELECT	h.Codigo AS [Cod_Hosp],
			h.Cod_Cliente,
			h.Cod_Quarto,
			FORMAT(h.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			FORMAT(h.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			h.Consumo_Total AS [Consumo],
			h.Ativo AS [Ativo_Hospe]
			FROM Hospedagem h
			WHERE h.Ativo = @Ativo
			ORDER BY h.Data_Entrada DESC
END
GO

EXECUTE SP_SELECIONAR_HOSPEDAGENS_STATUS 1
GO


-- CRIAÇÃO DE UMA STRORED PROCEDURE PARA SELECIONAR HOSPEDAGENS PARA CHECK-OUT
CREATE PROCEDURE SP_SELECIONAR_HOSPEDAGEM_CHECKOUT(
	@Cpf VARCHAR(11)
) AS
BEGIN
	SELECT	h.Codigo AS [Cod_Hosp],
			h.Cod_Cliente,
			h.Cod_Quarto,
			FORMAT(h.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			FORMAT(h.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			h.Consumo_Total AS [Consumo],
			h.Ativo AS [Ativo_Hospe]
			FROM Hospedagem h
			INNER JOIN Cliente c ON c.Codigo = h.Cod_Cliente
			WHERE h.Ativo = 1 AND c.Cpf = @Cpf
END
GO

EXECUTE SP_SELECIONAR_HOSPEDAGEM_CHECKOUT @Cpf = '37894291237'
GO


-- CRIAÇÃO DE UMA STRORED PROCEDURE PARA SELECIONAR HOSPEDAGENS POR CÓDIGO
CREATE PROCEDURE SP_SELECIONAR_HOSPEDAGENS_COD(
	@Cod UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	h.Codigo AS [Cod_Hosp],
			h.Cod_Cliente,
			h.Cod_Quarto,
			FORMAT(h.Data_Entrada, 'dd-MM-yyyy') AS [Entrada],
			FORMAT(h.Data_Saida, 'dd-MM-yyyy') AS [Saida],
			h.Consumo_Total AS [Consumo],
			h.Ativo AS [Ativo_Hospe]
			FROM Hospedagem h
			WHERE h.Codigo = @Cod
END
GO

EXECUTE SP_SELECIONAR_HOSPEDAGENS_COD @Cod = 'D06A59BF-BE18-49B5-93C7-8F390559853F'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA INSERIR CONSUMOS À UMA HOSPEDAGEM
CREATE PROCEDURE SP_HOSPEDAGEM_INSERIR_CONSUMOS(
	@Cod_Consumo UNIQUEIDENTIFIER,
	@Cod_Hospedagem UNIQUEIDENTIFIER,
    @Cod_Produto UNIQUEIDENTIFIER,
	@Tipo VARCHAR(20),
    @Qtd_Consumida INT,
    @Valor_Total FLOAT,
    @Data_Consumo DATE,
	@Ativo BIT
)AS
BEGIN
	INSERT INTO Produto_Hospedagem(Codigo, Cod_Hospedagem, Cod_Produto, Qtd_Consumida, Valor_Total, Data_Consumo, Ativo) VALUES 
			(@Cod_Consumo, @Cod_Hospedagem, @Cod_Produto, @Qtd_Consumida, @Valor_Total, @Data_Consumo, @Ativo);
	UPDATE Hospedagem SET Consumo_Total = Consumo_Total + @Valor_Total WHERE Codigo = @Cod_Hospedagem;
	IF @Tipo = 'Mercadoria'
		UPDATE Produto SET Quantidade = Quantidade - @Qtd_Consumida WHERE Codigo = @Cod_Produto;
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_HOSPEDAGEM_INSERIR_CONSUMOS @Cod_Consumo = @IN, @Cod_Hospedagem = 'D06A59BF-BE18-49B5-93C7-8F390559853F', @Cod_Produto = 'B690A1E3-CD7A-4A5B-ADB4-58FC3BCA9A65', @Tipo = 'Mercadoria', @Qtd_Consumida = 3, @Valor_Total = 16.5, @Data_Consumo = '2021-02-24', @Ativo = 1
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_HOSPEDAGEM_INSERIR_CONSUMOS @Cod_Consumo = @IN, @Cod_Hospedagem = 'D06A59BF-BE18-49B5-93C7-8F390559853F', @Cod_Produto = '865EB7C7-D52E-4644-A84E-4322E354F892', @Tipo = 'Serviço', @Qtd_Consumida = 1, @Valor_Total = 55, @Data_Consumo = '2021-02-24', @Ativo = 1
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA CONSULTAR OS CONSUMOS DE UMA HOSPEDAGEM
CREATE PROCEDURE SP_CONSUMOS_HOSPEDAGEM(
	@Cod UNIQUEIDENTIFIER
) AS
BEGIN
	SELECT	ph.Codigo AS [Cod_Consumo],
			ph.Cod_Hospedagem,
			ph.Cod_Produto,
			ph.Qtd_Consumida,
			ph.Valor_Total,
			FORMAT(ph.Data_Consumo, 'dd-MM-yyyy') AS [Data_Consumo],
			ph.Ativo AS [Ativo_Consumo]
			FROM Produto_Hospedagem ph
			INNER JOIN Hospedagem h ON h.Codigo = ph.Cod_Hospedagem
			INNER JOIN Produto p ON p.Codigo = ph.Cod_Produto
			WHERE ph.Cod_Hospedagem = @Cod
			ORDER BY ph.Data_Consumo
END
GO

EXECUTE SP_CONSUMOS_HOSPEDAGEM @Cod = 'D06A59BF-BE18-49B5-93C7-8F390559853F'
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA FAZER CHECK-OUT COM CONSUMOS
CREATE PROCEDURE SP_REALIZAR_CHECK_OUT_CONSUMOS(
	@Cod_CheckOut UNIQUEIDENTIFIER,
    @Cod_Hospedagem UNIQUEIDENTIFIER,
    @Forma_Pagto VARCHAR(10),
    @Valor FLOAT,
    @Data_Pagto DATE,
	@Ativo BIT	
) AS
BEGIN
	INSERT INTO Check_Out(Codigo, Cod_Hospedagem, Ativo) VALUES 
			(@Cod_CheckOut, @Cod_Hospedagem, @Ativo);
	UPDATE Hospedagem SET Ativo = 0 WHERE Codigo = @Cod_Hospedagem;
	INSERT INTO Registro_Pagamento(Codigo, Cod_Hospedagem, Valor, Forma_Pagto, Data_Pagto, Ativo) VALUES 
			(NEWID(), @Cod_Hospedagem, @Valor, @Forma_Pagto, @Data_Pagto, @Ativo);
END
GO

DECLARE @IN UNIQUEIDENTIFIER
	SET @IN = NEWID()
	EXECUTE SP_REALIZAR_CHECK_OUT_CONSUMOS @Cod_CheckOut = @IN, @Cod_Hospedagem = 'D06A59BF-BE18-49B5-93C7-8F390559853F', @Forma_Pagto = 'Especie', @Valor = 71.5, @Data_Pagto = '26-02-2021', @Ativo = 1
GO

-- CRIAÇÃO DE UMA STORED PROCEDURE PARA FAZER CHECK-OUT SEM CONSUMOS
CREATE PROCEDURE SP_REALIZAR_CHECK_OUT(
	@Cod_CheckOut UNIQUEIDENTIFIER,
    @Cod_Hospedagem UNIQUEIDENTIFIER,
	@Ativo BIT	
) AS
BEGIN
	INSERT INTO Check_Out(Codigo, Cod_Hospedagem, Ativo) VALUES 
			(@Cod_CheckOut, @Cod_Hospedagem, @Ativo);
	UPDATE Hospedagem SET Ativo = 0 WHERE Codigo = @Cod_Hospedagem;
END
GO


-- CRIAÇÃO DE UMA STORED PROCEDURE PARA LISTAR OS REGISTROS DE PAGAMENTO
CREATE PROCEDURE SP_LISTAR_REGISTROS_PAGAMENTO AS
BEGIN
	SELECT	rp.Codigo AS [Cod_Registro],
			rp.Cod_Hospedagem,
			rp.Cod_Reserva,
			rp.Valor,
			rp.Forma_Pagto,
			FORMAT(rp.Data_Pagto, 'dd-MM-yyyy') AS [Data_Pagto],
			rp.Ativo AS [Ativo_Registro]
			FROM Registro_Pagamento rp
			WHERE rp.Ativo = 1
			ORDER BY rp.Data_Pagto DESC
END
GO

EXEC SP_LISTAR_REGISTROS_PAGAMENTO
GO