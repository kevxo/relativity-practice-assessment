using System.Data.Common;

namespace RelativityPracticeAssessment.Models;

public class Reviewer
{
  public string Id { get; set;} = string.Empty;
  public string Name {get; set;} = string.Empty;


  public Reviewer(string id, string name)
  {
    Id = id;
    Name = name;
  }
}