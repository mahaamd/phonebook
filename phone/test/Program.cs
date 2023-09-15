using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace test
{
    internal class Program
    {
        private static GenetateCode id;
        /// <summary>
        /// check iterator 
        /// </summary>


        //private static FileStream fileStream = new FileStream();
        private static List<string> lines = new List<string>();

        public static bool EndOfProg { get; private set; }

        public static void LoadFile()
        {
            FileStream fileStream = File.Open("info.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);
            //Console.WriteLine(streamReader.Read());
            while (!streamReader.EndOfStream)
            {
                lines.Add(streamReader.ReadLine());
            }
            fileStream.Flush();
            //Console.ReadKey();
            fileStream.Close();
            //streamReader.Close();
            Console.WriteLine("loaded from file seccesfully");
        }
        public static void Save(Parent parent)
        {

            //fileStream.Close();
            string parentData = parent.ReturnData();
            if (parent.GetType() == typeof(Haghighi))
            {
                parentData += "|Haghighi";
            }
            else if (parent.GetType() == typeof(Hoghoghi))
            {
                parentData += "|Hoghoghi";
            }
            lines.Add(parentData);

            Console.WriteLine("added to file seccesfully");
            //Console.ReadKey();
        }
        public static void Input()
        {
            //Console.Clear();

            Console.WriteLine("enter 1 for haghighi person");
            Console.WriteLine("enter 2 for hoghoghi person");
            Console.WriteLine("enter 0 for exit");

            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            string haghighiHoghoghi = consoleKeyInfo.Key.ToString();
            //if (consoleKeyInfo != null)
            Console.WriteLine();
            if (haghighiHoghoghi != "D1" && haghighiHoghoghi != "D2"
                && !haghighiHoghoghi.Equals("D0"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("choose a valid option");
                Console.ForegroundColor = ConsoleColor.White;
                Input();
            }
            if (haghighiHoghoghi.Equals("D0"))
            {
                EndOfProg = true;
            }
            if (haghighiHoghoghi.Equals("D2"))
            {
                //Console.Clear();
                HoghoghiInput();
            }
            if (haghighiHoghoghi.Equals("D1"))
            {
                //Console.Clear();


                HaghighiInput();
            }

            Console.WriteLine(" " + consoleKeyInfo.Key.ToString());
        }

        private static void HoghoghiInput()
        {
            Console.WriteLine("*********HOGHOGHI PERSON********");
            Console.WriteLine("enter 1 for show all persons");
            Console.WriteLine("enter 2 for add persons");
            Console.WriteLine("enter 3 for delete");
            Console.WriteLine("enter 0 for return");
            ConsoleKeyInfo options = Console.ReadKey();
            string selectedOptions = options.Key.ToString();
            Console.WriteLine();
            switch (selectedOptions)
            {
                case "D1":
                    ShowAll(IndividualType.Hoghoghi);
                    break;
                case "D2":
                    Save(GetHoghoghiPersonInfo());
                    break;
                case "D3":
                    //Console.Clear();
                    ShowAll(IndividualType.Hoghoghi);
                    Console.WriteLine("enter person code for delete");
                    Delete(Console.ReadLine());
                    break;
                case "D0":
                    Console.Clear();
                    Input();
                    break;
                default:

                    Console.WriteLine("choose valid option");
                    //Console.ReadKey();
                    //Console.Clear();
                    HoghoghiInput();
                    break;
            }
        }

        private static void HaghighiInput()
        {
            Console.WriteLine("*********HAGHIGHI PERSON********");

            Console.WriteLine("enter 1 for show all persons");
            Console.WriteLine("enter 2 for add persons");
            Console.WriteLine("enter 3 for delete");
            Console.WriteLine("enter 0 for return");
            ConsoleKeyInfo options = Console.ReadKey();
            string selectedOptions = options.Key.ToString();
            Console.WriteLine();

            switch (selectedOptions)
            {
                case "D1":
                    ShowAll(IndividualType.Haghighi);
                    break;
                case "D2":
                    Save(GetHaghighiPersonInfo());
                    break;
                case "D3":
                    //Console.Clear();
                    ShowAll(IndividualType.Haghighi);
                    Console.WriteLine("enter person code for delete");
                    Delete(Console.ReadLine());
                    break;
                case "D0":
                    Console.Clear();
                    Input();
                    break;
                default:
                    if (selectedOptions.Equals("D0"))
                    {
                        Input();
                    }
                    else
                    {
                        Console.WriteLine("choose valid option");
                        //Console.Clear();
                        HaghighiInput();
                    }
                    break;
            }

        }
        private static Hoghoghi GetHoghoghiPersonInfo()
        {
            string code, tell, address, companyName, shomareSabt, fax;
            while (true)
            {
                //Console.WriteLine("enter code");
                code = id.NewHoghoghoacode().ToString();
                Console.WriteLine("enter tell");
                tell = Console.ReadLine();
                Console.WriteLine("enter address");
                address = Console.ReadLine();
                Console.WriteLine("enter company name");
                companyName = Console.ReadLine();
                Console.WriteLine("enter shomare sabt");
                shomareSabt = Console.ReadLine();
                Console.WriteLine("enter fax");
                fax = Console.ReadLine();

                if (!code.IsValid(DataType.Code) || !tell.IsValid(DataType.Tell)||
                    !shomareSabt.IsValid(DataType.ShomareSabt) || !fax.IsValid(DataType.Fax))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input data is not valid. Please enter the data again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                break;
            }

            Hoghoghi hoghoghi = new Hoghoghi(tell, companyName, shomareSabt, fax, address, code);
            return hoghoghi;
        }

        private static Haghighi GetHaghighiPersonInfo()
        {
            string code, tell, address, name, family, mobile;
            int age;

            while (true)
            {
                //Console.WriteLine("enter code");
                code = id.NewHaghighiacode().ToString();
                Console.WriteLine("enter tell");
                tell = Console.ReadLine();
                Console.WriteLine("enter address");
                address = Console.ReadLine();
                Console.WriteLine("enter name");
                name = Console.ReadLine();
                Console.WriteLine("enter age");

                if (!int.TryParse(Console.ReadLine(), out age))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid age. Please enter a valid integer.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                Console.WriteLine("enter family");
                family = Console.ReadLine();
                Console.WriteLine("enter mobile");
                mobile = Console.ReadLine();

                if (!code.IsValid(DataType.Code) || !tell.IsValid(DataType.Tell) || !name.IsValid(DataType.Name) ||
                    !age.ToString().IsValid(DataType.Age) || !family.IsValid(DataType.Family) || !mobile.IsValid(DataType.Mobile))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your input data is not valid. Please enter the data again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                break;
            }

            Haghighi haghighi = new Haghighi(name, age, family, mobile, code, tell, address);
            return haghighi;
        }


        public static void ShowAll(IndividualType type)
        {

            foreach (string data in lines)
            {
                //string data = streamReader.ReadLine();

                if (data.Split('|')[data.Split('|').Length - 1] == type.ToString())
                {
                    Console.WriteLine(data);
                }
            }
            //streamReader.Close();
        }
        public static List<string> Search(string code)
        {
            List<string> codes = new List<string>();
            foreach (string line in lines)
            {
                string[] splited = line.Split('|');
                if (splited[0].Equals(code))
                {
                    codes.Add(splited[0]);
                    //Console.WriteLine(line);
                }
            }
            return codes;
        }
        public static void Delete(string code)
        {
            List<string> codes = Search(code);
            //Console.WriteLine();
            //{
            for (int i = 0; i < codes.Count; i++)
            {
                for (int j = 0; j < lines.Count; j++)
                {
                    string[] splited = lines[j].Split('|');
                    if (splited[0].Equals(codes[i]))
                    {
                        //codes.Add(splited[0]);
                        //Console.WriteLine("lines j is equal to" + lines[j]);
                        lines.Remove(lines[j]);
                    }
                }
            }
        }

        private static void SaveFile()
        {
            FileStream fileStream = File.Open("info.txt", FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);

            foreach (string item in lines)
            {
                //string parentData = 
                streamWriter.WriteLine(item);

            }

            streamWriter.Close();

        }
        static void Main(string[] args)
        {
            id = new GenetateCode();

            LoadFile();
            while (!EndOfProg)
            {
                Input();
            }
            id.SaveToFile();
            SaveFile();
        }
    }
}