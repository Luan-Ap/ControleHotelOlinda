USE BD_CONTROLE_HOTEL_TESTE;

--Popular Tabela TIPO_QUARTO

INSERT INTO Tipo_Quarto(Codigo, Valor, Tipo, Max_Acompanhantes, Ativo) VALUES
	(NEWID(), 100, 'Single', 0, 1),
	(NEWID(), 180, 'Gêmeos', 1, 1),
	(NEWID(), 280, 'Couple', 1, 1),
	(NEWID(), 350, 'Family', 2, 1),
	(NEWID(), 420, 'Big Family', 3, 1)
GO

SELECT * FROM Tipo_Quarto;

--Popular Tabela QUARTO

INSERT INTO Quarto(Codigo, Num_Quarto, Cod_Tipo_Quarto, Descricao, Data_Cadastro, Ativo) VALUES
	(NEWID(), 1, 'A1A5123E-EC15-4942-AFFF-74769A6CA4CE', 'Quarto Single com 1 cama de solteiro e vista para o mar', '2021-01-01', 1),
	(NEWID(), 2, '20EDBA66-AA7E-4CFA-8AE6-0E142F1936CC', 'Quarto Gêmeos com 2 camas de solteiro', '2021-01-01', 1),
	(NEWID(), 3, '1F4518D2-DA8F-4B44-A6B4-1BC77B9E01CE', 'Quarto Couple com 1 cama de casal e vista para o mar', '2021-01-01', 1),
	(NEWID(), 4, '6027B54C-8177-4007-ADEA-55A1D67A698A', 'Quarto Family com 1 cama de casal e 1 cama de solteiro', '2021-01-01', 1),
	(NEWID(), 5, '8E50B8A1-07DA-4938-B700-BE54BB236C5E', 'Quarto Big Family com 1 cama de casal, 2 camas de solteiro e vista para o mar', '2021-01-01', 1),
	(NEWID(), 6, 'A1A5123E-EC15-4942-AFFF-74769A6CA4CE', 'Quarto Single com 1 cama de solteiro e vista para o mar', '2021-01-01', 1),
	(NEWID(), 7, '20EDBA66-AA7E-4CFA-8AE6-0E142F1936CC', 'Quarto Gêmeos com 2 camas de solteiro', '2021-01-01', 1),
	(NEWID(), 8, '1F4518D2-DA8F-4B44-A6B4-1BC77B9E01CE', 'Quarto Couple com 1 cama de casal e vista para o mar', '2021-01-01', 1),
	(NEWID(), 9, '6027B54C-8177-4007-ADEA-55A1D67A698A', 'Quarto Family com 1 cama de casal e 1 cama de solteiro', '2021-01-01', 1),
	(NEWID(), 10, '8E50B8A1-07DA-4938-B700-BE54BB236C5E', 'Quarto Big Family com 1 cama de casal, 2 camas de solteiro e vista para o mar', '2021-01-01', 1),
	(NEWID(), 11, 'A1A5123E-EC15-4942-AFFF-74769A6CA4CE', 'Quarto Single com 1 cama de solteiro e vista para o mar', '2021-01-01', 1),
	(NEWID(), 12, '20EDBA66-AA7E-4CFA-8AE6-0E142F1936CC', 'Quarto Gêmeos com 2 camas de solteiro', '2021-01-01', 1),
	(NEWID(), 13, '1F4518D2-DA8F-4B44-A6B4-1BC77B9E01CE', 'Quarto Couple com 1 cama de casal e vista para o mar', '2021-01-01', 1),
	(NEWID(), 14, '6027B54C-8177-4007-ADEA-55A1D67A698A', 'Quarto Family com 1 cama de casal e 1 cama de solteiro', '2021-01-01', 1),
	(NEWID(), 15, '8E50B8A1-07DA-4938-B700-BE54BB236C5E', 'Quarto Big Family com 1 cama de casal, 2 camas de solteiro e vista para o mar', '2021-01-01', 1)
GO

SELECT * FROM Quarto;

--Popular Tabela PRODUTO

