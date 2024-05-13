﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class FootballPlayer : Player
    {
            public FootballPlayer(string firstName, string lastName, DateTime dateOfBirth, string position, string club, int scoredGoals) : base(firstName, lastName, dateOfBirth, position, club, scoredGoals) { }

            public override void ScoreGoal()
            {
                Console.WriteLine("Zawodnik Piłki nożnej strzelił Gola !!!");
                base.ScoreGoal();
            }
    }
}