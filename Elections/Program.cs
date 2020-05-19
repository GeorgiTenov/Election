using ChooseOptions;
using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elections
{
    class Program
    {
        static void Main(string[] args)
        {
            Person myName = new Person("Violeta","Markova","9504023501",24,false);
            myName.Vote(VoteOptions.IvailoIvailov);

            Person myl = new Person("Ivan", "Georgiev", "9702015690", 22, false);
            myName.Vote(VoteOptions.IvailoIvailov);

            Person malinka = new Person("Malinka", "Teodorova", "9901023421", 20, true);
            malinka.Vote(VoteOptions.RadoslavRadoslavov);

            VoteManager.AddPerson(myl);
            VoteManager.AddPerson(myName);
            VoteManager.AddPerson(malinka);
            VoteManager.ShowVotes();
            VoteManager.AddToDatabase();
            VoteManager.ShowVotesCount();
            //VoteManager.DeleteAllData();

            VoteManager.ShowAllVotesFromDatabase();
          
            Console.ReadKey();
        }
    }
}
