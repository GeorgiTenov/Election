
using ChooseOptions;
using PersonLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Elections
{
   public static class VoteManager
    {
        private static List<Person> _people = new List<Person>();

        private static string _sqlConnection = @"Data Source=LAPTOP-ET5RGIG4\SQLEXPRESS01;Initial Catalog=ElectionDatabase;Integrated Security=True";

        private static int _votedForIvailoIvailov;

        private static int _votedForDimiturDimitrov;

        private static int _votedForNikolaNikolov;

        private static int _votedForPeturPetrov;

        private static int _votedForGenadiGenadiev;

        private static int _votedForKostadinKostadinov;

        private static int _votedForRadoslavRadoslavov;

        private static SqlConnection _connection = new SqlConnection(_sqlConnection);

        public static void ShowVotes()
        {
            foreach(var person in _people)
            {
                if (person.IsAlreadyVoted())
                {
                    Console.WriteLine("RESULTS-------------------------" + "\n");
                    
                    Console.WriteLine(person.FirstName +" "+person.LastName +" Voted For "+person.VotedFor());
                }
               
            }
        }
        public static bool AddPerson(Person person)
        {
            if (person.CanVote())
            {
                foreach(var p in _people)
                {
                    if (!person.Id.Equals(p.Id))
                    {
                        _people.Add(person);
                        return true;
                    }

                    
                }
                if(_people.Count <= 0)
                {
                    _people.Add(person);
                    return true;
                }
               
            }
            return false;
        }

        public static bool AddToDatabase()
        {
            try
            {
                
                _connection.Open();
                foreach (var person in _people)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO ElectionTable Values('"+person.FirstName+"'," +
                        "'"+person.LastName+"'," +
                        "'"+person.Age+"'," +
                        "'"+person.VotedFor()+"')",_connection);

                    cmd.ExecuteNonQuery();
                    
                }
                _connection.Close();
                return true;
                
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
           
        }
        public static void ShowAllVotesFromDatabase()
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM ElectionTable",_connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetValue(0) +"\n");

                    Console.WriteLine(reader.GetValue(1) + "\n");

                    Console.WriteLine(reader.GetValue(2) + "\n");

                    Console.WriteLine(reader.GetValue(3) + "\n");
                    
                }
                reader.Close();

                _connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static void ShowVotesCount()
        {
            foreach(var person in _people)
            {
                switch (person.VotedFor())
                {
                    case VoteOptions.IvailoIvailov:
                        {
                            _votedForIvailoIvailov++;
                            break;
                        }

                    case VoteOptions.DimiturDimitrov:
                        {
                            _votedForDimiturDimitrov++;
                            break;
                        }

                    case VoteOptions.NikolaNikolov:
                        {
                            _votedForNikolaNikolov++;
                            break;
                        }
                    case VoteOptions.PeturPetrov:
                        {
                            _votedForPeturPetrov++;
                            break;
                        }
                    case VoteOptions.GenadiGenadiev:
                        {
                            _votedForGenadiGenadiev++;
                            break;
                        }
                    case VoteOptions.KostadinKostadinov:
                        {
                            _votedForKostadinKostadinov++;
                            break;
                        }
                    case VoteOptions.RadoslavRadoslavov:
                        {
                            _votedForRadoslavRadoslavov++;
                            break;
                        }
                }
            }
            Console.WriteLine("-------------------------------------------------------------------------------"+"\n");

            Console.WriteLine("Voted for Ivailo Ivailov: "+_votedForIvailoIvailov +"\n");

            Console.WriteLine("Voted for Dimitur Dimitrov: " + _votedForDimiturDimitrov + "\n");

            Console.WriteLine("Voted for Nikola Nikolov: " + _votedForNikolaNikolov + "\n");

            Console.WriteLine("Voted for Petur Petrov: " + _votedForPeturPetrov + "\n");

            Console.WriteLine("Voted for Genadi Genadiev: " + _votedForGenadiGenadiev + "\n");

            Console.WriteLine("Voted for Kostadin Kostadinov: " + _votedForKostadinKostadinov + "\n");

            Console.WriteLine("Voted for Radoslav Radoslavov: " + _votedForRadoslavRadoslavov + "\n");

            Console.WriteLine("-------------------------------------------------------------------------------" + "\n");
        }

        public static bool DeleteAllData()
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ElectionTable",_connection);
            try
            {
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
            
        }
    }
}
