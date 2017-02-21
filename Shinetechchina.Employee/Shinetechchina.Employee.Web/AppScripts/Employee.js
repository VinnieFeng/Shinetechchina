(function (Employee, undefined) {
    var module = angular.module('employeeApp', []);
    module.controller('employeeCtrl', function ($scope, $http) {
        $scope.EmployeeList = [];
        $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '', IsAdd: false };

        $scope.loadEmployeeList = function loadEmployeeList() {
            $http.get("/employee/GetAll").then(function (response) {
                $scope.EmployeeList = response.data;
            }, function (e) {
                //error method
            });
        }

        $scope.addEmployee = function () {
            var url = "";
            if ($scope.Employee.IsAdd) {
                url = "/employee/Add"
            } else {
                url = "/employee/Update"
            }
            $http.post(url, $scope.Employee).then(function (response) {
                if (response.data) {
                    $scope.Employee = { EmployeeID: '', FirstName: '', LastName: '', Phone: '', Email: '' };
                    $scope.loadEmployeeList();
                    $scope.closeAddForm();
                } else {
                    //save fail 
                }
            }, function (e) {
                //save fail 
            });
        };

        // Delete one customer based on id.
        $scope.delEmployee = function (id) {
            if (confirm("Are you sure you want to delete this customer?")) {
                // todo code for deletion
                $http.post("/employee/delete", { empID: id }).then(function (response) {
                    if (response.data) {
                        alert("Deleted successfully.");
                        // Refresh list
                        $scope.loadEmployeeList();
                    } else {
                        //save fail 
                    }
                }, function (e) {
                    //save fail 
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