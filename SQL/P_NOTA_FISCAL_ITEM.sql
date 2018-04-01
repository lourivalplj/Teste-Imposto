USE [Teste]
GO

/****** Object:  StoredProcedure [dbo].[P_NOTA_FISCAL_ITEM]    Script Date: 01/04/2018 18:39:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_NOTA_FISCAL_ITEM]
(
	@pId int,
    @pIdNotaFiscal int,
    @pCfop varchar(5),
    @pTipoIcms varchar(20),
    @pBaseIcms decimal(18,5),
    @pAliquotaIcms decimal(18,5),
    @pValorIcms decimal(18,5),
	@pBaseIPI decimal(18,5),
    @pAliquotaIPI decimal(18,5),
    @pValorIPI decimal(18,5),
    @pNomeProduto varchar(50),
    @pCodigoProduto varchar(20)
)
AS
BEGIN
	IF (@pId = 0)
	BEGIN 		
		INSERT INTO [dbo].[NotaFiscalItem]
           ([IdNotaFiscal]
           ,[Cfop]
           ,[TipoIcms]
           ,[BaseIcms]
           ,[AliquotaIcms]
           ,[ValorIcms]
		   ,[BaseIPI]
		   ,[AliquotaIPI]
		   ,[ValorIPI]
           ,[NomeProduto]
           ,[CodigoProduto])
		VALUES
           (@pIdNotaFiscal,
			@pCfop,
			@pTipoIcms,
			@pBaseIcms,
			@pAliquotaIcms,
			@pValorIcms,
			@pBaseIPI,
			@pAliquotaIPI,
			@pValorIPI,
			@pNomeProduto,
			@pCodigoProduto)

		SET @pId = @@IDENTITY
	END
	ELSE
	BEGIN
		UPDATE [dbo].[NotaFiscalItem]
		SET [IdNotaFiscal] = @pIdNotaFiscal
			,[Cfop] = @pCfop
			,[TipoIcms] = @pTipoIcms
			,[BaseIcms] = @pBaseIcms
			,[AliquotaIcms] = @pAliquotaIcms
			,[ValorIcms] = @pValorIcms
			,[NomeProduto] = @pNomeProduto
			,[CodigoProduto] = @pCodigoProduto
		 WHERE Id = @pId
	END	    
END

GO