INSERT INTO Produto(Codigo, Nome, Tipo_Produto, Valor, Quantidade, Data_Cadastro, Ativo) VALUES
	(NEWID(), 'Almoço', 'Serviço', 45, 1, '2021-01-01', 1),
	(NEWID(), 'Jantar', 'Serviço', 55, 1, '2021-01-01', 1),
	(NEWID(), 'Lavanderia', 'Serviço', 45, 1, '2021-01-01', 1),
	(NEWID(), 'Passar Roupa', 'Serviço', 20, 1, '2021-01-01', 1),
	(NEWID(), 'Lavanderia', 'Serviço', 45, 1, '2021-01-01', 1)
GO

INSERT INTO Produto(Codigo, Nome, Tipo_Produto, Valor, Quantidade, Data_Cadastro, Ativo) VALUES
	(NEWID(), 'Coca-Cola 2L', 'Mercadoria', 10, 50, '2021-01-01', 1),
	(NEWID(), 'Suco de Laranja', 'Mercadoria', 7, 20, '2021-01-01', 1),
	(NEWID(), 'Pepsi 2L', 'Mercadoria', 8, 45, '2021-01-01', 1),
	(NEWID(), 'Batata Ruffles', 'Mercadoria', 5, 40, '2021-01-01', 1),
	(NEWID(), 'Biscoito Bauduco', 'Mercadoria', 4, 30, '2021-01-01', 1)
GO

SELECT * FROM Produto ORDER BY Tipo_Produto;

--Popular Tabela ENDERECO

INSERT INTO Endereco(Codigo, Endereco, Numero, Cep, Telefone, Estado, Ativo) VALUES
	(NEWID(), 'Rua das Flores', '255', '06381200', '1141885074', 'SP', 1),
	(NEWID(), 'Rua da Esquina', '777', '08601300', '1141875579', 'SP', 1),
	(NEWID(), 'Rua de Baixo', '666', '66666666', '1166855466', 'SP', 1),
	(NEWID(), 'Rua de Cima', '111', '09703500', '1151855469', 'SP', 1),
	(NEWID(), 'Rua das Almas', '13', '07821235', '1175714227', 'SP', 1),
	(NEWID(), 'Rua do Meio', '55', '07802400', '1131865479', 'SP', 1),
	(NEWID(), 'Rua dos Santos', '25', '07981252', '1142796724', 'SP', 1),
	(NEWID(), 'Rua Angélica Souza', '12', '08369125', '1174299473', 'SP', 1),
	(NEWID(), 'Rua Maria das Dores', '267', '05679135', '1174297912', 'SP', 1),
	(NEWID(), 'Rua do Lado', '254', '09233456', '1184537123', 'SP', 1)
GO

SELECT * FROM Endereco;

--Popular Tabela CLIENTE

INSERT INTO Cliente(Codigo, Nome, Sobrenome, Cpf, Rg, Email, Cod_Endereco, Data_Nascimento, Data_Cadastro, Ativo) VALUES
	(NEWID(), 'Luan', 'Vasconcelos', '11111111111', '222222222', 'luan@email.com', '8ABD00C5-AB78-48F0-BC5F-54C412D10194', '2001-09-07', '2021-02-10', 1),
	(NEWID(), 'Johnny', 'Cage', '22222222222', '333333333', 'cage@email.com', '8570DBDB-81DA-42E3-A29C-4F91B5E7AAAC', '1992-01-01', '2021-02-10', 1),
	(NEWID(), 'Liu', 'Kang', '33333333333', '444444444', 'kang@email.com', '7EF393FD-4E54-4AFF-84DE-3EEDE6FEB154', '1990-05-07', '2021-02-10', 1),
	(NEWID(), 'Sub-Zero', 'Bi-Han', '55555555555', '666666666', 'zero@email.com', 'F6EDAEB4-AFD5-4311-9B70-32399E4F009F', '1990-03-01', '2021-02-10', 1),
	(NEWID(), 'Hanzo', 'Hasashi', '66666666666', '777777777', 'scorpion@email.com', '40FA5B45-6966-46F7-9385-55148E450BDC', '1990-06-06', '2021-02-10', 1)
GO

SELECT * FROM Cliente;

--Popular Tabela FUNCIONARIO

