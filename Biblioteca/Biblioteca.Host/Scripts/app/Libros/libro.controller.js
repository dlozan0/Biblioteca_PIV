//ha este controlador tenemos que hagregarle el editorialService para que pueda traer las editoriales de la BD
//tambien agregaremso los siguiente justamente debajo de agregar 

$scope.obtenerEditoriales = function () {
    editorialService.obtenerEditoriales()
    .then(function(response)){
    $scope.editoriales = rsponse.data;


}
}