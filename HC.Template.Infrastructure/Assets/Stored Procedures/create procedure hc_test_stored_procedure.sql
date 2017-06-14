use Omega;

/* -------------------------------------------------------------------------- */
/*  1. hc_test_stored_procedure                                               */
print 'hc_test_stored_procedure'
if (select object_id('hc_test_stored_procedure')) is not null
  drop procedure hc_test_stored_procedure
go

create procedure hc_test_stored_procedure
       @Parameter1  int,
       @Parameter2  bit
as
  set nocount on

  declare @Error             int          = 0,
          @SampleData        varchar(10)  = '',
          @ErrorMsg          varchar(max) = ''

  set @SampleData = (select cast(@Parameter1 as varchar(10)))

  if (@Parameter2 = 0)
  begin
    select 'Stored Procedure: '            as 'Field5', 
           'hc_test_stored_procedure'      as 'Field6', 
           'Param2 = 0'                    as 'Field7', 
           'Sample Data 1: ' + @SampleData as 'Field8' 
    union 
    select 'Stored Procedure: '            as 'Field5', 
           'hc_test_stored_procedure'      as 'Field6', 
           'Param2 = 0'                    as 'Field7', 
           'Test Data 1: ' + @SampleData   as 'Field8' 
  end
  else
  begin
    select 'Stored Procedure: '            as 'Field5', 
           'hc_test_stored_procedure'      as 'Field6', 
           'Param2 = 0'                    as 'Field7', 
           'Sample Data 2: ' + @SampleData as 'Field8' 
    union
    select 'Stored Procedure: '            as 'Field5', 
           'hc_test_stored_procedure'      as 'Field6', 
           'Param2 = 0'                    as 'Field7', 
           'Test Data 2: ' + @SampleData   as 'Field8' 
  end

  if @@Error <> 0
  begin
    select @ErrorMsg = 'Error retrieving test data. (hc_adax_item_integration)'
    raiserror(@ErrorMsg, 16, 1)
    return 1
  end


go