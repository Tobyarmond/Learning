using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;


namespace Lambdas
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            foreach (int i in L.evens)
            {
                Console.WriteLine("Even = " + i);
                //() => Console.WriteLine(L.byfour);
            }
            L.SayBlah();

            List<GameObject> gameObjects = new List<GameObject>
            {
                new Ship {ID = 1, X = 0, Y = 1, Health = 35, MaxHealth = 100, PlayerID = 1},
                new Ship {ID = 2, X = 4, Y = 3, Health = 76, MaxHealth = 100, PlayerID = 1},
                new Ship {ID = 3, X = 7, Y = 2, Health = 65, MaxHealth = 100, PlayerID = 2},
                new Ship {ID = 4, X = 7, Y = 2, Health = 100, MaxHealth = 100, PlayerID = 2},
                new Ship {ID = 5, X = 7, Y = 2, Health = 100, MaxHealth = 100, PlayerID = 1}
            };

            List<Player> Players = new List<Player>();
            Players.Add(new Player{PlayerID = 1,TeamColour = Player.Colours.Red, Username = "Bob"});
            Players.Add(new Player{PlayerID = 2,TeamColour = Player.Colours.Blue, Username = "Fred"});

            // o in this example is a range variable, it is like the variable you assign in foreach loops
            // you can also specify what type the variable would be: from Ship s in gameObjects
            IEnumerable<GameObject> allObjects = from o in gameObjects
                select o;

            IEnumerable<string> healthList = from o in allObjects
                select o.Health + "/" + o.MaxHealth;

            IEnumerable<GameObject> aliveObjects = from o in gameObjects
                where o.Health > 0
                select o;
            
            // NOTE:
            // Multiple from clauses in notes
            
            // Let clauses allow you to create new range variables (percentHealth) normally for the purpose of using it
            // later within the query, it also can be used to simply make the code more readable.
            IEnumerable<string> statuses = from o in gameObjects
                let percentHealth = Math.Round(o.Health / o.MaxHealth * 100)
                select $"{o.ID} is at {percentHealth}";

            // The join clause allows for two lists to be made into one. During a join clause you cannot use the "==" operator
            // instead you use the equals keyword which translates to "==" this means that if you have overloaded operators
            // you can still use your overloaded versions.
            
            // The placement of the two sides of the equals statement are crucial, the left side MUST reference an earlier
            // range variable while the right side can only reference the new variable, in this example p
            var objectColours = from o in gameObjects
                join p in Players on o.PlayerID equals p.PlayerID
                select new {o.ID, p.TeamColour};
            // This is what database people call an inner join. In order for objects to show up in the resulting collection
            // there must be a match for it found in the other collection.

            // Orderby clauses sort collections into new collections. By default it sorts into a ascending order but this
            // behaviour can be reversed through the use of the descending or ascending keywords like below
            IEnumerable<Player> sortedPlayers = from p in Players
                orderby p.Username descending 
                select p;
            
            // You can also perform multi level sorts
            IEnumerable<GameObject> multiSortedObjects = from o in gameObjects
                orderby o.PlayerID ascending, o.MaxHealth descending
                select o;
            // In this example the list will sort the list by PlayerID from lowest to highest first, then it will sort
            // by Maxhealth from highest to lowest.
            
            // Group Clauses are caluses that can end a query statement. It allows you to bundle up items into collections
            // based off some criteria you supply, for example this will sort the objects into groups based on playerID
            IEnumerable<IGrouping<int, GameObject>> groups = from o in gameObjects
                group o by o.PlayerID;
            // To use the group command the collection that the results are being sent to must conform to the IGrouping
            // interface which is like so: IGrouping<TKey,TElement> You can simply use a var if you are lazy and let the
            // compiler deal with it. !! Unverified !! the by statement indicates which variable will be the Key  
            
            // You will not get empty groups from simple group statement 
            
            // The code below prints out what the resulting groups look like
            foreach (IGrouping<int, GameObject> group in groups)
            {
                Console.WriteLine(group.Key);
                foreach (GameObject o in group)
                {
                    Console.WriteLine("    " + o.ID);
                }
            }
            
            // Even though queries end when they reach either a select or group, they can be continued using an into clause
            // an into statement turns your group/select into a new range variable available for mre querys.
            
            // This select new {blah blah} seems to be because the return type is not explicitly stated i.e using var
            var objectCountPerPlayer = from o in gameObjects
                group o by o.PlayerID
                into Playergroup
                select new {ID = Playergroup.Key, count = Playergroup.Count()};
            
            // an into clause can follow either a group or select statemtent.
           
            // Group join clauses, a normal join clause will take two collections and pair up elemnents that belong to each -
            // other. After the join clause you can access the matching object from each collection together at the same
            // time. One caveat of this is that if an object in either sequence didn't match something in the other you
            // will never see this object as a result. a group join is a little different in this regard.
            
            // Similar to a join a group join operates on two collections and objects are matched together but with a
            // group join all the items in the second group are are bundled together into a single group that belongs to
            // a single item within the first collection, this applies even where there were no matches (which creates
            // an empty group). 
            
            // With a normal join you have to work with two objects that matched. After a group join you will always have 
            // the object from the first collection and paired with it will an IEnumerable of items that belong
            // to it from the second list (even if there were none, creating an empty group)

            var playerObjects = from p in Players
                join o in gameObjects on p.PlayerID equals o.PlayerID into objectsOwnedByPlayer
                select new {Player = p, Objects = objectsOwnedByPlayer};

            foreach (var objects in playerObjects)
            {
                Console.WriteLine(objects.Player.Username + " has the following objects");
                foreach (GameObject o in objects.Objects)
                {
                    Console.WriteLine($"    {o.ID} {o.Health}/{o.MaxHealth}");
                }
            }
            
            // To perform a group join, as you can see in the example you use a normal join clause and immediately follow
            // up with an into clause 
            
            // SYNTAX:
            // In addition to the style of queries that we have been working above there is an alternative syntax available
            // which is called method call syntax, unsurprisingly this takes the form of a method call rather than the
            // keywords we have been using above. Further details can be found pg 243 Players Guide
            
            // The following two examples are the same with the two different syntaxes, The invocation style has to make
            // heavy use of lambdas.

            IEnumerable<int> aliveIDs1 = from o in gameObjects
                where o.Health > 0
                select o.ID;

            IEnumerable<int> aliveIDs2 = gameObjects.Where(o => o.Health > 0).Select(o => o.ID);
            
            // so you can achieve slightly better code brevity at the possible cost of readability.
            
            // FINAL NOTE:
            // queries are lazy when possible, this means that they will only evaluate the bare minimum to get a result,
            // this means if you have a foreach loop that is looking through an IEnumerable like all of those above, it
            // will evaluate the query get an answer then run the foreach stuff, then go back find next one, run foreach
            // code. In these situations use the ToList() or ToArray() methods to force the query to run all the way through
            // then use these collections for your foreach instead.

            // TRY IT OUT
            
            // This doesn't actually do exactly what both tryitouts wanted but was what I interpereted it as meaning when
            // I first read it.
            var fullHealthObjects = from gameobj in gameObjects
                where gameobj.Health == gameobj.MaxHealth
                group gameobj by gameobj.PlayerID
                into idlist
                from i in idlist
                // don't need to use key and value, it appears as though it has made a dictionary style thing
                select new {Key = i.ID, value = i.Health};

            PrintTryitOut();

            void PrintTryitOut()
            {
                foreach (var VARIABLE in fullHealthObjects)
                {
                    Console.WriteLine($"Key is {VARIABLE.Key}\tvalue is {VARIABLE.value}");
                }   
            }

            IEnumerable<GameObject> bob = findAliveObjects();
            IEnumerable<GameObject> findAliveObjects()
            {
                ArrayList answer = new ArrayList(); 
                foreach (GameObject gobj in gameObjects)
                {
                    if (gobj.Health > 0)
                    {
                        // The yield return command will return the items in a list Theoretically a yield return
                        // statement can last forever
                        yield return gobj;
                    }
                }
            }

            foreach (var VARIABLE in bob)
            {
                Console.WriteLine($"ID={VARIABLE.ID} Heatlh={VARIABLE.Health} Player={VARIABLE.PlayerID}");
            }
        }
    }
}