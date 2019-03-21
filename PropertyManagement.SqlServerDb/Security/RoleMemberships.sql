ALTER ROLE [db_securityadmin] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_owner] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_denydatareader] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_ddladmin] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_datawriter] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_datareader] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_backupoperator] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];


GO
ALTER ROLE [db_accessadmin] ADD MEMBER [IIS APPPOOL\PropertyManagementWebApi];

