(function () {
    'use strict';

    angular
        .module('recipesApp')
        .controller('recipesController', recipesController);

    recipesController.$inject = ['$scope', 'Recipes'];

    function recipesController($scope, Recipes) {
        $scope.title = 'recipesController';
        $scope.Recipes = Recipes.query();
    }
})();
