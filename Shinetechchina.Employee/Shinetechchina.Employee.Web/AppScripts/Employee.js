(function (Employee, undefined) {
    var employeeApp = angular.module('employeeApp', []);

    employeeApp.factory('employeeService', ['$http', function ($http) {
        var employeeApiUri = "/api/Employees/";
        var employeeService = {};
        employeeService.getEmployees = function () {
            return $http.get(employeeApiUri);
        };
        employeeService.addEmployee = function (d) {
            return $http.post(employeeApiUri, d);
        };
        employeeService.updateEmployee = function (d) {
            return $http.put(employeeApiUri + d.EmployeeID, d);
        };
        employeeService.deleteEmployee = function (id) {
            return $http.delete(employeeApiUri + id);
        };
        return employeeService;
    }]);

    employeeApp.controller('employeeCtrl', function ($scope, employeeService) {
        $scope.EmployeeList = [];
        $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '', IsAdd: false };

        $scope.loadEmployeeList = function loadEmployeeList() {
            employeeService.getEmployees().then(function (response) {
                $scope.EmployeeList = response.data;
            }, function (e) {
                alert(e.data.Message);
            });
        }

        $scope.addEmployee = function () {
            if ($scope.Employee.IsAdd) {
                employeeService.addEmployee($scope.Employee).then(function (response) {
                    if (response.data) {
                        $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '' };
                        $scope.loadEmployeeList();
                        $scope.closeAddForm();
                    } else {
                        //save fail 
                    }
                }, function (e) {
                    alert(e.data.Message);
                });
            } else {
                employeeService.updateEmployee($scope.Employee).then(function (response) {
                    if (response.data) {
                        $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '' };
                        $scope.loadEmployeeList();
                        $scope.closeAddForm();
                    } else {
                        //save fail 
                    }
                }, function (e) {
                    alert(e.data.Message);
                });
            }
        };

        // Delete one customer based on id.
        $scope.delEmployee = function (id) {
            if (confirm("Are you sure you want to delete this customer?")) {
                // todo code for deletion
                employeeService.deleteEmployee(id).then(function (response) {
                    if (response.data) {
                        alert("Deleted successfully.");
                        // Refresh list
                        $scope.loadEmployeeList();
                    } else {
                        //save fail 
                    }
                }, function (e) {
                    alert(e.data.Message);
                });
            }
        };

        $scope.openEditForm = function (emp) {
            $scope.Employee.IsAdd = false;
            $scope.Employee.EmployeeID = emp.EmployeeID.trim();
            $scope.Employee.FirstName = emp.FirstName.trim();
            $scope.Employee.LastName = emp.LastName.trim();
            $scope.Employee.Phone = emp.Phone.trim();
            $scope.Employee.Email = emp.Email.trim();
            $('#formModal').modal({
                keyboard: true,
            });
        };

        $scope.openAddForm = function () {
            $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '', IsAdd: true };
            $('#formModal').modal({
                keyboard: true,
            });
        };

        $scope.closeAddForm = function () {
            $('#formModal').modal('hide');
        };

        $scope.loadEmployeeList();
    });
}(window.Employee = window.Employee || {}));