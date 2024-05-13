namespace lab02 {

    public class Player : Person{
        private string _position;
        private string _club;
        private int _scoredGoals;

        public string Position {get{return _position;}set {_position=value;}}
        public string Club {get{return _club;}set {_club=value;}}
        public int ScoredGoals{get{return _scoredGoals;}set {_scoredGoals=value;}}

        public Player():base(){
            _position="";
            _club="";
            _scoredGoals=0;
        }
        public Player(string firstName,string lastName,DateTime dateOfBirth,string position,string club, int scoredGoeals):base(firstName,lastName,dateOfBirth){
            _position=position;
            _club=club;
            _scoredGoals=scoredGoeals;
        }

        public override string ToString(){
            return base.ToString()+"\n"+$"pozycja: {_position} | klub: {_club} | Strzelone Bramki: {_scoredGoals}";
        }
        public virtual void ScoreGoal(){
            _scoredGoals++;
        }

    }
}