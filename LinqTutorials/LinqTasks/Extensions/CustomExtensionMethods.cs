using LinqTasks.Models;

namespace LinqTasks.Extensions;

public static class CustomExtensionMethods
{
    ///     Metoda powinna zwrócić tylko tych pracowników, którzy mają min. 1 bezpośredniego podwładnego.
    ///     Pracownicy powinny w ramach kolekcji być posortowani po nazwisku (rosnąco) i pensji (malejąco).
    public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
    {
        var temp = emps
            .Select(x => x.Mgr.Empno).ToList();
        return emps
            .Where(x => temp.Contains(x.Empno))
            .OrderBy(x => x.Ename)
            .ThenByDescending(x => x.Salary);
    }
}