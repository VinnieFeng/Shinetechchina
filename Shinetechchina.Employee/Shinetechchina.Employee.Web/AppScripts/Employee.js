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
        var $body = $('body');
        $scope.loadEmployeeList = function loadEmployeeList() {
            employeeService.getEmployees().then(function (response) {
                $scope.EmployeeList = response.data;
            }, function (e) {
                showAlert('error', e.data.Message);
            });
        }

        $scope.addEmployee = function () {
            if ($scope.Employee.IsAdd) {
                $body.mask('processing', 500);
                employeeService.addEmployee($scope.Employee).then(function (response) {
                    $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '' };
                    $scope.loadEmployeeList();
                    $scope.closeAddForm();
                    showAlert('success', 'success');
                    $body.unmask();
                }, function (e) {
                    $body.unmask();
                    showAlert('error', e.data.Message);
                });
            } else {
                $body.mask('processing', 500);
                employeeService.updateEmployee($scope.Employee).then(function (response) {
                    $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '' };
                    $scope.loadEmployeeList();
                    $scope.closeAddForm();
                    showAlert('success', 'success');
                    $body.unmask();
                }, function (e) {
                    $body.unmask();
                    showAlert('error', e.data.Message);
                });
            }
        };

        // Delete one customer based on id.
        $scope.delEmployee = function (id) {
            if (confirm("Are you sure you want to delete this customer?")) {
                // todo code for deletion
                $body.mask('processing', 500);
                employeeService.deleteEmployee(id).then(function (response) {
                    showAlert('success', 'delete success');
                    // Refresh list
                    $scope.loadEmployeeList();
                    $body.unmask();
                }, function (e) {
                    showAlert('error', e.data.Message);
                    $body.unmask();
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

        function showAlert(type, msg) {
            var $alert = $(".alert-success");
            if (type === 'error') {
                $alert = $(".alert-error");
            } else if (type === 'error') {
                $alert = $(".alert-success");
            }

            $alert.text(msg).fadeTo(2000, 500).slideUp(500, function () {
                $alert.slideUp(500);
            });
        }
    });
}(window.Employee = window.Employee || {}));