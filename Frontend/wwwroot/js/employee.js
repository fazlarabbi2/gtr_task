const apiBaseUrl = "https://localhost:5001/api";

// Load data on page load
$(document).ready(function () {
    loadDepartments();
    loadDesignations();
    loadEmployees();
    loadProducts();

    // Form submission
    $("#employeeForm").submit(function (event) {
        event.preventDefault();
        saveEmployee();
    });
});

// Load Departments
function loadDepartments() {
    $.get(`${apiBaseUrl}/Department`, function (data) {
        const departmentSelect = $("#departmentId");
        departmentSelect.empty();
        data.forEach((department) => {
            departmentSelect.append(
                `<option value="${department.id}">${department.name}</option>`
            );
        });
    });
}

// Load Designations
function loadDesignations() {
    $.get(`${apiBaseUrl}/Designation`, function (data) {
        const designationSelect = $("#designationId");
        designationSelect.empty();
        data.forEach((designation) => {
            designationSelect.append(
                `<option value="${designation.id}">${designation.title}</option>`
            );
        });
    });
}

// Load Employees
function loadEmployees() {
    $.get(`${apiBaseUrl}/Employee`, function (data) {
        const employeeTable = $("#employeeTable tbody");
        employeeTable.empty();
        data.forEach((employee) => {
            employeeTable.append(`
                <tr>
                    <td>${employee.id}</td>
                    <td>${employee.name}</td>
                    <td>${employee.department.name}</td>
                    <td>${employee.designation.title}</td>
                    <td>${employee.email}</td>
                    <td>
                        <button onclick="editEmployee(${employee.id})">Edit</button>
                        <button onclick="deleteEmployee(${employee.id})">Delete</button>
                    </td>
                </tr>
            `);
        });
    });
}

// Save Employee
function saveEmployee() {
    const employee = {
        id: parseInt($("#employeeId").val()),
        name: $("#employeeName").val(),
        departmentId: parseInt($("#departmentId").val()),
        designationId: parseInt($("#designationId").val()),
        email: $("#employeeEmail").val(),
    };

    const method = employee.id === 0 ? "POST" : "PUT";
    const url = employee.id === 0
        ? `${apiBaseUrl}/Employee`
        : `${apiBaseUrl}/Employee/${employee.id}`;

    $.ajax({
        url: url,
        type: method,
        contentType: "application/json",
        data: JSON.stringify(employee),
        success: function () {
            loadEmployees();
            clearForm();
        },
    });
}

// Edit Employee
function editEmployee(id) {
    $.get(`${apiBaseUrl}/Employee/${id}`, function (employee) {
        $("#employeeId").val(employee.id);
        $("#employeeName").val(employee.name);
        $("#departmentId").val(employee.departmentId);
        $("#designationId").val(employee.designationId);
        $("#employeeEmail").val(employee.email);
    });
}

// Delete Employee
function deleteEmployee(id) {
    if (confirm("Are you sure you want to delete this employee?")) {
        $.ajax({
            url: `${apiBaseUrl}/Employee/${id}`,
            type: "DELETE",
            success: function () {
                loadEmployees();
            },
        });
    }
}

// Load Products
function loadProducts() {
    $.get("https://www.pqstec.com/InvoiceApps/values/GetProductListAll", function (data) {
        const productTable = $("#productTable tbody");
        productTable.empty();
        data.forEach((product) => {
            productTable.append(`
                <tr>
                    <td>${product.id}</td>
                    <td>${product.name}</td>
                    <td>${product.price}</td>
                </tr>
            `);
        });
    });
}

// Clear Form
function clearForm() {
    $("#employeeId").val(0);
    $("#employeeName").val("");
    $("#departmentId").val("");
    $("#designationId").val("");
    $("#employeeEmail").val("");
}
