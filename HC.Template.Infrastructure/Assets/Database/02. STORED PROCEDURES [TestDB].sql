use TestDB;

/*  *************************************************************** */
/*  1. sp_get_Customer                                              */
/*  2. sp_insert_Artist                                             */

/* ---------------------------------------------------------------- */
/*  1. sp_get_Customer                                              */

print 'sp_get_Customer'
if (select object_id('sp_get_Customer')) is not null
  drop procedure sp_get_Customer
go

create procedure sp_get_Customer
       @SupportRepId  int,
       @Country       varchar(40)
as
  set nocount on

  declare @Error             int          = 0,
          @SampleData        varchar(10)  = '',
          @ErrorMsg          varchar(max) = ''

  select cus.CustomerId, 
		 cus.FirstName, 
		 cus.LastName, 
		 cus.Country, 
		 cus.SupportRepId
    from dbo.Customer cus  
   where cus.SupportRepId = @SupportRepId
     and cus.Country = @Country  

  if @@Error <> 0
  begin
    select @ErrorMsg = 'Error retrieving customer data. (sp_get_Customer)'
    raiserror(@ErrorMsg, 16, 1)
    return 1
  end

go
/* ---------------------------------------------------------------- */
/*  2. sp_insert_Artist                                             */

print 'sp_insert_Artist'
if (select object_id('sp_insert_Artist')) is not null
  drop procedure sp_insert_Artist
go

create procedure sp_insert_Artist
	   @ArtistName varchar(40),
	   @ArtistId   int output
as
  set nocount on

  declare @Error             int          = 0,
          @SampleData        varchar(10)  = '',
          @ErrorMsg          varchar(max) = ''

  insert into [dbo].[Artist]
		   ([Name])
	   values
		   (@ArtistName)

  if @@Error <> 0 and @@ROWCOUNT <> 1
  begin
    select @ErrorMsg = 'Error inserting artist data. (sp_insert_Artist)'
    raiserror(@ErrorMsg, 16, 1)
    return 1
  end

  select @ArtistId = SCOPE_IDENTITY()

go