INSERT INTO Funcionario(Codigo, Nome, Sobrenome, Cpf, Rg, Ctps, Email, Cod_Endereco, Cargo, Salario, Data_Nascimento, Data_Cadastro, Ativo) VALUES
	(NEWID(), 'Baraka', 'Tarkatan', '14141414141', '151515151', '23232323232SP', 'baraka@email.com', '5F9D97BA-B1F6-42B8-AD85-90DFDF8302DE', 'Gerente', 5000, '1988-02-15', '2021-01-10', 1),
	(NEWID(), 'Jax', 'Briggs', '15151515151', '161616161', '24242424242SP', 'jax@email.com', '9FC37690-8DE7-4196-ABCE-C00D4E3BE27D', 'Recepcionista', 3000, '1986-05-15', '2021-01-10', 1),
	(NEWID(), 'Kitana', 'Edenia', '16161616161', '171717171', '25252525252SP', 'kitana@email.com', '32548DBD-77CA-4E74-9961-C1ADD43EEF02', 'Gerente', 4500, '1992-12-15', '2021-01-10', 1),
	(NEWID(), 'Milena', 'Edenia', '17171717171', '181818181', '26262626262SP', 'milena@email.com', 'CFFF8C7A-9929-48DF-9AAB-C641D0F6FFCA', 'Recepcionista', 2000, '1993-12-15', '2021-01-10', 1),
	(NEWID(), 'Kung', 'Lao', '18181818181', '191919191', '27272727272SP', 'kung@email.com', 'D20D659C-F52A-475F-B556-EDCA66E5AAD2', 'Recepcionista', 2000, '1994-10-07', '2021-01-10', 1)
GO

SELECT * FROM Funcionario;

--Popular Tabela FUNCIONARIO_USUARIO

INSERT INTO Funcionario_Usuario(Codigo, Usuario, Senha, Nivel_Acesso, Ativo) VALUES
	('21A6DDAB-5827-42F3-8938-5D68DFE14591', 'baraka@email.com', 'baraka123', 2, 1),
	('E0A89856-EB90-42BB-BBAF-85718B8342B1', 'kitana@email.com', 'kitana123', 2, 1),
	('3C96FFF6-8133-4037-A88A-BC78C4FFA92B', 'jax@email.com', 'jaxMaromba123', 1, 1),
	('42AD9E5A-E80A-4FFE-9EEA-83477988F3C8', 'milena@email.com', 'milenaSorridente123', 1, 1),
	('1A485E6B-694F-43F5-A547-E48B81C83E88', 'kung@email.com', 'kungLao123', 1, 1)
GO

SELECT * FROM Funcionario_Usuario;

--Popular Tabela RESERVA

SELECT * FROM Cliente
SELECT * FROM Quarto ORDER BY Num_Quarto
SELECT * FROM Tipo_Quarto ORDER BY Valor;

INSERT INTO Reserva(Codigo, Cod_Cliente, Cod_Quarto, Num_Acompanhantes, Data_Entrada, Data_Saida, Data_Reserva, Total_Diaria, Status_Reserva, Ativo) VALUES
	(NEWID(), '5C70AD3B-7328-471B-AB03-275F95B324E1', '6C40F524-315A-4A75-89D3-44CD1E49D5E6', 0, '2021-02-12', '2021-02-15', '2021-02-10', 300, 'Concluida', 1),
	(NEWID(), '6B814DFF-1AB5-44B1-A0C9-2C4E552CCB35', '414C9A86-06C4-45B4-BE40-BFCB7886CDCB', 1, '2021-02-15', '2021-02-20', '2021-02-10', 900, 'Concluida', 1),
	(NEWID(), '4EA9B196-D49E-48A8-8343-45CF2E57AF4C', '610F0B1A-FEE2-486D-B8FF-97C56A7F00B8', 1, '2021-02-20', '2021-02-23', '2021-02-10', 840, 'Concluida', 1),
	(NEWID(), '3B0C4861-7185-4253-8899-6D8115AAF041', '2A611446-8F8E-446B-9EB2-33E6F762A3B6', 2, '2021-02-12', '2021-02-16', '2021-02-10', 1400, 'Concluida', 1),
	(NEWID(), 'FE94AE75-9105-4CB6-9CD3-EE3591A1377D', '5AAB072F-87DA-4C7A-A370-E6BD1A719100', 3, '2021-02-18', '2021-02-22', '2021-02-10', 1680, 'Concluida', 1)
