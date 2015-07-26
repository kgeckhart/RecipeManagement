(function () {
    'use strict';

    angular
        .module('recipesServices', ['ngResource'])
        .factory('Recipe', Recipe);

    Recipe.$inject = ['$resource'];

    function Recipe($resource) {
        return $resource('/api/recipes/:id');
    }
})();