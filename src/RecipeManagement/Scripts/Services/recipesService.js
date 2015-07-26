(function () {
    'use strict';

    var recipesService = angular.module('recipesService', ['ngResource']);
    recipesService.factory('Recipes', ['$resource',
        function ($resource) {
            return $resource('/api/recipes', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }
    ]);
})();