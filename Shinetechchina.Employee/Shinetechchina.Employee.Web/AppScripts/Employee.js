(function (Employee, undefined) {
    var employeeApp = angular.module('employeeApp', []);

    employeeApp.constant('EMPLOYEE_API_URI', '/api/Employees/')
        .factory('employeeService', function ($http, EMPLOYEE_API_URI, $log) {

            var employeeService = {};
            employeeService.getEmployees = function () {
                return $http.get(EMPLOYEE_API_URI);
            };
            employeeService.addEmployee = function (d) {
                return $http.post(EMPLOYEE_API_URI, d);
            };
            employeeService.updateEmployee = function (d) {
                return $http.put(EMPLOYEE_API_URI + d.EmployeeID, d);
            };
            employeeService.deleteEmployee = function (id) {
                return $http.delete(EMPLOYEE_API_URI + id);
            };
            return employeeService;
        });

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
            $scope.Employee.EmployeeID = emp.EmployeeID;
            $scope.Employee.FirstName = emp.FirstName;
            $scope.Employee.LastName = emp.LastName;
            $scope.Employee.Phone = emp.Phone;
            $scope.Employee.Email = emp.Email;
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