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
                    price:faker.commerce.price()
                }
            }
        })
    }
}