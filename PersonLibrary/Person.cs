
using ChooseOptions;
using System;

namespace PersonLibrary
{
   public  class Person
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Id { get; private set; }

        public byte Age { get; private set; }

        private VoteOptions _votedFor; 


        public bool HasCriminalRecords { get; private set; }

        private bool _alreadyVoted;

        public Person(string firstName,
                      string lastName,
                      string id,
                      byte age,
                      bool hasCriminalRecords)
        {
            this.FirstName = firstName;

            this.LastName = lastName;

            this.Id = id;

            this.Age = age;

            this.HasCriminalRecords = hasCriminalRecords;
        }

        public bool CanVote()
        {
            if(!this.HasCriminalRecords && this.Age >= 18)
            {
                return true;
            }
            return false;
        }

        public bool Vote(VoteOptions voteOption)
        {
            if (!this.HasCriminalRecords && this.Age >= 18)
            {
                this._votedFor = voteOption;
                this._alreadyVoted = true;
                Console.WriteLine("You have voted for "+voteOption+"\n");
            }
            return this._alreadyVoted;
        }

        public bool IsAlreadyVoted()
        {
            return this._alreadyVoted;
        }

        public VoteOptions VotedFor()
        {
            return this._votedFor;
        }

       
    }
}
