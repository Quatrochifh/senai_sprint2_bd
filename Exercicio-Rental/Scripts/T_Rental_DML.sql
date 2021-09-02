USE T_Rental;
GO


-----------DML-----------

INSERT INTO EMPRESA(nomeEmpresa)
VALUES('Juarezmotors'),('Carrinhos');
GO

 INSERT INTO CLIENTE(nomeCliente, sobrenomeCliente) VALUES(@nomeCliente)

INSERT INTO CLIENTE(nomeCliente,sobrenomeCliente, cpfCliente)
VALUES ('Ana', 'Catharina', 90719176069),('Fabio', 'Quatrochi',01135695059);
GO

DELETE FROM CLIENTE 
WHERE idCliente = 7


INSERT INTO MARCA(nomeMarca)
VALUES('VW'),('Chevrolet');
GO
 = @idCliente

INSERT INTO MODELO(nomeModelo, idMarca)
VALUES('Gol', 1),('Corsa',2),('jetta',1);
GO


INSERT INTO VEICULO(idEmpresa, idModelo, PlacaVeiculo)
VALUES(2, 1,2213),(1,2,45678),(1,1,4545),(2,3,6873);
GO



INSERT INTO ALUGUEL(idVeiculo, idCliente, Descricao)
VALUES(2, 2, '12.12.21 A 15.12.21'),(3,3, '15.02.21 A 16.02.21');
GO

SELECT *  FROM VEICULO 

--DELETE FROM ALUGUEL 
--WHERE idAluguel in(7,8)
--GO