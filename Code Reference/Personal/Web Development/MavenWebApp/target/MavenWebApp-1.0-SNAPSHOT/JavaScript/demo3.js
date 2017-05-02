var app3 = angular.module('app3', []);

app3.controller('gListCtrl', function($scope){
    
    $scope.groceries = [{item:'Tomatoes', purchased:false}, {item:'Carrots', purchased:false}, {item:'Potatoes', purchased:false}];
    
    $scope.getList = function() {
        return $scope.showList ? "Demo HTML Excerpts/ul.html" : "Demo HTML Excerpts/ol.html";
    }
});