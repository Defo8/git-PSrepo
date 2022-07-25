using System;

namespace ProgramStudent
{
    public class PlayerBio
    {
        public string CharacterName { get; set; }
        public string CharacterSurrname { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Faculty { get; set; }
        public string FieldOfstudy { get; set; }

        public PlayerBio()
        {
            CharacterName = "0";
            CharacterSurrname = "0";
            City = "0";
            Street = "0";
            PhoneNumber = "0";
            Email = "0";
            Faculty = "0";
            FieldOfstudy = "0";
        }

        public void ShowPlayerBio()
        {
            Console.WriteLine(CharacterName);
            Console.WriteLine(CharacterSurrname);
            Console.WriteLine(City);
            Console.WriteLine(Street);
            Console.WriteLine(PhoneNumber);
            Console.WriteLine(Email);
            Console.WriteLine(Faculty);
            Console.WriteLine(FieldOfstudy);
        }
    }
}
