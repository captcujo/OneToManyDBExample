namespace OneToManyDBExample.Controllers
{

    export class HomeController 
    {
        public message = 'Hello from the home page!';

        public movies;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            this.$http.get('/api/movies').then((response) =>
            {
                this.movies = response.data;
            })
        }
    }

    export class DetailController
    {
        public movie;

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            let movieId = this.$stateParams['id'];

            this.$http.get('/api/movies/' + movieId).then((response) =>
            {
                this.movie = response.data;
            })
        }

        public deleteMovie()
        {
            console.log("delete Movie hit");

            this.$http.delete('/api/movies/'+ this.movie.id ).then((response) =>
            {
                this.$state.go('home');
            })
        }
    }

    export class CatagoriesController
    {
        public catagoryMovies;

        constructor(private $stateParams: ng.ui.IStateParamsService, private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            let catagoryId = this.$stateParams['id'];

            this.$http.get('/api/catagories/' + catagoryId).then((response) =>
            {
                this.catagoryMovies = response.data;
            })
        }
    }   

    export class CatagoryController
    {
        public catagories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            this.$http.get('/api/catagories').then((response) =>
            {
                this.catagories = response.data;
            })
        }

        public deleteCategory(catId: number)
        {
            console.log("deleteCategory id = ", catId);

            this.$http.delete('/api/catagories/' + catId).then((response) =>
            {
                this.$state.go('home');
            })
        }
    }

    export class AddCategoryController
    {
        message = "hello from the AddCategoryController";

        public category;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {

        }

        public addCategory()
        {
            this.$http.post('/api/catagories', this.category).then((response) =>
            {
                this.$state.go('catagories');
            })
        }

    }

    export class AddMovieController
    {
        public movie;

        public categories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService)
        {
            this.$http.get('/api/catagories').then((response) =>
            {
                this.categories = response.data;
            })
        }

        addMovie()
        {
            this.$http.post('/api/movies', this.movie).then((response) =>
            {
                this.$state.go('home');
            })
        }
    }

    export class editMovieController
    {
        public movie;

        public categories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService)
        {
            let movieId = this.$stateParams['id'];

            this.$http.get('/api/movies/' + movieId).then((response) =>
            {
                this.movie = response.data;
            })

            this.$http.get('/api/catagories').then((response) =>
            {
                this.categories = response.data;
            })
        }

        public editMovie()
        {
            console.log("editMovie hit catagory.id = ", this.movie.catagory.id);

            this.$http.post('/api/movies', this.movie).then((response) =>
            {
                this.$state.go('detail', { id: this.movie.id });
            })
        }
    }

    export class AboutController
    {
        public message = 'Hello from the about page!';
    }

}
