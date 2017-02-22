(function (Employee, undefined) {
    var module = angular.module('employeeApp', []);
    module.controller('employeeCtrl', function ($scope, $http) {
        $scope.EmployeeApiUri = "/api/Employees/";
        $scope.EmployeeList = [];
        $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '', IsAdd: false };

        $scope.loadEmployeeList = function loadEmployeeList() {
            $http.get($scope.EmployeeApiUri).then(function (response) {
                $scope.EmployeeList = response.data;
            }, function (e) {
                alert(e.data.Message);
            });
        }

        $scope.addEmployee = function () {
            if ($scope.Employee.IsAdd) {
                $http.post($scope.EmployeeApiUri, $scope.Employee).then(function (response) {
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
                $http.put($scope.EmployeeApiUri + $scope.Employee.EmployeeID, $scope.Employee).then(function (response) {
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
                $http.delete($scope.EmployeeApiUri + id).then(function (response) {
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