namespace c_lab03{

    public class Author : Person{

        public string Nationality {get;set;}
        public Author():base()
        {
            Nationality="";
        }
        public Author(string firstName, string lastName, string nationality):base(firstName,lastName)
        {
            Nationality=nationality;
        }
        public override string ToString(){
            return $"Autor: {base.ToString()} / {Nationality}\n";
        }
    }

}