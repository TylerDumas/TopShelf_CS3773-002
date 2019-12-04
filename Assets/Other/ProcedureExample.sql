CREATE PROCEDURE [dbo].[spGetCouponsByZipCode]
    @ZipCode int
AS
begin
    set nocount on;
    
    select Id, Name, Description, StoreName, StoreZipCode, ImageURL
    from
    [dbo].[Coupons] where StoreZipCode = @ZipCode
end