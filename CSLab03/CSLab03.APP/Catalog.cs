using System.Linq.Expressions;

namespace c_lab03{
    public class Catalog : IMusicalInstrument {
        public IList<Item> Items {get;set; }
        public string ThematicDepartment {get;set;}
        public Catalog(IList<Item> items) {
            Items=items;
            ThematicDepartment="";
        }
        public Catalog(string thematicDepartment, IList<Item> items) {
            Items=items;
            ThematicDepartment=thematicDepartment;
        }
        public void AddItem(Item item){
            Items.Add(item);
        }
        public override string ToString () {
            string str = $"{ThematicDepartment}:\n";
            foreach (Item item in Items){
                str+=item.ToString();
                str+='\n';
            }
            return str;
        }
        public void ShowAllItems() {
            Console.WriteLine(this.ToString());
        }
        public Item FindItem(Expression<Func<Item, bool>> expression) {
            return Items.FirstOrDefault(expression.Compile());
        }
        public Item FindItemBy(int id)
        {
            foreach (Item item in Items)
            {
                if (item.Id.Equals(id)) 
                    return item;
            }
            return null;
        }
        public Item FindItemBy(string title) 
        {
            foreach(Item item in Items)
            {
                if (item.Title.Equals(title)) 
                    return item;
            }
            return null;
        }
    }
}