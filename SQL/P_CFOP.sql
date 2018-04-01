USE [Teste]
GO

/****** Object:  StoredProcedure [dbo].[P_CFOP]    Script Date: 01/04/2018 18:39:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_CFOP] 
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		Cfop, 
		Sum(BaseICMS), 
		Sum(ValorIcms),
		Sum(BaseIPI), 
		Sum(ValorIPI)
	FROM
		NotaFiscalItem
	GROUP BY
		Cfop
END
GO

