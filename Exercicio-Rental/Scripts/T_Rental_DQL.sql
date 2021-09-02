USE T_Rental;
GO

SELECT * FROM EMPRESA;
GO

SELECT * FROM CLIENTE;
GO

SELECT * FROM MARCA;
GO

SELECT * FROM MODELO;
GO

SELECT * FROM VEICULO;
GO

SELECT * FROM ALUGUEL;
GO

 --listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro

 SELECT Descricao Data_inicio_e_fim, nomeCliente,sobrenomeCliente,nomeModelo, PlacaVeiculo  FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
GO


-- listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

 SELECT Descricao, nomeCliente,nomeModelo, PlacaVeiculo  FROM ALUGUEL
INNER JOIN CLIENTE
ON ALUGUEL.idCliente = CLIENTE.idCliente
INNER JOIN VEICULO
ON ALUGUEL.idVeiculo = VEICULO.idVeiculo
INNER JOIN MODELO
ON MODELO.idModelo = VEICULO.idModelo
WHERE CLIENTE.nomeCliente = 'Fabio';
GO


SELECT idAluguel,idVeiculo,idCliente,Descricao FROM ALUGUEL;
GO

SELECT * FROM ALUGUEL;
GO

SELECT idCliente, nomeCliente, sobrenomeCliente, cpfCliente FROM CLIENTE;
GO