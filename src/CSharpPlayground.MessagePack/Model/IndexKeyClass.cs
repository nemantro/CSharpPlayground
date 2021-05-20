using MessagePack;

namespace CSharpPlayground.MessagePack.Model
{
    [MessagePackObject]
    public class IndexKeyClass
    {
        [Key(0)]
        public int Age { get; set; }

        [Key(1)]
        public string FirstName { get; set; }

        [Key(2)]
        public string LastName { get; set; }

        [IgnoreMember]
        public string FullName { get { return FirstName + LastName; } }
    }

    [MessagePackObject]
    public class ExtendedIndexKeyClass
    {
        [Key(0)]
        public int Age { get; set; }

        [Key(1)]
        public string FirstName { get; set; }

        [Key(2)]
        public string LastName { get; set; }

        [Key(3)]
        public int NewIntger {get; set;}
    }

    [MessagePackObject]
    public class DifferentIndexKeyClass
    {
        [Key(0)]
        public int DIfferentAge { get; set; }

        [Key(1)]
        public string DifferentFirstName { get; set; }

        [Key(2)]
        public double NewDoubleValue { get; set; }
    }

    [MessagePackObject]
    public class SimilarIndexKeyClass
    {
        [Key(0)]
        public int DIfferentAge { get; set; }

        [Key(1)]
        public string DifferentFirstName { get; set; }

        [Key(2)]
        public string DifferentLastName { get; set; }
    }
}