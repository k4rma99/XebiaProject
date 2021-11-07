const { request } = require("http")

module.exports = function(){
    var faker = require("faker");
    var _ = require("lodash");
    return {
        books: _.times(20,function(n){
            return {
                id:n,
                title:faker.commerce.productName(),
                image:faker.image.sports(),
                author:faker.name.findName(),
                price:faker.commerce.price()
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