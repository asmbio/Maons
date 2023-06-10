using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maons.Controls
{
    public static class MaonsNavigationEx
    {
        public static void Push(this ContentView content,ContentView view)
        {
            Element cw = content;
            while (!(cw.Parent is MaonsNavigation) )
            {
                cw = cw.Parent;
            }

            var na = cw.Parent as MaonsNavigation;
            na.Push(view);
        }


        public static View Pop(this ContentView content)
        {
            Element cw = content;
            while (!(cw.Parent is MaonsNavigation))
            {
                cw = cw.Parent;
            }

            var na = cw.Parent as MaonsNavigation;
          return  na.Pop();
        }
    }


}
