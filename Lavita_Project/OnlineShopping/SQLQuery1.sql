create table products
(
	ID int NOT NULL PRIMARY KEY,
    ProdName varchar(255) NOT NULL,
    Price varchar(255),
	ImageUrl varchar(255)
);

drop table Cart
create table Cart
(
	userId varchar(255) NOT NULL PRIMARY KEY,
	ProdID int FOREIGN KEY REFERENCES products(ID),
    ProdName varchar(255) NOT NULL,
	ImageUrl varchar(255),
    EachPrice varchar(255),
	Quantity int,
	Total varchar(255)	
);

insert into products values (1,'flower','408.00','~/Images/flower.png')
insert into products values (2,'shoes','600.00','~/Images/shoe.png')
insert into products values (3,'shert','700.00','~/Images/shert.png')

Create procedure spGetAllProducts
as
Begin
 Select Id, ProdName,Price,ImageUrl
 from products
End

create procedure spAddToCart
@userId varchar(255),
@prodid int,
@prodName varchar(255),
@ImageUrl varchar(255),
@price varchar(255),
@qnty int,
@total varchar(255)
as
Begin
insert into Cart 
values (@userId,@prodid,@prodName,@ImageUrl,@price,@qnty,@total)
End

create procedure spGetFromCart
@userId varchar(255),
@prodid int
as
Begin
 select * from Cart where userId = @userId and ProdID = @prodid
 End

 create procedure spGetAllCartForUser
 @userId varchar(255)
as
begin
select * from Cart where userId = @userId
End

select * from products