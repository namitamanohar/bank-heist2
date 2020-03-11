namespace BankHeist2 {
  public interface IRobber {
    string name { get; set; }
    int SkillLevel { get; set; }

    int PercentageCut { get; set; }
    void PerformSkill (Bank bank);
  }
}