--CRIAÇÃO DO BANCO DE DADOS

CREATE DATABASE BD_CONTROLE_HOTEL_TESTE;

USE BD_CONTROLE_HOTEL_TESTE;

--CRIAÇÃO DAS TABELAS

CREATE TABLE Cliente (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
	Sobrenome VARCHAR(150) NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    Rg VARCHAR(9) NOT NULL,
	Email VARCHAR(150) NOT NULL,
	Cod_Endereco UNIQUEIDENTIFIER NOT NULL,
	Data_Nascimento DATE NOT NULL,
	Data_Cadastro DATE NOT NULL,
	Ativo BIT NOT NULL,
    UNIQUE (Cpf, Rg, Email)
);

CREATE TABLE Funcionario (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
	Sobrenome VARCHAR(150) NOT NULL,
	Cpf VARCHAR(11) NOT NULL,
    Rg VARCHAR(9) NOT NULL,
    Ctps VARCHAR(15) NOT NULL,
	Email VARCHAR(150) NOT NULL,
    Cod_Endereco UNIQUEIDENTIFIER NOT NULL,
    Salario FLOAT NOT NULL,
    Cargo VARCHAR(150) NOT NULL,
    Data_Nascimento DATE NOT NULL,
	Data_Cadastro DATE NOT NULL,
	Ativo BIT NOT NULL,
    UNIQUE (Cpf, Rg, Ctps, Email)
);

CREATE TABLE Funcionario_Usuario (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Usuario VARCHAR(150) UNIQUE NOT NULL,
    Senha VARCHAR(150) NOT NULL,
	Nivel_Acesso INT NOT NULL,
	Ativo BIT NOT NULL,
	UNIQUE(Usuario)
);

CREATE TABLE Endereco(
	Codigo UNIQUEIDENTIFIER PRIMARY KEY,
	Endereco VARCHAR(150) NOT NULL,
	Numero VARCHAR(6) NOT NULL,
	Cep VARCHAR(8) NOT NULL,
	Telefone VARCHAR(11) NOT NULL,
	Estado CHAR(2) NOT NULL,
	Ativo BIT NOT NULL
);

CREATE TABLE Reserva (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Cod_Cliente UNIQUEIDENTIFIER NOT NULL,
    Cod_Quarto UNIQUEIDENTIFIER NOT NULL,
    Num_Acompanhantes INT NOT NULL,
    Total_Diaria FLOAT NOT NULL,
    Data_Entrada DATE NOT NULL,
    Data_Saida DATE NOT NULL,
    Data_Reserva DATE NOT NULL,
	Status_Reserva VARCHAR(10) NOT NULL CHECK(Status_Reserva IN('Ativa', 'Concluida', 'Cancelada')),
	Ativo BIT NOT NULL
);

CREATE TABLE Quarto (
	Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Num_Quarto INT NOT NULL,
	Descricao VARCHAR(250) NOT NULL,
    Cod_Tipo_Quarto UNIQUEIDENTIFIER NOT NULL,
    Data_Cadastro DATE NOT NULL,
	Ativo BIT NOT NULL
	UNIQUE(Num_Quarto)
);

CREATE TABLE Tipo_Quarto (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Valor FLOAT NOT NULL,
    Tipo VARCHAR(30) NOT NULL,
	Max_Acompanhantes INT NOT NULL,
	Ativo BIT NOT NULL
);

CREATE TABLE Hospedagem (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Cod_Cliente UNIQUEIDENTIFIER NOT NULL,
	Cod_Quarto UNIQUEIDENTIFIER NOT NULL,
    Data_Entrada DATE NOT NULL,
    Data_Saida DATE NOT NULL,
	Consumo_Total FLOAT DEFAULT 0,
	Ativo BIT NOT NULL
);

CREATE TABLE Produto (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Nome VARCHAR(150) NOT NULL,
    Quantidade INT NOT NULL,
    Valor FLOAT NOT NULL,
    Data_Cadastro DATE NOT NULL,
	Tipo_Produto VARCHAR(20) NOT NULL CHECK(Tipo_Produto IN('Mercadoria', 'Serviço')),
	Ativo BIT NOT NULL
);

CREATE TABLE Produto_Hospedagem (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
	Cod_Hospedagem UNIQUEIDENTIFIER NOT NULL,
    Cod_Produto UNIQUEIDENTIFIER NOT NULL,
    Qtd_Consumida INT NOT NULL,
    Valor_Total FLOAT NOT NULL,
    Data_Consumo DATE NOT NULL,
	Ativo BIT NOT NULL
);

CREATE TABLE Check_In (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
	Cod_Reserva UNIQUEIDENTIFIER NOT NULL,
	Ativo BIT NOT NULL,
	UNIQUE(Cod_Reserva)
);

