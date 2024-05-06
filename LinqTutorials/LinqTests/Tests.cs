using LinqTasks;
using LinqTasks.Models;
using Xunit;

namespace LinqTests;

public partial class Tests
{
    private IEnumerable<Emp> EmpsTest { get; }

    private IEnumerable<Dept> DeptsTest { get; }

    private int[] Array = { 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 10, 2, 10, 10 };

    public Tests()
    {
        DeptsTest = LoadTestDepts();
        EmpsTest = LoadTestEmps();

        Tasks.Depts = DeptsTest;
        Tasks.Emps = EmpsTest;
    }

    /// <summary>
    ///     SELECT * FROM Emps WHERE Job = "Backend programmer";
    /// </summary>
    [Fact]
    public void Task1_Test()
    {
        IEnumerable<Emp> studRes = Tasks.Task1().ToList();

        Assert.NotNull(studRes);
        Assert.Equal(3, studRes.Count());

        Assert.Contains(studRes, x => x.Empno == 3);
        Assert.Contains(studRes, x => x.Empno == 4);
        Assert.Contains(studRes, x => x.Empno == 10);
    }

    /// <summary>
    ///     SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
    /// </summary>
    [Fact]
    public void Task2_Test()
    {
        IEnumerable<Emp> studRes = Tasks.Task2().ToList();

        Assert.NotNull(studRes);
        Assert.Equal(3, studRes.Count());

        Assert.Contains(studRes, x => x.Empno == 2);
        Assert.Contains(studRes, x => x.Empno == 1);
        Assert.Contains(studRes, x => x.Empno == 20);
        
        Assert.Equal(2,studRes.First().Empno);
        Assert.Equal("Marcin Korewski",studRes.First().Ename);
        
        Assert.Equal(20,studRes.Last().Empno);
        Assert.Equal("Anna Malewska",studRes.Last().Ename);
    }


    /// <summary>
    ///     SELECT MAX(Salary) FROM Emps;
    /// </summary>
    [Fact]
    public void Task3_Test()
    {
        int studRes = Tasks.Task3();

        Assert.True(studRes >= 0);
        Assert.True(studRes == 50000);
    }


    /// <summary>
    ///     SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
    /// </summary>
    [Fact]
    public void Task4_Test()
    {
        IEnumerable<Emp> studRes = Tasks.Task4().ToList();

        Assert.NotNull(studRes);
        Assert.Single(studRes);

        Emp empResult = studRes.First();
        Assert.Equal("Marcin Marcinowski", empResult.Ename);
        Assert.Equal(100, empResult.Empno);
        Assert.Equal(50000, empResult.Salary);
    }


    /// <summary>
    ///     SELECT ename AS Nazwisko, job AS Praca FROM Emps;
    /// </summary>
    [Fact]
    public void Task5_Test()
    {
        IEnumerable<object> studRes = Tasks.Task5().ToList();

        Assert.NotNull(studRes);
        Assert.Equal(12, studRes.Count());

        object firstEmp = studRes.First();
        Assert.Equal(new { Nazwisko = "Jan Kowalski", Praca = "Frontend programmer" }.ToString(),firstEmp.ToString());
    }

    /// <summary>
    ///     SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
    ///     INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
    ///     Rezultat: Złączenie kolekcji Emps i Depts.
    /// </summary>
    [Fact]
    public void Task6_Test()
    {
        IEnumerable<object> studRes = Tasks.Task6()?.ToList();

        Assert.NotNull(studRes);
        
        Assert.Equal(new { Ename = "Marcin Marcinowski", Job = "KING", Dname = "Accounting" }.ToString(), studRes.Last().ToString());
    }


    /// <summary>
    ///     SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
    /// </summary>
    [Fact]
    public void Task7_Test()
    {
        IEnumerable<object> studRes = Tasks.Task7()?.ToList();

        Assert.NotNull(studRes);
        Assert.Equal(8, studRes.Count());
        
        Assert.Equal(new { Praca = "Frontend programmer", LiczbaPracownikow = 3 }.ToString(), studRes.First().ToString());
        Assert.Equal(new { Praca = "KING", LiczbaPracownikow = 1 }.ToString(), studRes.Last().ToString());
    }

    /// <summary>
    ///     Zwróć wartość "true" jeśli choć jeden
    ///     z elementów kolekcji pracuje jako "Backend programmer".
    /// </summary>
    [Fact]
    public void Task8_Test()
    {
        bool studRes = Tasks.Task8();

        Assert.True(studRes);
    }

