# ContactList

1.Created a web api for contact list

2.Refer class libraries for application layer, service layer and infrastructure layer

3. Set ContactList.API as startup project
5.Create a database name : ContactList

 5.1. Created one table : [ContactList]
-----------------------------------------------------------------------------
USE [ContactList]
GO

/****** Object:  Table [dbo].[ContactList]    Script Date: 12/11/2023 4:10:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactList](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](100) NOT NULL,
	[Category] [nvarchar](100) NOT NULL,
	[Birthdate] [datetime] NULL,
	[Status] [int] NULL
) ON [PRIMARY]
GO
---------------------------------------------------------

5. Run through postman
     - Basic authentication is needed.

        username = "TestUser"

       Password = "P@ssw0rd"
        
6. APIs
   
   5.1 . Create Contact

            url : https://localhost:44308/api/ContactList

            body : {
                  "name": "string",
                  "email": "user@example.com",
                  "phoneNumber": "string",
                  "category": "string",
                  "birthdate": "2023-12-10T22:25:07.680Z",
                  "status": 0
                }
                
    5.2 . Get All contact list
          url : https://localhost:44308/api/ContactList
          
    5.3. get Contact by contactId
          url : https://localhost:44308/api/ContactList/{id}
          
    5.4. Update contact
         url : https://localhost:44308/api/ContactList

           body : {
                  "contactId": "string",
                  "name": "string",
                  "email": "user@example.com",
                  "phoneNumber": "string",
                  "category": "string",
                  "birthdate": "2023-12-10T22:30:11.776Z",
                  "status": 0
                }

     5.5. get by page
   
          url : https://localhost:44308/api/ContactList/GetByPage?PageNumber={id}&RowCount={id}&SearchText={id}&SortColumns={columnName}&SortDirection={ASC/DESC}

    5.6. Delete contact
   
          url : https://localhost:44308/api/ContactList/{id}
