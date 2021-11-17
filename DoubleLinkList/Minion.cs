using System;

namespace DoubleLinkList
{
    public class Minion : IComparable<Minion>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Minion(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int CompareTo(Minion oth)
        {
            if (Name.Equals(oth.Name) && Age == oth.Age)
            {
                return 0;
            }
            else if (Age < oth.Age)
            {
                return 1;
            }
            else return -1;
           
        }
        public override string ToString()
        {
            return ($"{Name} возраст: {Age}");
        }
    }
}