GO

SELECT * FROM Reserva;

--Popular Tabela REGISTRO_PAGAMENTO com Reservas

INSERT INTO Registro_Pagamento(Codigo, Cod_Reserva, Valor, Forma_Pagto, Data_Pagto, Ativo) VALUES
	(NEWID(), '2592ADAF-645B-4087-A1BD-4691BE17B751', 900, 'Debito', '2021-02-10', 1),
	(NEWID(), 'E8C6BE87-23FE-44D5-BFFE-8232383EF37C', 1400, 'Credito', '2021-02-10', 1),
	(NEWID(), 'A11D27CF-E815-4737-8F71-A1BA826419C2', 1680, 'Boleto', '2021-02-10', 1),
	(NEWID(), 'F136F8E0-7DF7-450C-8A04-C0C3C780A1CA', 840, 'Especie', '2021-02-10', 1),
	(NEWID(), '5F512A1D-537C-4325-847D-DE92A92039D3', 300, 'Debito', '2021-02-10', 1)
GO

SELECT * FROM Registro_Pagamento;


--Popular Tabela CHECK-IN

INSERT INTO Check_In(Codigo, Cod_Reserva, Ativo) VALUES
	(NEWID(), '2592ADAF-645B-4087-A1BD-4691BE17B751', 1),
	(NEWID(), 'E8C6BE87-23FE-44D5-BFFE-8232383EF37C', 1),
	(NEWID(), 'A11D27CF-E815-4737-8F71-A1BA826419C2', 1),
	(NEWID(), 'F136F8E0-7DF7-450C-8A04-C0C3C780A1CA', 1),
	(NEWID(), '5F512A1D-537C-4325-847D-DE92A92039D3', 1)
GO

SELECT * FROM Check_In;


--Popular Tabela HOSPEDAGEM

INSERT INTO Hospedagem(Codigo, Cod_Cliente, Cod_Quarto, Data_Entrada, Data_Saida, Consumo_Total, Ativo) VALUES
	(NEWID(), '6B814DFF-1AB5-44B1-A0C9-2C4E552CCB35', '414C9A86-06C4-45B4-BE40-BFCB7886CDCB', '2021-02-15', '2021-02-20', 0, 1),
	(NEWID(), '3B0C4861-7185-4253-8899-6D8115AAF041', '2A611446-8F8E-446B-9EB2-33E6F762A3B6', '2021-02-12', '2021-02-16', 0, 1),
	(NEWID(), 'FE94AE75-9105-4CB6-9CD3-EE3591A1377D', '5AAB072F-87DA-4C7A-A370-E6BD1A719100', '2021-02-18', '2021-02-22', 0, 1),
	(NEWID(), '4EA9B196-D49E-48A8-8343-45CF2E57AF4C', '610F0B1A-FEE2-486D-B8FF-97C56A7F00B8', '2021-02-20', '2021-02-23', 0, 1),
	(NEWID(), '5C70AD3B-7328-471B-AB03-275F95B324E1', '6C40F524-315A-4A75-89D3-44CD1E49D5E6', '2021-02-12', '2021-02-15', 0, 1)
GO

SELECT * FROM Hospedagem;

--Popular Table PRODUTO_HOSPEDAGEM

SELECT * FROM Produto ORDER BY Tipo_Produto
SELECT * FROM Hospedagem;

