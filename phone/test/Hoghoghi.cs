using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace test
{
    internal class Hoghoghi : Parent
    {
        public string CompanyName { set; get; }
        public string ShomareSabt { set; get; }
        public string Fax { set; get; }

        public Hoghoghi(string tell, string companyNsme, string shomareSabt,
     string fax, string address, string code)
        {
            Code = code;
            Address = address;
            Tell = tell;
            CompanyName = companyNsme;
            ShomareSabt = shomareSabt;
            Fax = fax;
            Console.WriteLine("*********HOGHOGHI PERSON********");
        }
        public override string ReturnData()
        {
            return Code + "|" + Tell + "|" + Address + "|" + CompanyName + "|" + ShomareSabt + "|" + Fax;
        }
        public override void Show()
        {
            Console.WriteLine(" " + Code + " " + Tell+ " " + Address+ " " + CompanyName+ " " + ShomareSabt + " " + Fax + " ");

        }
    }
}
