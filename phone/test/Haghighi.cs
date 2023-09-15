using System;
using System.Reflection.Emit;

namespace test
{
    public class Haghighi : Parent
    {
        //int code { get; set; }
        //string tell { get; set; }
        //string address { get; set; }
        public string Name { set; get; }
        public double Age { set; get; }
        public string Family { set; get;}
        public string Mobile { set; get;}

    
        public Haghighi(string name, double age, string family, string mobile,
            string code, string tell, string address)
        {
            Code = code;
            Address = address;
            Tell = tell;
            Name = name;
            Age = age;
            Family = family;
            Mobile = mobile;
        }

        public Haghighi()
        {
        }

        public override string ReturnData()
        {
            return Code + "|" + Tell + "|" + Address + "|" + Name + "|" + Age + "|" + Family + "|" + Mobile;
        }

        public override void Show()
        {
            Console.WriteLine( "" + Code + " " + Tell+ " " + Address + " " + Name+ " " + Age+ " " + Family +" "+ Mobile + "");
        }
    }

}
