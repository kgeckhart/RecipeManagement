(function () {
    'use strict';

    angular.module('recipesApp', [
        'ngRoute', 'recipesServices'
    ]).config(config);

    function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                templateUrl: '/Views/list.html',
                controller: 'RecipesListController'
            })
            .when('/recipes/add', {
                templateUrl: '/Views/add.html',
                controller: 'RecipesAddController'
            })
            .when('/recipes/edit/:id', {
                templateUrl: '/Views/edit.html',
                controller: 'RecipesEditController'
            })
            .when('/recipes/delete/:id', {
                templateUrl: '/Views/delete.html',
                controller: 'RecipesDeleteController'
            });
    }

})();