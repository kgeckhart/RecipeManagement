!function(){"use strict";function config($routeProvider,$locationProvider){$locationProvider.html5Mode(!0),$routeProvider.when("/",{templateUrl:"/Views/list.html",controller:"RecipesListController"}).when("/recipes/add",{templateUrl:"/Views/add.html",controller:"RecipesAddController"}).when("/recipes/edit/:id",{templateUrl:"/Views/edit.html",controller:"RecipesEditController"}).when("/recipes/delete/:id",{templateUrl:"/Views/delete.html",controller:"RecipesDeleteController"})}angular.module("recipesApp",["ngRoute","recipesServices"]).config(config)}(),function(){"use strict";function RecipesListController($scope,Recipe){$scope.recipes=Recipe.query()}function RecipesAddController($scope,$location,Recipe){$scope.recipe=new Recipe,$scope.add=function(){$scope.recipe.$save(function(){$location.path("/")})}}function RecipesEditController($scope,$routeParams,$location,Recipe){$scope.recipe=Recipe.get({id:$routeParams.id}),$scope.edit=function(){$scope.recipe.$save(function(){$location.path("/")})}}function RecipesDeleteController($scope,$routeParams,$location,Recipe){$scope.recipe=Recipe.get({id:$routeParams.id}),$scope.remove=function(){$scope.recipe.$remove({id:$scope.recipe.Id},function(){$location.path("/")})}}angular.module("recipesApp").controller("RecipesListController",RecipesListController).controller("RecipesAddController",RecipesAddController).controller("RecipesEditController",RecipesEditController).controller("RecipesDeleteController",RecipesDeleteController),RecipesListController.$inject=["$scope","Recipe"],RecipesAddController.$inject=["$scope","$location","Recipe"],RecipesEditController.$inject=["$scope","$routeParams","$location","Recipe"],RecipesDeleteController.$inject=["$scope","$routeParams","$location","Recipe"]}(),function(){"use strict";function Recipe($resource){return $resource("/api/recipes/:id")}angular.module("recipesServices",["ngResource"]).factory("Recipe",Recipe),Recipe.$inject=["$resource"]}();