

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Magic.MAUI
{
    public abstract class ODbContext<T,D> : ConcurrentViewModelBase where T : class where D:IDataProvider<T>
    {
        //private DbSet<T> dbset { get; set; }
        //public D db = Activator.CreateInstance<D>();

        protected static IDataProvider<T> provider = Activator.CreateInstance<D>();
        public ODbContext()
        {
            // db = Activator.CreateInstance<D>();
            //  var tType = typeof(T);
            //var property = db.GetType().GetProperty(tType.Name);
            //dbset = property.GetValue(db) as DbSet<T>;

          //  List
        }
        ~ODbContext()
        {
         //   db.Dispose();
        }
        //public ODbContext(DbSet<T> db)
        //{
        //   // dbset = db;
        //}

        public ObservableCollection<T> list = null;
        public ObservableCollection<T> List
        {
            get
            {
                //if (list == null)
                //{
                //  //  list = new ObservableCollection<T>();
                //    this.GetList();
                //}
                return list;
            }
            set { list = value; OnPropertyChanged("List"); }
        }
        // 搜索
        //[ObservableProperty]
        private T sModel = Activator.CreateInstance<T>();
        // 添加
       // [ObservableProperty]
        private T model = Activator.CreateInstance<T>();


        public T SModel
        {
            get { return sModel; }
            set
            {
                sModel = value;

            }
        }
        public T Model
        {
            get { return model; }
            set
            {
                if (value != null)
                {
                    model = (T)value.Copy();
                }
                RaisePropertyChanged("Model");
            }
        }
        private RelayCommand clearinputCmd;
        public RelayCommand ClearinputCmd
        {
            get
            {
                return clearinputCmd ?? (clearinputCmd = new RelayCommand(Clearinput));
            }
        }
        private void Clearinput()
        {

            foreach (var item in propertys)
            {
                var vul = item.GetValue(sModel, null);

                switch (item.PropertyType.ToString())
                {
                    case "System.String":


                        item.SetValue(sModel, null);


                        break;
                    case "System.DateTime":

                        //if (!string.IsNullOrEmpty((int)vul))
                        //{
                        //    source = source.Where(p => pro.GetValue(p, null) == vul);
                        //}
                        break;
                    case "System.Int32":

                        //if (!string.IsNullOrEmpty((int)vul))
                        //{
                        //    source = source.Where(p => pro.GetValue(p, null) == vul);
                        //}

                        break;
                    //case "System.Nullable`1[System.Int32]"
                    default:
                        //if (item)
                        //{

                        //}
                        item.SetValue(sModel, null);


                        //if (vul != null)
                        //{
                        //    source += $"and {pro.Name} = {vul} ";
                        //}

                        break;
                }
            }

        }

        private RelayCommand getListCmd;
        public RelayCommand GetListCmd
        {
            get
            {
                return getListCmd ?? (getListCmd = new RelayCommand(GetList));
            }
        }
        
        public  virtual void GetList()
        {
            try
            {
                var ret = ( provider.GetList(Getquery(), curPage, pageSize, stime, etime, orderby, orderkey, ""));
                List = new ObservableCollection<T>(ret.Result.list);
                list.CollectionChanged += List_CollectionChanged;
            }
            catch (Exception e)
            { 
                LogHelper.DefaultLogger.Error( "正在连接主网",e);
            }
        }

        private RelayCommand getListLikeCmd;
        public RelayCommand GetListLikeCmd
        {
            get
            {
                return getListLikeCmd ?? (getListLikeCmd = new RelayCommand(GetListLike));
            }
        }
        public async virtual void GetListLike()
        {
            try
            {
                var ret = (await provider.GetListLike(Getquery(), curPage, pageSize, stime, etime, orderby, orderkey, ""));
                this.list = new ObservableCollection<T>(ret.list);
                this.list.CollectionChanged += List_CollectionChanged;
            }
            catch (Exception e)
            {
                LogHelper.DefaultLogger.Error(e);
            }
        }
        protected async void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        //try
                        //{
                        //   // model.ID = db.getSequece("SEQ_BAS_PRODUCT_ID");
                        //    model.CREATED_TIME = System.DateTime.Now;
                        //    _context.BAS_PRODUCT.Add(model);
                        //    await _context.SaveChangesAsync();
                        //    _context.Operationrecord(model.CREATOR, "添加产品字典列表", "成功", "ID:" + model.PRODUCT_NAME);
                        //}
                        //catch (DbUpdateException e)
                        //{
                        //    db.Operationrecord(model.CREATOR, "添加产品字典列表", "失败", e.InnerException?.Message);
                        //    return BadRequest("该字段不能重复：ID,产品名称, 请检查数据");

                        //}
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        List<T> Models = new List<T>();
                        foreach (var item in e.OldItems)
                        {
                            //if ((T)item)
                            //{

                            //}
                            Models.Add((T)item);
                        }
                        await provider.Delete(Models);
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex1)
            {
                LogHelper.DefaultLogger.Error(ex1);
            }
           
        }

        private RelayCommand<T> insertCmd;
        public RelayCommand<T> InsertCmd
        {
            get
            {
                return insertCmd ?? (insertCmd = new RelayCommand<T>(Insert));
            }
        }
        public async void Insert(T oItem)
        {
            try
            {
                if (await provider.Insert(oItem) !=null)
                {
                    lock (_lock)
                    {
                        List.Add(oItem.Copy() as T);
                    }
             
                }
            }
            catch (Exception e)
            {
                LogHelper.DefaultLogger.Error(e);
            }


        }

        private RelayCommand<T> updateCmd;
        public RelayCommand<T> UpdateCmd
        {
            get
            {
                return updateCmd ?? (updateCmd = new RelayCommand<T>(Update));
            }
        }
        public void Update(T oItem)
        {
            try
            {
                provider.Update(oItem);
            }
            catch (Exception e)
            {
                LogHelper.DefaultLogger.Error(e);
            }
         
        }
        private RelayCommand<T> deleteCmd;
        public RelayCommand<T> DeleteCmd
        {
            get
            {
                return deleteCmd ?? (deleteCmd = new RelayCommand<T>(Delete));
            }
        }
        public async void Delete(T oItem)
        {
            try
            {
                if (await provider.Delete(oItem) !=null)
                {
                    lock (_lock)
                    {
                        List.Remove(oItem);
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.DefaultLogger.Error(e);
            }
         
        }
        //private ObservableCollection<T> GetList(Func<bool> predicate)
        //{
        //    predicate.


        //    throw new NotImplementedException();
        //}

      //  Type tType = typeof(T);
        PropertyInfo[] propertys = typeof(T).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

        public Dictionary<string, object> Getquery() 
        {
            Dictionary<string, object> query = new Dictionary<string, object>();
            foreach (var pro in propertys)
            {

                var vul = pro.GetValue(sModel, null);

                switch (pro.PropertyType.ToString())
                {
                    case "System.String":

                        if ((string)vul != null)
                        {
                            query.Add(pro.Name, vul);
                        }
                        break;
                    case "System.DateTime":

                        //if (!string.IsNullOrEmpty((int)vul))
                        //{
                        //    source = source.Where(p => pro.GetValue(p, null) == vul);
                        //}
                        break;
                    case "System.Int32":
                        //if (!string.IsNullOrEmpty((int)vul))
                        //{
                        //    source = source.Where(p => pro.GetValue(p, null) == vul);
                        //}
                        break;
                    default:

                        if (vul != null)
                        {
                            query.Add(pro.Name, vul);
                        }

                        break;
                }

            }
            return query;
        }
        //public ObservableCollection<T> GetOCList(T m) 
        //{
        //    string source = $"select * from {tType.Name} ";
        //    var timepro = tType.GetProperty(timekey);

        //    // source = source.OrderByDescending(p => timepro.GetValue(p));

        //    string swherestr = "";
        //    if (Stime!=null)
        //    {
        //         swherestr += $"{timepro.Name} >= '{Stime.Value.ToString("yyyy-MM-dd HH:mm:ss")}' and ";
        //    }
        //    if (Etime!=null)
        //    {
        //        swherestr += $" {timepro.Name} < '{Etime.Value.ToString("yyyy-MM-dd HH:mm:ss")}' and ";
        //    }
            


            
        //    //  var property = tType.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p=> property_r.FirstOrDefault(t=>t.Name == p.Name)==null);
        //    //  property.RemoveRange(property_r);


        //    foreach (var pro in propertys)
        //    {

        //        var vul = pro.GetValue(m, null);

        //        switch (pro.PropertyType.ToString())
        //        {
        //            case "System.String":

        //                if ((string)vul!=null)
        //                {
        //                    swherestr += $"{pro.Name} = '{vul}' and ";
        //                }

        //                break;
        //            case "System.DateTime":

        //                //if (!string.IsNullOrEmpty((int)vul))
        //                //{
        //                //    source = source.Where(p => pro.GetValue(p, null) == vul);
        //                //}
        //                break;
        //            case "System.Int32":
        //                //if (!string.IsNullOrEmpty((int)vul))
        //                //{
        //                //    source = source.Where(p => pro.GetValue(p, null) == vul);
        //                //}
        //                break;
        //            default:

        //                if (vul != null)
        //                {
        //                    swherestr += $"{pro.Name} = {vul} and ";
        //                }

        //                break;
        //        }

        //    }
        //    if (!string.IsNullOrEmpty(swherestr))
        //    {
                
        //        source += $" where {swherestr.Remove(swherestr.Length - 4)}";
        //    }
        //    source += $" order by {orderkey} desc";

        //    var ret = dbset.FromSqlRaw(source);
        //    //dbset.AsNoTracking();
        //    // source.Load();
        //    //List.Clear();
        //    //foreach (var item in ret)
        //    //{
        //    //    List.Add(item);
        //    //}
        //  //  var ret1 = new { x = 1, r = 2 };
        //    return new ObservableCollection<T>(ret.AsEnumerable());
        //}


        private RelayCommand<IList<T>> outputCmd;
        public RelayCommand<IList<T>> OutputCmd
        {
            get
            {
                return outputCmd ?? (outputCmd = new RelayCommand<IList<T>>(Output));
            }
        }

        protected void Output(IList<T> list)
        {
            try
            {
                //var tType = typeof(T);
                //var propertys = tType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p=>p.Name).ToArray();

                //SaveFileDialog folderBrowserDialog1 = new SaveFileDialog();
                //folderBrowserDialog1.DefaultExt = "*.xlsx";
                //folderBrowserDialog1.FileName = $"{tType.Name}-{DateTime.Now.ToString("yyyyMMdd-hh-mm-ss")}.xlsx";
                //folderBrowserDialog1.Title = "请选择导出文件";

                //folderBrowserDialog1.Filter = "Excel|*.xlsx";

                //var result = folderBrowserDialog1.ShowDialog();

                
                //if (result ==  DialogResult.OK)
                //{
                //    FileInfo file = new FileInfo(folderBrowserDialog1.FileName);

                //    //ObjectToExcel<T> excle = new ObjectToExcel<T>(
                //    //    list,
                //    //   propertys);
                //    //excle.CreatePackage(file.FullName);
                //}       
            }
            catch (System.Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
            }
        }


        #region page

        private DateTime? stime = null;

        private DateTime? etime = null;
  
        private string orderkey = "CREATED_TIME";

        private string orderby = "desc";
        public string Orderby
        {
            get { return orderby; }
            set
            {
                orderby = value;
                RaisePropertyChanged("Orderby");
            }
        }
        public string Orderkey
        {
            get { return orderkey; }
            set
            {
                orderkey = value;
                RaisePropertyChanged("Orderkey");
            }
        }
        public DateTime? Stime
        {
            get { return stime; }
            set
            {
                stime = value;
                RaisePropertyChanged("Stime");
            }
        }
        public DateTime? Etime
        {
            get { return etime; }
            set
            {
                etime = value;
                RaisePropertyChanged("Etime");
            }
        }

        private int recordCount;

        private int pageCount;
   
        private int curPage;

        protected int pageSize = 10;

        public int RecordCount
        {
            get
            {
                //this.GetCount();
                return recordCount;
            }
            set
            {
                recordCount = value;
                PageCount = recordCount / PageSize + 1;
            }
        }

        public int PageCount
        {
            get { return pageCount; }
            set
            {
                pageCount = value;
                RaisePropertyChanged("PageCount");
            }
        }


        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = value;
                RaisePropertyChanged("PageSize");
            }
        }
        public int CurPage
        {
            get { return curPage; }
            set
            {
                if (value > 0 && value <= pageCount)
                {
                    curPage = value;
                }
                RaisePropertyChanged("CurPage");
            }
        }
        #endregion

    }
}
