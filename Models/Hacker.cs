using System;
namespace BankHeist2 {
  public class Hacker : IRobber {
    public string name { get; set; }
    public int SkillLevel { get; set; }

    public int PercentageCut { get; set; }

    public override string ToString () {
      return ($"{name} is a HACKER with skill Level {SkillLevel} and wants a {PercentageCut }% cut");
    }
    public void PerformSkill (Bank bank) {
      bank.AlarmScore -= SkillLevel;
      if (bank.AlarmScore <= 0) {
        Console.WriteLine ($"{name} has disabled the alarm system.");
      } else {

        Console.WriteLine ($"{name} is hacking the alarm system. Decreased security {bank.AlarmScore} points");
      }
    }
  }
}