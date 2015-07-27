(function () {
    'use strict';

    angular
        .module('recipesApp')
        .controller('RecipesListController', RecipesListController)
        .controller('RecipesAddController', RecipesAddController)
        .controller('RecipesEditController', RecipesEditController)
        .controller('RecipesDeleteController', RecipesDeleteController);

    /* Recipes List Controller  */
    RecipesListController.$inject = ['$scope', 'Recipe'];

    function RecipesListController($scope, Recipe) {
        $scope.recipes = Recipe.query();
    }

    /* Recipes Create Controller */
    RecipesAddController.$inject = ['$scope', '$location', 'Recipe'];

    function RecipesAddController($scope, $location, Recipe) {
        $scope.recipe = new Recipe();
        $scope.add = function () {
            $scope.recipe.$save(function () {
                $location.path('/');
            });
        };
    }

    /* Recipes Edit Controller */
    RecipesEditController.$inject = ['$scope', '$routeParams', '$location', 'Recipe'];

    function RecipesEditController($scope, $routeParams, $location, Recipe) {
        $scope.recipe = Recipe.get({ id: $routeParams.id });
        $scope.edit = function () {
            $scope.recipe.$save(function () {
                $location.path('/');
            });
        };
    }

    /* Recipes Delete Controller  */
    RecipesDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Recipe'];

    function RecipesDeleteController($scope, $routeParams, $location, Recipe) {
        $scope.recipe = Recipe.get({ id: $routeParams.id });
        $scope.remove = function () {
            $scope.recipe.$remove({ id: $scope.recipe.Id }, function () {
                $location.path('/');
            });
        };
    }


})();