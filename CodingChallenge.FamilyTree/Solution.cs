using System;

namespace CodingChallenge.FamilyTree
{
  public class Solution
  {
    public string GetBirthMonth(Person person, string descendantName)
    {
      var descendant = GetDescendant(person, descendantName);
      if (descendant != null)
      {
        return descendant.Birthday.ToString("MMMM");
      }

      return "Name does not exist!";
    }

    public Person GetDescendant(Person person, string descendantName)
    {
      //CHECKS IF THE PERSON ITSELF OR THE PERSON'S DECENDANTS HAS descendantName
      var descendant = person.Name.Equals(descendantName) ? person : person.Descendants.Find(p => p.Name.Equals(descendantName));
      if (descendant != null)
      {
        return descendant;
      }
      else
      {
        var children = person.Descendants; 
        foreach (var child in children)
        {
          //LOOKS FOR descendantName IN EACH PERSON'S CHILD'S DESCENDANTS
          var childDescendant = GetDescendant(child, descendantName);
          if (childDescendant != null)
          {
            return childDescendant;
          }
        }
      }

      return null;
    }
  }
}