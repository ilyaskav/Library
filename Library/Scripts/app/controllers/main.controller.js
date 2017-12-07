'use strict';

app.controller('MainController', function ($scope, $http) {
    $scope.book = {};
    $scope.books = [];

    $scope.showAddBookSection = function () {
        $scope.action = 'add';
    }; 

    $scope.showEditBookSection = function () {
        $scope.action = 'edit';
    };

    $scope.redrawBooksTable = function () {
        $http.get('api/book')
            .then(function (res) {
                $scope.books = res;
                console.log(res);
            })
            .catch(function (err) {
                console.log(err);
            });
    };

    $scope.createBook = function (form) {
        $http.post('api/book', $scope.book)
            .then(function (res) {
                console.log(res);
            })
            .catch(function (err) {
                console.log(err);
            });
    };

    $scope.cancel = function () {
        $scope.action = null;
    };
});