# ContactList

1.Created a web api for contact list

2.Refer class libraries for application layer, service layer and infrastructure layer

3. Set ContactList.API as startup project
5.Create a database name : ContactList

 5.1. Created one table : [ContactList]

 Column_name	Type	Computed	Length	Prec	Scale	Nullable	TrimTrailingBlanks	FixedLenNullInSource	Collation
ContactId	int	no	4	10   	0    	no	(n/a)	(n/a)	NULL
Name	nvarchar	no	200	     	     	no	(n/a)	(n/a)	SQL_Latin1_General_CP1_CI_AS
Email	nvarchar	no	200	     	     	no	(n/a)	(n/a)	SQL_Latin1_General_CP1_CI_AS
PhoneNumber	nvarchar	no	200	     	     	no	(n/a)	(n/a)	SQL_Latin1_General_CP1_CI_AS
Category	nvarchar	no	200	     	     	no	(n/a)	(n/a)	SQL_Latin1_General_CP1_CI_AS
Birthdate	datetime	no	8	     	     	yes	(n/a)	(n/a)	NULL
Status	int	no	4	10   	0    	yes	(n/a)	(n/a)	NULL

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
