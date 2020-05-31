$(document).ready(() => {
    getProducts()
})
const addProduct = () => {
    $("#GetProductsCard").hide()
    $("#AddProductCard").show()
    $("#Category").hide()
    $("#AddCategory").hide()
}
const getProducts = () => {
    $("#GetProductsCard").show()
    $("#AddProductCard").hide()
    $("#Category").hide()
    $("#AddCategory").hide()
}
const getCategory = () => {
    $("#GetProductsCard").hide()
    $("#AddProductCard").hide()
    $("#Category").show()
    $("#AddCategory").hide()
}
const addCategory = () => {
    $("#GetProductsCard").hide()
    $("#AddProductCard").hide()
    $("#Category").hide()
    $("#AddCategory").show()
}
function readURL(input,namestr) {
    if (input.files && input.files[0]) {
        var reader = new FileReader()
        reader.onload = function (e) {
            $('#'+namestr).attr('src', e.target.result)
        }
        reader.readAsDataURL(input.files[0])
    }
}
$("#ProductImage").change(function () {
    readURL(this,'PreviewImage')
});
$("#ProductUpdatedImage").change(function () {
    readURL(this,'PreviewUpdatedImage')
});
$("#CategoryImage").change(function () {
    readURL(this,'CategoryPreviewImage')
});
$("#CategoryUpdatedImage").change(function () {
    readURL(this, 'CategoryUpdatedPreviewImage')
});