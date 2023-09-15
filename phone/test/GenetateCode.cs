using System;
using System.IO;

namespace test
{
    internal class GenetateCode
    {
        public int Haghighi { get; set; }
        public int Hoghoghi { get; set; }

        public GenetateCode()
        {
            string haghighiContent = File.ReadAllText("haghighi.txt");
            if (int.TryParse(haghighiContent, out int haghighiValue))
            {
                Haghighi = haghighiValue;
            }

            string hoghoghiContent = File.ReadAllText("hoghoghi.txt");
            if (int.TryParse(hoghoghiContent, out int hoghoghiValue))
            {
                Hoghoghi = hoghoghiValue;
            }
        }

        public int NewHaghighiacode()
        {
            return ++Haghighi;
        }

        public int NewHoghoghoacode()
        {
            return ++Hoghoghi;
        }

        public void SaveToFile()
        {
            File.WriteAllText("haghighi.txt", Haghighi.ToString());
            File.WriteAllText("hoghoghi.txt", Hoghoghi.ToString());
        }
    }
}
