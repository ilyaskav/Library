'use strict';

app.controller('MainController', function ($scope, $http) {
    $scope.book = {};

    $scope.showAddBookSection = function () {
        $scope.action = 'add';
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