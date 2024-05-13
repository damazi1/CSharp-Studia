using c_lab03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class Library
    {
        public string Address { get; set; }
        public IList<Librarian> Libraians { get; set; }
        public IList<Catalog> Catalogs { get; set; }
        public Library(string address, IList<Librarian> librarians, IList<Catalog> catalogs) {
            Address = address;
            Libraians = librarians;
            Catalogs = catalogs;
        }
        public void AddLibrarian(Librarian librarian)
        {
            Libraians.Add(librarian);
        }
        public void ShowAllLibrarians()
        {
            foreach (Librarian librarian in Libraians)
            {
                Console.WriteLine(librarian.ToString());
            }
        }
        public void AddCatalog(Catalog catalog)
        {
            Catalogs.Add(catalog);
        }
        public void AddItem(Item item, string thematicDepartment)
        {
            foreach (Catalog catalog in Catalogs)
            {
                if (catalog.ThematicDepartment == thematicDepartment)
                {
                    catalog.AddItem(item);
                    return;
                }
            }
        }
        public void ShowAllItems()
        {
            foreach (Catalog catalog in Catalogs)
            {
                Console.WriteLine(catalog.ToString());
            }
        }
        public Item FindItemBy(int id)
        {
            foreach (Catalog catalog in Catalogs)
            {
                foreach (Item item in catalog.Items)
                {
                    if(item.Id == id) return item;
                }
            }
            return null;
        }
        public Item FindItemBy(string title)
        {
            foreach (Catalog catalog in Catalogs)
            {
                foreach (Item item in catalog.Items)
                {
                    if (item.Title == title) return item;
                }
            }
            return null;
        }
        public Item FindItem(Expression<Func<Item, bool>> expression)
        {
            foreach (Catalog catalog in Catalogs)
            {
                return catalog.Items.FirstOrDefault(expression.Compile());
            }
            return null;
        }
        public override string ToString()
        {
            string str = $"Biblioteka: {Address}\n";
            foreach(Librarian librarian in Libraians)
            {
                str += librarian.ToString()+'\n';
            
            }
            foreach(Catalog catalog in Catalogs)
            {
                str += catalog.ToString()+'\n';
            }
            return str;
        }
    }
}