    /// <summary>
    ///     SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
    ///     ORDER BY HireDate DESC;
    /// </summary>
    [Fact]
    public void Task9_Test()
    {
        Emp studRes = Tasks.Task9();

        Assert.NotNull(studRes);

        Assert.Equal("Jan Kowalski", studRes.Ename);
        Assert.Equal(1, studRes.Empno);
    }

    /// <summary>
    ///     SELECT Ename, Job, Hiredate FROM Emps
    ///     UNION
    ///     SELECT "Brak wartości", null, null;
    /// </summary>
    [Fact]
    public void Task10_Test()
    {
        IEnumerable<object> studRes = Tasks.Task10().ToList();

        Assert.NotNull(studRes);

        DateTime? kingHiredate = EmpsTest.First(x => x.Job == "KING").HireDate;

        Assert.Equal(13, studRes.Count());
        Assert.Equal(new { Ename = "Marcin Marcinowski", Job = "KING", HireDate = kingHiredate }.ToString(), studRes.ElementAt(11).ToString());
        Assert.Equal(new { Ename = "Brak wartości", Job = string.Empty, HireDate = (DateTime?)null }.ToString(), studRes.Last().ToString());
    }

    /// <summary>
    ///     Wykorzystując LINQ pobierz pracowników podzielony na departamenty pamiętając, że:
    ///     1. Interesują nas tylko departamenty z liczbą pracowników powyżej 1
    ///     2. Chcemy zwrócić listę obiektów o następującej srukturze:
    ///     [
    ///     {name: "RESEARCH", numOfEmployees: 3},
    ///     {name: "SALES", numOfEmployees: 5},
    ///     ...
    ///     ]
    ///     3. Wykorzystaj typy anonimowe
    /// </summary>
    [Fact]
    public void Task11_Test()
    {
        IEnumerable<object> studRes = Tasks.Task11().ToList();

        Assert.NotNull(studRes);

        Assert.Equal(new { Name = "Accounting", NumOfEmployees = 2 }.ToString().ToLower(), studRes.Last().ToString().ToLower());
    }

    /// <summary>
    ///     Napisz własną metodę rozszerzeń, która pozwoli skompilować się poniższemu fragmentowi kodu.
    ///     Metodę dodaj do klasy CustomExtensionMethods, która zdefiniowana jest poniżej.
    ///     Metoda powinna zwrócić tylko tych pracowników, którzy mają min. 1 bezpośredniego podwładnego.
    ///     Pracownicy powinny w ramach kolekcji być posortowani po nazwisku (rosnąco) i pensji (malejąco).
    /// </summary>
    [Fact]
    public void Task12_Test()
    {
        IEnumerable<Emp> studRes = Tasks.Task12().ToList();

        Assert.NotNull(studRes);

        Assert.Contains(studRes, x => x.Ename == "Marcin Marcinowski" && x.Empno == 100);
        
        Assert.Equal("Anna Malewska", studRes.First().Ename);
        Assert.Equal("Marcin Marcinowski", studRes.Last().Ename);
    }

    /// <summary>
    ///     Poniższa metoda powinna zwracać pojedyczną liczbę int.
    ///     Na wejściu przyjmujemy listę liczb całkowitych.
    ///     Spróbuj z pomocą LINQ'a odnaleźć tę liczbę, które występuja w tablicy int'ów nieparzystą liczbę razy.
    ///     Zakładamy, że zawsze będzie jedna taka liczba.
    ///     Np: {1,1,1,1,1,1,10,1,1,1,1} => 10
    /// </summary>
    [Fact]
    public void Task13_Test()
    {
        int studRes = Tasks.Task13(Array);

        Assert.True(studRes >= 0);
        Assert.Equal(2, studRes);
    }

    /// <summary>
    ///     Zwróć tylko te departamenty, które mają 5 pracowników lub nie mają pracowników w ogóle.
    ///     Posortuj rezultat po nazwie departament rosnąco.
    /// </summary>
    [Fact]
    public void Task14_Test()
    {
        IEnumerable<Dept> studRes = Tasks.Task14().ToList();

        Assert.False(studRes == null);
        Assert.True(studRes.Count() == 2);

        Assert.Contains(studRes, x => x is { Dname: "Testing", Deptno: 2137 });
        Assert.True(studRes.Last().Dname == "Testing");
    }
}