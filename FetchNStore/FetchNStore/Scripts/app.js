'use strict';
var app = angular.module('fetchNStuff', []);


app.controller("requests", ($scope, DOOMFactory) => {
    $scope.request = {
        method: "",
        url: ""
    };
    $scope.sendRequest = () => {
        DOOMFactory.request($scope.request);
    };
});


app.factory("DOOMFactory", ($http, $q) => {
    var request = (requestInfo) => {
        return $q((resolve) => {
            let startTime = Date.now();
            $http({
                method: requestInfo.method,
                url: requestInfo.url
            }).success((code) => {
                let endTime = Date.now();
                let total = endTime - startTime;
                console.log(code, requestInfo.url, requestInfo.method, total);
                resolve(code, requestInfo.url, requestInfo.method, total);
            }).error((code) => {
                let endTime = Date.now();
                let total = endTime - startTime;
                console.log(code, requestInfo.url, requestInfo.method, total);
                resolve(total, code);
            })
        })
    };
    return { request: request };
});