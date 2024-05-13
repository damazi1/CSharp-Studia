namespace c_lab03 {
    public class Book : Item{
        public int PageCount {get;set;}
        public IList<Author> Authors {get;set;}
        public Book(string title,int id,string publisher,DateTime dateOfIssue, int pageCount,IList<Author> authors):base(title,id,publisher,dateOfIssue){
            PageCount=pageCount;
            Authors=authors;
        }
        public override string ToString(){
            string str = base.ToString();
            str+=$"\nIlosc stron: {PageCount}\n";
            foreach (Author author in Authors)
            {
                str+=author.ToString();
            }
            return str;
        }
        public override string GenerateBarCode() {
            return $"Barcode: BOOK - {this.Id}";
        }
        public void AddAuthor(Author author){
            Authors.Add(author);
        }

    }

}