CREATE TABLE Check_Out (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Cod_Hospedagem UNIQUEIDENTIFIER NOT NULL,
	Ativo BIT NOT NULL,
	UNIQUE(Cod_Hospedagem)
);

CREATE TABLE Registro_Pagamento (
    Codigo UNIQUEIDENTIFIER PRIMARY KEY,
    Cod_Reserva UNIQUEIDENTIFIER,
	Cod_Hospedagem UNIQUEIDENTIFIER,
    Forma_Pagto VARCHAR(10) NOT NULL CHECK(Forma_Pagto IN('Debito', 'Credito', 'Boleto', 'Especie', 'Pix')),
    Valor FLOAT NOT NULL,
    Data_Pagto DATE NOT NULL,
	Ativo BIT NOT NULL
);

--CRIAÇÃO DOS RELACIONAMENTOS
 
ALTER TABLE Funcionario_Usuario ADD CONSTRAINT FK_Login_Func
    FOREIGN KEY (Codigo)
    REFERENCES Funcionario (Codigo);
 
ALTER TABLE Check_Out ADD CONSTRAINT FK_Check_Out
    FOREIGN KEY (Cod_Hospedagem)
    REFERENCES Hospedagem (Codigo);
 
ALTER TABLE Hospedagem ADD CONSTRAINT FK_Hospedagem_Cliente
    FOREIGN KEY (Cod_Cliente)
    REFERENCES Cliente (Codigo);
 
ALTER TABLE Hospedagem ADD CONSTRAINT FK_Hospedagem_Quarto
    FOREIGN KEY (Cod_Quarto)
    REFERENCES Quarto (Codigo);
 
ALTER TABLE Produto_Hospedagem ADD CONSTRAINT FK_Produto_Consumido_Produto
    FOREIGN KEY (Cod_Produto)
    REFERENCES Produto (Codigo);

ALTER TABLE Produto_Hospedagem ADD CONSTRAINT FK_Produto_Consumido_Hospedagem
    FOREIGN KEY (Cod_Hospedagem)
    REFERENCES Hospedagem (Codigo);
 
ALTER TABLE Quarto ADD CONSTRAINT FK_Quarto_Tipo_Quarto
    FOREIGN KEY (Cod_Tipo_Quarto)
    REFERENCES Tipo_Quarto (Codigo);
 
ALTER TABLE Check_In ADD CONSTRAINT FK_Check_In_Reserva
    FOREIGN KEY (Cod_Reserva)
    REFERENCES Reserva (Codigo);
 
ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Cliente
    FOREIGN KEY (Cod_Cliente)
    REFERENCES Cliente (Codigo);
 
ALTER TABLE Reserva ADD CONSTRAINT FK_Reserva_Quarto
    FOREIGN KEY (Cod_Quarto)
    REFERENCES Quarto (Codigo);
 
ALTER TABLE Registro_Pagamento ADD CONSTRAINT FK_Registro_Pagamento_Reserva
    FOREIGN KEY (Cod_Reserva)
    REFERENCES Reserva (Codigo);
 
ALTER TABLE Registro_Pagamento ADD CONSTRAINT FK_Registro_Pagamento_Hospedagem
    FOREIGN KEY (Cod_Hospedagem)
    REFERENCES Hospedagem (Codigo);

SELECT * FROM sys.tables;

SELECT 'Cliente'				AS TABELA, COUNT(1) AS LINHAS FROM Cliente				UNION ALL
SELECT 'Funcionario'			AS TABELA, COUNT(1) AS LINHAS FROM Funcionario			UNION ALL
SELECT 'Funcionario_Usuario'	AS TABELA, COUNT(1) AS LINHAS FROM Funcionario_Usuario	UNION ALL
SELECT 'Check_Out'				AS TABELA, COUNT(1) AS LINHAS FROM Check_Out			UNION ALL
SELECT 'Produto'				AS TABELA, COUNT(1) AS LINHAS FROM Produto				UNION ALL
SELECT 'Quarto'					AS TABELA, COUNT(1) AS LINHAS FROM Quarto				UNION ALL
SELECT 'Tipo_Quarto'			AS TABELA, COUNT(1) AS LINHAS FROM Tipo_Quarto			UNION ALL
SELECT 'Check-In'				AS TABELA, COUNT(1) AS LINHAS FROM Check_In				UNION ALL
SELECT 'Reserva'				AS TABELA, COUNT(1) AS LINHAS FROM Reserva				UNION ALL
SELECT 'Registro_Pagamento'		AS TABELA, COUNT(1) AS LINHAS FROM Registro_Pagamento	UNION ALL
SELECT 'Hospedagem'				AS TABELA, COUNT(1) AS LINHAS FROM Hospedagem;

EXEC sp_columns Funcionario_Usuario;