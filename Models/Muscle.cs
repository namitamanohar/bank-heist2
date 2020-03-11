using System;
namespace BankHeist2 {
  public class Muscle : IRobber {
    public string name { get; set; }
    public int SkillLevel { get; set; }

    public int PercentageCut { get; set; }

    public override string ToString () {
      return ($"{name} is a MUSCLE with skill Level {SkillLevel} and wants a {PercentageCut}% cut");
    }
    public void PerformSkill (Bank bank) {
      if (bank.SecurityGuardScore <= 0) {
        Console.WriteLine ($"{name} has defeated the security guards.");
      } else {

        Console.WriteLine ($"{name} is fighting the security guards. Decreased security {bank.SecurityGuardScore} points");
      }
    }
  }
}