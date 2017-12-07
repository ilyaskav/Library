'use strict';

app.controller('MainController', function ($scope, $http) {
    $scope.book = {};
    $scope.books = [];

    $scope.showAddBookSection = function () {
        $scope.action = 'add';
    }; 

    $scope.showEditBookSection = function (book) {
        $scope.action = 'edit';
        $scope.book = angular.copy(book);
    };

    $scope.redrawBooksTable = function () {
        $http.get('api/book')
            .then(function (res) {
                $scope.books = res.data;
            })
            .catch(function (err) {
                console.log(err);
            });
    };

    $scope.createBook = function (form) {
        $http.post('api/book', $scope.book)
            .then(function (res) {
                $scope.redrawBooksTable();
                $scope.cancel(); 
            })
            .catch(function (err) {
                console.log(err);
            });
    };

    $scope.editBook = function (book) {
        $http.put('api/book', $scope.book)
            .then(function (res) {
                $scope.redrawBooksTable();
                $scope.cancel();
            })
            .catch(function (err) {
                console.log(err);
            });
    };

    $scope.removeBook = function (book) {
        $http.delete('api/book/' + book.Id)
            .then(function (res) {
                var index = $scope.books.indexOf(book);
                $scope.books.splice(index, 1);
            })
            .catch(function (err) {
                console.log(err);
            });
    };

    $scope.cancel = function () {
        $scope.book = {};
        $scope.action = null;
    };
});