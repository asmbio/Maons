namespace System.Collections.ObjectModel
{
    public static class ObservableCollectionEx
    {


        //public static void ConcurrentAdd<T>(this ObservableCollection<T> collection, T item)
        //{

        //    if (ConcurrentViewModelBase.Dispatcher != null)
        //    {
        //        ConcurrentViewModelBase.Dispatcher.Invoke(() => {

        //            collection.Add(item);
        //        });
        //    }
        //    else
        //    {
        //        collection.Add(item);
        //    }
        //}

        //public static bool ConcurrentRemove<T>(this ObservableCollection<T> collection, T item)
        //{

        //    if (ConcurrentViewModelBase.Dispatcher != null)
        //    {
        //        var result = ConcurrentViewModelBase.Dispatcher.Invoke<bool>(() => {

        //            return collection.Remove(item);
        //        });

        //        return result;
        //    }
        //    else
        //    {
        //        return collection.Remove(item);
        //    }
        //}

        //public static void ConcurrentClear<T>(this ObservableCollection<T> collection)
        //{

        //    if (ConcurrentViewModelBase.Dispatcher != null)
        //    {
        //        ConcurrentViewModelBase.Dispatcher.Invoke(() => {

        //            collection.Clear();
        //        });
        //    }
        //    else
        //    {
        //        collection.Clear();
        //    }
        //}

        //public static void ConcurrentRemoveAt<T>(this ObservableCollection<T> collection, int i)
        //{

        //    if (ConcurrentViewModelBase.Dispatcher != null)
        //    {
        //        ConcurrentViewModelBase.Dispatcher.Invoke(() => {

        //            collection.RemoveAt(i);
        //        });
        //    }
        //    else
        //    {
        //        collection.RemoveAt(i);
        //    }
        //}
    }
}
