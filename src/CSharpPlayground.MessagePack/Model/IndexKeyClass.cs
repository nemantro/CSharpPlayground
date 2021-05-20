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
}