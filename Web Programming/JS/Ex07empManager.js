class Employee {
    constructor(id, name, address, salary) {
        this.id = id;
        this.name = name;
        this.address = address;
        this.salary = salary;
    }
}

class EmployeeRepo{
    empList = [];

    addEmp = (emp) => this.empList = [...this.empList, emp];

    //removeEmp = (id) => this.empList = this.empList.filter(emp => emp.id != id);
    removeEmp = (id) => {
        const idx = this.empList.findIndex(e => e.id == id);
        if(idx >= 0){
            this.empList.splice(idx, 1);
        }
    }

    updateEmp = (emp) => {
        const idx = this.empList.findIndex(e => e.id == emp.id);
        if(idx >= 0){
            this.empList.splice(idx, 1, emp);
        }
    }

    updateEmpList = (emp) => {
        const employee = this.empList.find(e => e.id == emp.id);
        this.empList = [...this.empList, emp]
    }

    getAll = () => this.empList;

    getEmp = (id) => this.empList.find((e) => e.id == id); 
}