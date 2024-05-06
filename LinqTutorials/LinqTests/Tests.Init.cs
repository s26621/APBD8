using LinqTasks.Models;

namespace LinqTests;

public partial class Tests
{
    private IList<Dept> LoadTestDepts()
    {
        List<Dept> deptsCol = new();

        Dept d1 = new()
        {
            Deptno = 1,
            Dname = "Research",
            Loc = "Warsaw"
        };

        Dept d2 = new()
        {
            Deptno = 2,
            Dname = "Human Resources",
            Loc = "New York"
        };

        Dept d3 = new()
        {
            Deptno = 3,
            Dname = "IT",
            Loc = "Los Angeles"
        };

        Dept d4 = new()
        {
            Deptno = 5,
            Dname = "Accounting",
            Loc = "Radom"
        };

        Dept d5 = new()
        {
            Deptno = 2137,
            Dname = "Testing",
            Loc = "VadoVice"
        };

        deptsCol.Add(d1);
        deptsCol.Add(d2);
        deptsCol.Add(d3);
        deptsCol.Add(d4);
        deptsCol.Add(d5);

        return deptsCol;
    }

    private IList<Emp> LoadTestEmps()
    {
        List<Emp> empsCol = new();

        Emp e1 = new()
        {
            Deptno = 1,
            Empno = 1,
            Ename = "Jan Kowalski",
            HireDate = DateTime.Now.AddMonths(-1),
            Job = "Frontend programmer",
            Mgr = null,
            Salary = 2000
        };

        Emp e2 = new()
        {
            Deptno = 1,
            Empno = 20,
            Ename = "Anna Malewska",
            HireDate = DateTime.Now.AddMonths(-7),
            Job = "Frontend programmer",
            Mgr = e1,
            Salary = 4000
        };

        Emp e3 = new()
        {
            Deptno = 1,
            Empno = 2,
            Ename = "Marcin Korewski",
            HireDate = DateTime.Now.AddMonths(-3),
            Job = "Frontend programmer",
            Mgr = null,
            Salary = 5000
        };

        Emp e4 = new()
        {
            Deptno = 2,
            Empno = 3,
            Ename = "Paweł Latowski",
            HireDate = DateTime.Now.AddMonths(-2),
            Job = "Backend programmer",
            Mgr = e2,
            Salary = 5500
        };

        Emp e5 = new()
        {
            Deptno = 2,
            Empno = 4,
            Ename = "Michał Kowalski",
            HireDate = DateTime.Now.AddMonths(-2),
            Job = "Backend programmer",
            Mgr = e2,
            Salary = 5500
        };

        Emp e6 = new()
        {
            Deptno = 2,
            Empno = 5,
            Ename = "Katarzyna Malewska",
            HireDate = DateTime.Now.AddMonths(-3),
            Job = "Manager",
            Mgr = null,
            Salary = 8000
        };

        Emp e7 = new()
        {
            Deptno = null,
            Empno = 6,
            Ename = "Andrzej Kwiatkowski",
            HireDate = DateTime.Now.AddMonths(-3),
            Job = "System administrator",
            Mgr = null,
            Salary = 7500
        };

        Emp e8 = new()
        {
            Deptno = 2,
            Empno = 7,
            Ename = "Marcin Polewski",
            HireDate = DateTime.Now.AddMonths(-3),
            Job = "Mobile developer",
            Mgr = null,
            Salary = 4000
        };

        Emp e9 = new()
        {
            Deptno = 2,
            Empno = 8,
            Ename = "Władysław Torzewski",
            HireDate = DateTime.Now.AddMonths(-9),
            Job = "CTO",
            Mgr = null,
            Salary = 12000
        };

        Emp e10 = new()
        {
            Deptno = 2,
            Empno = 9,
            Ename = "Andrzej Dalewski",
            HireDate = DateTime.Now.AddMonths(-4),
            Job = "Database administrator",
            Mgr = null,
            Salary = 9000
        };

        Emp e12 = new()
        {
            Deptno = 5,
            Empno = 100,
            Ename = "Marcin Marcinowski",
            HireDate = DateTime.Now.AddMonths(-10),
            Job = "KING",
            Mgr = null,
            Salary = 50000
        };

        Emp e11 = new()
        {
            Deptno = 5,
            Empno = 10,
            Ename = "Kunta Kinte",
            HireDate = DateTime.Now.AddMonths(-4),
            Job = "Backend programmer",
            Mgr = e12,
            Salary = 2000
        };


        empsCol.Add(e1);
        empsCol.Add(e2);
        empsCol.Add(e3);
        empsCol.Add(e4);
        empsCol.Add(e5);
        empsCol.Add(e6);
        empsCol.Add(e7);
        empsCol.Add(e8);
        empsCol.Add(e9);
        empsCol.Add(e10);
        empsCol.Add(e11);
        empsCol.Add(e12);

        return empsCol;
    }
}