$(".basket-product-count").change((val) => {
    value = val.target.value
    if (isNaN(value - parseInt(value)) || value <= 0){
        val.target.value = 1
    } else {
        val.target.value = parseInt(value)
    }
})