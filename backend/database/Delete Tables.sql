-- delete Tables and data --
use BookStoreDB

drop table Logs
drop table OrderDetails
drop table Orders
drop table Books
drop table Coupons
drop table Category
drop table Authors
drop table UserAddresses
drop table LoginCredentials
drop table Users
drop table Wishlist

delete from UserAddresses
delete from Users

delete from Users where uId = 1011
delete from UserAddresses

delete from Books

drop table Wishlist