using MessagePack;

namespace CSharpPlayground.MessagePack.Model
{
    public class StringKeyClass
    {
        [Key("age")]
        public int Age { get; set; }

        [Key("firstName")]
        public string FirstName { get; set; }

        [Key("lastName")]
        public string LastName { get; set; }

        [IgnoreMember]
        public string FullName { get { return FirstName + LastName; } }
    }
}