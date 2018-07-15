CREATE PROC CreatePromo  @Percent int
AS
   
BEGIN TRANSACTION;
SAVE TRANSACTION MySavePoint;
BEGIN TRY
	UPDATE dbo.Product
	SET Price =  Price + (Price * @Percent / 100.0)

END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION MySavePoint; 
        END
    END CATCH
    COMMIT TRANSACTION 