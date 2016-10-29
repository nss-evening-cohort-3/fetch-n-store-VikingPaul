'use strict';
var app = angular.module('fetchNStuff', []);


app.controller("requests", ($scope, DOOMFactory, $http) => {
    $scope.request = {
        method: "",
        url: ""
    };
    $scope.display = {
        statusCode: "",
        url: "",
        method: "",
        time: ""
    };
    $http.get('api/response').success((data) => {
        console.log(data);
    })
    $scope.sendRequest = () => {
        DOOMFactory.request($scope.request).then((response) => {
            $scope.display = response;
        });
    };
    $scope.saveRequest = () => {
        DOOMFactory.responseSave($scope.display)
    }
});


app.factory("DOOMFactory", ($http, $q) => {
    var request = (requestInfo) => {
        return $q((resolve) => {
            let startTime = Date.now();
            $http({
                method: requestInfo.method,
                url: requestInfo.url
            }).success((data, status) => {
                let endTime = Date.now();
                let total = endTime - startTime;
                let response = {
                    statusCode: status,
                    url: requestInfo.url,
                    method: requestInfo.method,
                    time: total
                };
                resolve(response);
            }).error((error, status) => {
                let endTime = Date.now();
                let total = endTime - startTime;
                let response = {
                    statusCode: status,
                    url: requestInfo.url,
                    method: requestInfo.method,
                    time: total
                };
                resolve(response);
            })
        })
    };

    var responseSave = (data) => {
        $http.post('api/response', data).success(() => {
            console.log("success")
        })
    };
    var responseGet = () => {
        return $q((resolve) => {
            let startTime = Date.now();
            $http.get('api/response').success((data) => {
                resolve(data);
            })
        })
    }

    return { request: request, responseSave: responseSave, responseGet: responseGet };
});