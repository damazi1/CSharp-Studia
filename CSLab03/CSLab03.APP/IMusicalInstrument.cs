using c_lab03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace c_lab03
{
    internal interface IMusicalInstrument
    {
        void ShowAllItems();
        Item FindItemBy(int id);
        Item FindItemBy(string name);
        Item FindItem(Expression<Func<Item, bool>> expression);
    }
}