INSERT INTO Produto_Hospedagem(Codigo, Cod_Hospedagem, Cod_Produto, Qtd_Consumida, Valor_Total, Data_Consumo, Ativo) VALUES
	(NEWID(), '414005A0-1937-40D6-BC76-06681CAD05DC', '865EB7C7-D52E-4644-A84E-4322E354F892', 1, 55, '2021-02-16', 1),
	(NEWID(), '5A0F0125-D6D7-463C-B0B0-69F5CA69813A', 'AA059BAA-C605-4610-9F1A-2F53A9077ED9', 1, 45, '2021-02-21', 1),
	(NEWID(), '978393AA-5D29-4241-BD57-BA691A50518E', 'BC0501A4-39A9-49A2-B1DD-829891857664', 1, 45, '2021-02-12', 1),
	(NEWID(), '028091D2-D832-4A7A-9775-D56E1B4A9C61', '6EC3DFCC-25BD-4398-8A54-C7D51DB19087', 2, 20, '2021-02-20', 1),
	(NEWID(), '96B0DF69-D29D-440F-B6D9-E946C9C75B4F', 'CDB08DFD-86D9-4BB0-AED2-F61C2AB53FA9', 3, 15, '2021-02-13', 1)
GO

SELECT * FROM Produto_Hospedagem
GO

UPDATE Produto 
	SET Quantidade = 
		((select Quantidade from Produto WHERE Codigo = '6EC3DFCC-25BD-4398-8A54-C7D51DB19087') - 2)
	WHERE Codigo = '6EC3DFCC-25BD-4398-8A54-C7D51DB19087'
GO

UPDATE Produto 
	SET quantidade = 
		((select quantidade from Produto WHERE Codigo = 'CDB08DFD-86D9-4BB0-AED2-F61C2AB53FA9') - 2)
	WHERE Codigo = 'CDB08DFD-86D9-4BB0-AED2-F61C2AB53FA9'
GO

UPDATE Hospedagem
	SET Consumo_Total = Consumo_Total + 15
	WHERE Codigo = '96B0DF69-D29D-440F-B6D9-E946C9C75B4F'
GO

UPDATE Hospedagem
	SET Consumo_Total = Consumo_Total + 55
	WHERE Codigo = '414005A0-1937-40D6-BC76-06681CAD05DC'
GO

UPDATE Hospedagem
	SET Consumo_Total = Consumo_Total + 45
	WHERE Codigo = '5A0F0125-D6D7-463C-B0B0-69F5CA69813A'
GO

UPDATE Hospedagem
	SET Consumo_Total = Consumo_Total + 45
	WHERE Codigo = '978393AA-5D29-4241-BD57-BA691A50518E'
GO

UPDATE Hospedagem
	SET Consumo_Total = Consumo_Total + 20
	WHERE Codigo = '028091D2-D832-4A7A-9775-D56E1B4A9C61'
GO

SELECT * FROM Hospedagem
GO


--Popular Tabela CHECK_OUT

INSERT INTO Check_Out(Codigo, Cod_Hospedagem, Ativo) VALUES
	(NEWID(), '414005A0-1937-40D6-BC76-06681CAD05DC', 1),
	(NEWID(), '5A0F0125-D6D7-463C-B0B0-69F5CA69813A', 1),
	(NEWID(), '978393AA-5D29-4241-BD57-BA691A50518E', 1),
	(NEWID(), '028091D2-D832-4A7A-9775-D56E1B4A9C61', 1),
	(NEWID(), '96B0DF69-D29D-440F-B6D9-E946C9C75B4F', 1)
GO

SELECT * FROM Check_Out
GO

UPDATE Hospedagem
	SET Ativo = 0
GO

SELECT * FROM Hospedagem
GO


--Popular Tabela REGISTRO_PAGAMENTO com Hospedagem

INSERT INTO Registro_Pagamento(Codigo, Cod_Hospedagem, Valor, Forma_Pagto, Data_Pagto, Ativo) VALUES
	(NEWID(), '414005A0-1937-40D6-BC76-06681CAD05DC', 55, 'Debito', '2021-02-20', 1),
	(NEWID(), '5A0F0125-D6D7-463C-B0B0-69F5CA69813A', 45, 'Debito', '2021-02-23', 1),
	(NEWID(), '978393AA-5D29-4241-BD57-BA691A50518E', 45, 'Especie', '2021-02-15', 1),
	(NEWID(), '028091D2-D832-4A7A-9775-D56E1B4A9C61', 20, 'Especie', '2021-02-22', 1),
	(NEWID(), '96B0DF69-D29D-440F-B6D9-E946C9C75B4F', 15, 'Credito', '2021-02-16', 1)
GO

SELECT * FROM Registro_Pagamento
GO