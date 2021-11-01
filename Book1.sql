create database BookStoreDB
use BookStoreDB

create table UserTable
(uId int primary key,
uFName nvarchar(50) not null,
uSName nvarchar(50) not null,
uPhone nvarchar(10) unique not null,
uMailId nvarchar(50) unique not null,
uAccountStatus nvarchar(10) not null,
uRole nvarchar(10) not null)

create table LoginCredentials
(uName nvarchar(50) unique not null,
uPassword nvarchar(50) not null,
uId int foreign key references UserTable(uId),
uRole nvarchar(10) not null)


create table UserAddressesTable 
(uId int foreign key references UserTable(uId),
uAddressLineOne nvarchar(100) not null,
uAddressLineTwo nvarchar(100),
uLandMark nvarchar(50),
uCity nvarchar(50) not null,
uState nvarchar(50) not null,
uCountry nvarchar(50) not null,
uPincode nvarchar(50) not null)


create table AuthorTable 
(aId int primary key,
aFName nvarchar(50) not null,
aSName nvarchar(50),
aCountry nvarchar(50) not null)

create table CategoryTable 
(cId int primary key,
cName nvarchar(50) unique not null,
cDescription nvarchar(300) not null,
cImage nvarchar(50) not null,
cStatus nvarchar(10)not null,
cPosition int not null,
cCreatedAt date)

create table BookTable 
(bId int primary key,
bName nvarchar(50) unique not null,
cId int foreign key references CategoryTable(cId),
aId int foreign key references AuthorTable(aId),
bISBN varchar(17) not null,
bPrice float not null,
bDescription nvarchar(300)not null,
bPosition int not null, 
bStatus nvarchar(10) not null,
bImage nvarchar(50) not null,
bQuantity int not null)

create table FeaturedBooksTable
(bId int foreign key references BookTable(bId),
bName nvarchar(50) unique not null,
bISBN varchar(17) not null)

create table OrderDetailsTable 
(oId int primary key,
uId int foreign key references UserTable(uId),
bId int foreign key references BookTable(bId),
oISBN varchar(17) not null,
oTotalPrice float not null,
oShippingAddress nvarchar(250) not null,
oBillingAddress nvarchar(250) not null,
oPaymentMode nvarchar(10) not null)

create table CouponTable 
(coId nvarchar(10) primary key,
coName nvarchar(50) unique not null,
coExpiryDate date,
coDiscount float)

create table Orders 
(orId int foreign key references OrderDetailsTable(oId),
uId int not null,
orDateAndTime date,
orCouponId nvarchar(10) foreign key references CouponTable(coId))

create table LogTable 
(lId int primary key,
uId int foreign key references UserTable(uId),
lUserType nvarchar(10),
lDateAndTime date)









 







 











