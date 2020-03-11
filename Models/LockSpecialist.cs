using System;
namespace BankHeist2 {
  public class LockSpecialist : IRobber {
    public string name { get; set; }
    public int SkillLevel { get; set; }

    public int PercentageCut { get; set; }

    public override string ToString () {
      return ($"{name} is a LOCK SPECIALIST with skill Level {SkillLevel} and wants a {PercentageCut}% cut");
    }
    public void PerformSkill (Bank bank) {
      if (bank.VaultScore <= 0) {
        Console.WriteLine ($"{name} has unlocked the vault.");
      } else {

        Console.WriteLine ($"{name} is picking the lock. Decreased vault score {bank.VaultScore} points");
      }
    }
  }
}