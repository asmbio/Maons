using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Magic.MAUI
{
    public interface IDataProvider<T>
    {
       // PropertyInfo[] propertys = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
        Task<T> GetModel(int id);
        Task<T> Delete(T oItem );

        Task<T> Delete(int id );
        Task<int> Delete(IEnumerable<T> list);

        Task<(int total, IEnumerable<T> list, IEnumerable<IGrouping<object, T>> group)> GetList(Dictionary<string,object> query, int pageNo, int pageSize, System.DateTime? stime, DateTime? etime, string orderby, string orderKey, string groupkey);
        Task<(int total, IEnumerable<T> list,IEnumerable< IGrouping<object,T>> group)> GetListLike(Dictionary<string, object> query, int pageNo, int pageSize, System.DateTime? stime, DateTime? etime, string orderby, string orderKey, string groupkey);

        //Task<IEnumerable<T>> ReInput(IEnumerable<T> list);
        Task<IEnumerable<T>> Input(IEnumerable<T> list);

        Task<IEnumerable<T>> OverrideImporting(IEnumerable<T> list);
        Task<T> Insert(T oItem);
        Task<T> Update(T oItem);
}
}
