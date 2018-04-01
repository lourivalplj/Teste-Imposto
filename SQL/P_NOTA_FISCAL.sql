USE [Teste]
GO

/****** Object:  StoredProcedure [dbo].[P_NOTA_FISCAL]    Script Date: 01/04/2018 18:39:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_NOTA_FISCAL] 
(
	@pId int OUTPUT,
	@pNumeroNotaFiscal int,
	@pSerie int,
	@pNomeCliente varchar(50),
	@pEstadoDestino varchar(50),
	@pEstadoOrigem varchar(50),
	@pDesconto int
)
AS
BEGIN
	IF (@pId = 0)
	BEGIN 
		INSERT INTO [dbo].[NotaFiscal]
           ([NumeroNotaFiscal]
           ,[Serie]
           ,[NomeCliente]
           ,[EstadoDestino]
           ,[EstadoOrigem]
		   ,[Desconto])
		VALUES
           (@pNumeroNotaFiscal
           ,@pSerie
           ,@pNomeCliente
           ,@pEstadoDestino
           ,@pEstadoOrigem
		   ,@pDesconto)

		SET @pId = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [dbo].[NotaFiscal]
		SET [NumeroNotaFiscal] = @pNumeroNotaFiscal
		  ,[Serie] = @pSerie
		  ,[NomeCliente] = @pNomeCliente
		  ,[EstadoDestino] = @pEstadoDestino
		  ,[EstadoOrigem] = @pEstadoOrigem
		WHERE Id = @pId
	END	    
END

GO

