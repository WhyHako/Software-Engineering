using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoftwareEngineeringNumber2
{
    class Program
    {
        public class Rootobject
        {
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string dept { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public int hours { get; set; }
        }

        public class JSON
        {
            public ОтделАСУ ОтделАСУ { get; set; }
            public ОтделИнформационныхСистем Отделинформационныхсистем { get; set; }
        }

        public class ОтделАСУ
        {
            public int count { get; set; }
            public int avg_hours { get; set; }
            public Person[] people { get; set; }
        }

        public class Person
        {
            public string name { get; set; }
            public string phone { get; set; }
            public int hours { get; set; }
        }

        public class ОтделИнформационныхСистем
        {
            public int count { get; set; }
            public int avg_hours { get; set; }
            public Person[] people { get; set; }
        }

        public static void Main(string[] args)
        {
            JObject obj = JObject.Parse(@"{
                          ""data"":[
                  {
                    ""dept"": ""Отдел информационных систем"",
                    ""name"": ""Сотрудник 1"",
                    ""phone"": ""89999999999""
                  },
                  {
                    ""dept"": ""Отдел АСУ"",
                    ""name"": ""Сотрудник 2"",
                    ""phone"": ""88888888888""
                  },
                  {
                    ""dept"": ""Отдел информационных систем"",
                    ""name"": ""Сотрудник 3"",
                    ""hours"": 165,
                    ""phone"": ""87777777777""
                  },
                  {
                    ""dept"": ""Отдел информационных систем"",
                    ""name"": ""Сотрудник 4"",
                    ""hours"": 132,
                    ""phone"": ""86666666666""
                  },
                  {
                    ""dept"": ""Отдел АСУ"",
                    ""name"": ""Сотрудник 5"",
                    ""hours"": 101,
                    ""phone"": ""85555555555""
                  },
                  {
                    ""dept"": ""Отдел информационных систем"",
                    ""name"": ""Сотрудник 6"",
                    ""hours"": 98,
                    ""phone"": ""84444444444""
                  }
                ]}");

            string json = obj.ToString();
            Rootobject result = JsonConvert.DeserializeObject<Rootobject>(json);

            var s = from f in result.data
                    orderby f.dept
                    select f;

            int countDeptIS = 0;
            int countDeptACS = 0;
            int avghoursDeptACS = 0;
            int avghoursDeptIS = 0;
            List<int> listavghoursDeptACS = new List<int>();
            List<int> listavghoursDeptIS = new List<int>();

            foreach (var f in s)
            {
                if (f.dept == "Отдел информационных систем")
                {
                    countDeptIS++;
                    if (f.hours != 0) listavghoursDeptIS.Add(f.hours);
                }
                if (f.dept == "Отдел АСУ")
                {
                    countDeptACS++;
                    if (f.hours != 0) listavghoursDeptACS.Add(f.hours);
                }
            }

            double avgdeptACS = listavghoursDeptACS.Average();
            double avgdeptIS = listavghoursDeptIS.Average();

            List<Person> persondeptIS = new List<Person>();
            List<Person> persondeptACS = new List<Person>();
            foreach (var f in s)
            {
                if (f.dept == "Отдел информационных систем")
                    persondeptIS.Add(new Person { name = f.name, phone = f.phone, hours = f.hours });
                if (f.dept == "Отдел АСУ")
                    persondeptACS.Add(new Person { name = f.name, phone = f.phone, hours = f.hours });
            }

            JSON Json = new JSON();

            ОтделАСУ deptACS = new ОтделАСУ();
            ОтделИнформационныхСистем deptIS = new ОтделИнформационныхСистем();

            deptACS.avg_hours = Convert.ToInt32(avgdeptACS);
            deptIS.avg_hours = Convert.ToInt32(avgdeptIS);

            deptACS.count = countDeptACS;
            deptIS.count = countDeptIS;

            deptACS.people = persondeptACS.ToArray();
            deptIS.people = persondeptIS.ToArray();

            Json.ОтделАСУ = deptACS;
            Json.Отделинформационныхсистем = deptIS;

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@".\final_json.json"))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                serializer.Serialize(sw, Json);
            }

            string StringJson = null;
            JSON fresult;
            using (StreamReader file = File.OpenText(@".\final_json.json"))
            {
                fresult = (JSON)serializer.Deserialize(file, typeof(JSON));
            }

            Console.WriteLine("Отдел АСУ");
            foreach (Person person in fresult.ОтделАСУ.people)
            {
                Console.WriteLine(person.name + " " + person.phone + " " + person.hours);
            }

            Console.WriteLine("Отдел ИС");
            foreach (Person person in fresult.Отделинформационныхсистем.people)
            {
                Console.WriteLine(person.name + " " + person.phone + " " + person.hours);
            }
        }
    }
}