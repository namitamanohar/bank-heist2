using System;
using System.Collections.Generic;
using System.Linq;

namespace BankHeist2 {
    class Program {
        static void Main (string[] args) {
            var Rolodex = new List<IRobber> ();

            var memberSpeciality = "";
            var newMemberName = "";
            var percentageCut = 0;
            var skillLevel = 0;

            var bank1 = new Bank ();
            bank1.AlarmScore = new Random ().Next (0, 100);
            bank1.VaultScore = new Random ().Next (0, 100);
            bank1.SecurityGuardScore = new Random ().Next (0, 100);
            bank1.CashOnHand = new Random ().Next (50000, 1000001);

            var bankScores = new Dictionary<string, int> ();

            bankScores.Add ("Alarm Score", bank1.AlarmScore);
            bankScores.Add ("Vault Score", bank1.VaultScore);
            bankScores.Add ("Security Guard Score", bank1.SecurityGuardScore);

            var orderedScores = bankScores.OrderBy (score => score.Value);
            var highestValue = orderedScores.Last ();
            Console.WriteLine ($"The most secure is {highestValue.Key}:{highestValue.Value}");

            var lowestValue = orderedScores.First ();
            Console.WriteLine ($"The least secure is {lowestValue.Key}:{lowestValue.Value}");

            // recon report 
            // most secure system 

            var holden = new Hacker ();
            holden.name = "Holden";
            holden.PercentageCut = 80;
            holden.SkillLevel = 24;

            var audrey = new Hacker ();
            audrey.name = "Audrey";
            audrey.PercentageCut = 25;
            audrey.SkillLevel = 43;

            var kevin = new LockSpecialist ();
            kevin.name = "Kevin";
            kevin.PercentageCut = 12;
            kevin.SkillLevel = 14;

            var william = new LockSpecialist ();
            william.name = "William";
            william.PercentageCut = 12;
            william.SkillLevel = 45;

            var willy = new Muscle ();
            willy.name = "Willy";
            willy.PercentageCut = 3;
            willy.SkillLevel = 34;

            var garrett = new Muscle ();
            garrett.name = "Garrett";
            garrett.PercentageCut = 12;
            garrett.SkillLevel = 54;

            Rolodex.Add (holden);
            Rolodex.Add (audrey);
            Rolodex.Add (kevin);
            Rolodex.Add (william);
            Rolodex.Add (willy);
            Rolodex.Add (garrett);

            Console.WriteLine ($"Current number of members {Rolodex.Count}");
            while (true) {
                Console.WriteLine ("Enter the name of your new member");
                newMemberName = Console.ReadLine ();
                if (string.IsNullOrEmpty (newMemberName)) {

                    break;

                } else {

                    while (true) {

                        Console.WriteLine ("Pick one of the options Hacker-disables alarms, Muscle -disarms guards, Lock Specialist-cracks vault");
                        memberSpeciality = Console.ReadLine ();

                        try {
                            if (memberSpeciality == "Hacker" || memberSpeciality == "Muscle" || memberSpeciality == "Lock Specialist")
                                break;
                        } catch {
                            Console.WriteLine ("Pick a Hacker, Lock Specialist, or Muscle");
                        }
                    }

                    Console.WriteLine ("Enter the member's skill level between 1 and 100");
                    while (true) {
                        var skill = Console.ReadLine ();

                        try {
                            skillLevel = int.Parse (skill);
                            if (skillLevel >= 1 && skillLevel <= 100) {
                                break;
                            } else {
                                Console.WriteLine ("Enter a number between 1 and 100");
                            }
                        } catch {
                            Console.WriteLine ("Enter a VALID number");
                        }
                    }

                    Console.WriteLine ("Enter the percentage cut the crew member demands for each mission");
                    while (true) {
                        var percent = Console.ReadLine ();
                        try {
                            percentageCut = int.Parse (percent);
                            if (percentageCut >= 1 && percentageCut <= 50) {
                                break;
                            } else {
                                Console.WriteLine ("Enter a percent between 1 and 50");
                            }
                        } catch {
                            Console.WriteLine ("Enter a valid number");
                        }

                    }

                    if (memberSpeciality == "Hacker") {
                        var newHacker = new Hacker ();
                        newHacker.name = newMemberName;
                        newHacker.SkillLevel = skillLevel;
                        newHacker.PercentageCut = percentageCut;
                        Rolodex.Add (newHacker);
                    } else if (memberSpeciality == "Muscle") {
                        var newMuscle = new Muscle ();
                        newMuscle.name = newMemberName;
                        newMuscle.SkillLevel = skillLevel;
                        newMuscle.PercentageCut = percentageCut;
                        Rolodex.Add (newMuscle);
                    } else if (memberSpeciality == "Lock Specialist") {
                        var newLock = new LockSpecialist ();
                        newLock.name = newMemberName;
                        newLock.SkillLevel = skillLevel;
                        newLock.PercentageCut = percentageCut;
                        Rolodex.Add (newLock);
                    } else {
                        Console.WriteLine ("You did not enter a correct speciality");
                    }
                }

            }

            // rolodex report 
            foreach (var item in Rolodex) {
                Console.WriteLine ($" {Rolodex.IndexOf(item)} {item.ToString ()}");
            }

            var crew = new List<IRobber> ();

            var percentageLeft = 100;
            // 100 - percentage total >= PercentageCut
            while (true) {
                Console.WriteLine ("Enter the index of who you want in your crew");
                var index = Console.ReadLine ();

                if (string.IsNullOrEmpty (index)) {

                    break;
                } else {
                    try {
                        var robberIndex = int.Parse (index);

                        if (robberIndex < Rolodex.Count || robberIndex >= 0) {
                            crew.Add (Rolodex[robberIndex]);
                            Rolodex.Remove (Rolodex[robberIndex]);

                            percentageLeft -= crew[robberIndex].PercentageCut;
                            Console.WriteLine ($"percent left {percentageLeft}");

                            foreach (var item in Rolodex) {
                                if (percentageLeft >= item.PercentageCut) {

                                    Console.WriteLine ($" {Rolodex.IndexOf(item)} {item.ToString ()}");

                                }
                            }

                        } else {
                            Console.WriteLine ("Enter an the correct index value");
                        }
                    } catch {
                        Console.WriteLine ("Enter a valid index number");
                    }
                }
            }

            // print out the rolodex but remove items that are in the crew

            // foreach (var item in Rolodex) {
            //     if (percentageLeft >= item.PercentageCut) {

            //         Console.WriteLine ($" {Rolodex.IndexOf(item)} {item.ToString ()}");

            //     }
            // }
        }
    }
}