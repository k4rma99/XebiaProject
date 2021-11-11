const { request } = require("http")

module.exports = function(){
    var faker = require("faker");
    var _ = require("lodash");
    return {
        books: _.times(20,function(n){
            return {
                id:n,
                bName:faker.commerce.productName(),
                image:faker.image.sports(),
                author:{
                    aFName:faker.name.findName()
                },
                category:{
                    cName:faker.name.findName()
                },
                bPrice:faker.commerce.price(),
                bISBN:faker.phone.phoneNumber()
            }
        }),
        cart:_.times(4,function(n){
            return {
                id:n,
                book:{
                    id:n*10,
                    title:faker.commerce.productName(),
                    image:faker.image.sports(),
                    author:faker.name.findName(),
                    price:faker.commerce.price(),
                   
                }
            }
        }),
        orders:[],
        coupons:[
            {
                "id":1,
                "couponCode":"IND374",
                "discount":10
            }
        ],
        address:_.times(2,function(n){
            return {
                id:n,
                name:faker.name.firstName(),
                city:faker.commerce.productName(),
                phone:faker.commerce.productAdjective(),
                pincode:faker.commerce.price()
                }
            
        })
    }
}