USE FnfTraining;

CREATE TABLE Employee1 (
    Emp_Id INT PRIMARY KEY,
    Name VARCHAR(50),
    Salary INT,
    Manager_Id INT
);

INSERT INTO Employee1 (Emp_Id, Name, Salary, Manager_Id) VALUES
(1, 'Ram', 20000, 3),
(2, 'Sita', 12000, 5),
(3, 'Lakshman', 10000, 5),
(4, 'Rohit', 25000, 3),
(5, 'Yoshni', 30000, NULL);


SELECT * FROM Employee1;

SELECT e.Name AS emp_Name, m.Name AS manager_name
FROM Employee1 e
LEFT JOIN Employee1 m ON e.Manager_Id = m.Emp_Id
ORDER BY e.Name;