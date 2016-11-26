//creamos controller 
app.controller('editorialController', [
    '$scope',
    function ($scope) {
        $scope.editoriales = [
            {
                id: '1',
                nombre: 'editorial 1'

            },
        {
        id: '2',
        nombre: 'editorial 2',

        }
        ];
        $scope.editorialActual = {
            id: '123',
            nombre: '123'
        };

    }

])