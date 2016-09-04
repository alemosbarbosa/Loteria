var app;
(function (app) {
    var common;
    (function (common) {
        var services;
        (function (services) {
            var DataService = (function () {
                function DataService($http, $q) {
                    this.httpService = $http;
                    this.qService = $q;
                }
                DataService.prototype.get = function (resource) {
                    var self = this;
                    var deferred = self.qService.defer();
                    self.httpService.get(resource).then(function (result) {
                        deferred.resolve(result.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
                    return deferred.promise;
                };
                DataService.prototype.getSingle = function (resource) {
                    var self = this;
                    var deferred = self.qService.defer();
                    self.httpService.get(resource).then(function (result) {
                        deferred.resolve(result.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
                    return deferred.promise;
                };
                DataService.prototype.add = function (resource, entity) {
                    var self = this;
                    var deferred = self.qService.defer();
                    self.httpService.post(resource, entity)
                        .then(function (result) {
                        deferred.resolve(result.data);
                    }, function (error) {
                        deferred.reject(error);
                    });
                    return deferred.promise;
                };
                DataService.prototype.update = function (resource, entity) {
                    var self = this;
                    var deferred = self.qService.defer();
                    self.httpService.put(resource, entity)
                        .then(function (data) {
                        deferred.resolve(data);
                    }, function (error) {
                        deferred.reject(error);
                    });
                    return deferred.promise;
                };
                DataService.prototype.remove = function (resource) {
                    var self = this;
                    var deferred = self.qService.defer();
                    self.httpService.delete(resource)
                        .then(function (data) {
                        deferred.resolve(data);
                    }, function (error) {
                        deferred.reject(error);
                    });
                    return deferred.promise;
                };
                DataService.$inject = ['$http', '$q'];
                return DataService;
            }());
            services.DataService = DataService;
            angular.module('loteriaApp')
                .service('dataService', DataService);
        })(services = common.services || (common.services = {}));
    })(common = app.common || (app.common = {}));
})(app || (app = {}));
//# sourceMappingURL=dataService.js.map