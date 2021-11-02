
create database BookStoreDB
use BookStoreDB
drop database BookStoreDB

create table Users
(uId int primary key identity(1000,1),
uFName nvarchar(50) not null,
uLName nvarchar(50) not null,
uPhone nvarchar(10) unique not null check  (uPhone like REPLICATE('[0-9]', 10)),
uMailId nvarchar(50) unique not null check (uMailId like '%_@__%.__%'),
uPassword nvarchar(50) not null  check (len([uPassword])>(5)),
uAccountStatus nvarchar(10) not null check (uAccountStatus in ('activated','deactivated')),
uRole nvarchar(10) not null check (uRole in('user','admin')))

create view LoginCredentials as
select uMailId,uPassword, uId, uRole
from Users
with check option


create table UserAddresses 
(id int identity primary key,
uId int foreign key references Users(uId),
uAddressLineOne nvarchar(100) not null,
uAddressLineTwo nvarchar(100),
uLandMark nvarchar(100),
uCity nvarchar(50) not null,
uState nvarchar(50) not null,
uCountry nvarchar(50) not null,
uPincode nvarchar(50) not null check(UPincode like REPLICATE('[0-9]', 6)))  


create table Authors 
(aId int primary key identity(100,1),
aFName nvarchar(50) not null,
aLName nvarchar(50),
aCountry nvarchar(50) not null)

create table Category 
(cId int primary key identity(200,1),
cName nvarchar(50) unique not null,
cDescription nvarchar(300) not null,
cImage nvarchar(50) not null,
cStatus nvarchar(10)not null  check (cStatus in ('activated','deactivated')),
cPosition int not null,
cCreatedAt date)

create table Books 
(bId int primary key identity(5000,1),
bName nvarchar(50) unique not null,
cId int foreign key references Category(cId),
aId int foreign key references Authors(aId),
bISBN varchar(17) not null,
bPrice float not null,
bDescription nvarchar(300)not null,
bPosition int not null, 
bStatus nvarchar(10) not null check (bStatus in ('activated','deactivated')),
bImage nvarchar(50) not null,
bQuantity int not null)

create table Coupons 
(coId int primary key,
coCode nvarchar(10) not null,
coName nvarchar(50) unique not null,
coExpiryDate date,
coDiscount float not null)

create table Orders 
(oId int primary key identity(10000,1),
uId int foreign key references Users(uId),
orDateAndTime date,
orCouponId int foreign key references Coupons(coId))

create table OrderDetails 
(ordrId int primary key identity,
oId int foreign key references Orders(oId),
uId int foreign key references Users(uId),
bId int foreign key references Books(bId),
bISBN varchar(17) not null,
bPrice float not null,
bQuantity int not null,
oTotalPrice float not null,
oShippingAddress nvarchar(250) not null,
oBillingAddress nvarchar(250) not null,
oPaymentMode nvarchar(10) not null)



create table Logs 
(lId int primary key identity,
uId int foreign key references Users(uId),
lLogType nvarchar(20),
lUserType nvarchar(10),
lDateAndTime date)









 







 











