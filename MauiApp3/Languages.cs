using Maons.Language;
using Maons;
using Microsoft.Maui.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp3;

namespace Maons
{
    public class Languages
    {

        public List<string> L2 =  new List<string>{ "中文" ,"English"};
        public Dictionary<string, string> Lans = new Dictionary<string, string>{ 
            { "中文", @"Resources/Language/zh-cn.xaml" },
            { "English", @"Resources/Language/en-us.xaml" }

        };
        public object InitLan()
        {
            String lang = System.Globalization.CultureInfo.CurrentCulture.Name;

            if (lang.StartsWith("zh-"))
            {
                SwitchLan("中文");


            }
            else
            {
                SwitchLan("English");
            }
            //switch (lang)
            //{
                
            //    case "en-US":
            //        SwitchLan("English");
            //        break;
            //    default:
            //        SwitchLan("中文");
            //        break;
            //}
            //GetSystemDefaultLangID(lang)
            return 0;
        }
        public ResourceDictionary SwitchLan(string lang)
        {
            //List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            //foreach (ResourceDictionary dictionary in App.Current.Resources.MergedDictionaries)
            //{
            //    dictionaryList.Add(dictionary);
            //}
            string requestedCulture = Lans[lang];
            ResourceDictionary resourceDictionary = App.Current.Resources.MergedDictionaries.FirstOrDefault(d => d.Source.OriginalString.Contains(requestedCulture));

          //  App.Current.Resources.MergedDictionaries.Remove(resourceDictionary);


             App.Current.Resources.MergedDictionaries.Add(resourceDictionary);



            //App.Current.Resources
            //ResourceDictionary dict = new ResourceDictionary();        
            //dict.Source = new Uri(Lans[lang], UriKind.Relative);

            ////dict[]
            //App.Current.Resources.MergedDictionaries.Add(dict);
            return null;
        }
    }
}
