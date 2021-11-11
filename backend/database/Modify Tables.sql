-- modifying tables --
use BookStoreDB

alter table Users alter column uFName nvarchar(50)

alter table Books add bCreatedAt date not null

alter table Orders add totalPrice float

alter table UserAddresses add Phone nvarchar(10)