CREATE FUNCTION dbo.BigIntegerToIPAddress (@IP AS BIGINT)
RETURNS VARCHAR(15)
AS
BEGIN
 DECLARE @Octet1 BIGINT
 DECLARE @Octet2 TINYINT
 DECLARE @Octet3 TINYINT
 DECLARE @Octet4 TINYINT
 DECLARE @RestOfIP BIGINT
 
 SET @Octet1 = @IP / 16777216
 SET @RestOfIP = @IP - (@Octet1 * 16777216)
 SET @Octet2 = @RestOfIP / 65536
 SET @RestOfIP = @RestOfIP - (@Octet2 * 65536)
 SET @Octet3 = @RestOfIP / 256
 SET @Octet4 = @RestOfIP - (@Octet3 * 256)
 
 RETURN(CONVERT(VARCHAR, @Octet1) + '.' +
        CONVERT(VARCHAR, @Octet2) + '.' +
        CONVERT(VARCHAR, @Octet3) + '.' +
        CONVERT(VARCHAR, @Octet4))
END