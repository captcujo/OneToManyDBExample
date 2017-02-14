namespace OneToManyDBExample {

    angular.module('OneToManyDBExample', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: OneToManyDBExample.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('detail', {
                url: '/detail/:id',
                templateUrl: '/ngApp/views/detail.html',
                controller: OneToManyDBExample.Controllers.DetailController,
                controllerAs: 'controller'
            })
            .state('catagory', {
                url: '/catagory/:id',
                templateUrl: '/ngApp/views/catagory.html',
                controller: OneToManyDBExample.Controllers.CatagoriesController,
                controllerAs: 'controller'
            })
            .state('catagories', {
                url: '/catagories',
                templateUrl: '/ngApp/views/catagories.html',
                controller: OneToManyDBExample.Controllers.CatagoryController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: OneToManyDBExample.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('addCategory', {
                url: '/addCategory',
                templateUrl: '/ngApp/views/addCategory.html',
                controller: OneToManyDBExample.Controllers.AddCategoryController,
                controllerAs: 'controller'
            })
            .state('addMovie', {
                url: '/addMovie',
                templateUrl: '/ngApp/views/addMovie.html',
                controller: OneToManyDBExample.Controllers.AddMovieController,
                controllerAs: 'controller'
            })
            .state('editMovie', {
                url: '/editMovie/:id',
                templateUrl: '/ngApp/views/editMovie.html',
                controller: OneToManyDBExample.Controllers.editMovieController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    

}
