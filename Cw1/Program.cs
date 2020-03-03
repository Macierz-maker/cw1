using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)    // async używamy zawsze z Task!!! Taks oznacza wykonania jakiegoś zadania, BEZ ZWRACANIA
        {
            //console.writeline("hello world!");
            //// writeline() to odpowiednik system.out.println()

            //int tmp1 = 1;
            //int? tmp11 = null; // ? pozwala na null'e
            //double tmp2 = 2.0;

            //string tmp3 = "aaa";
            //bool tmp4 = true;

            //var tmp5 = 5;
            //var tmp6 = "aa";
            //var tmp7 = "ala ma kota";
            //var tmp8 = "i psa";

            //// var zastępuje typ zmiennej

            //console.writeline($"{tmp7} {tmp8} {tmp1} {tmp2 + tmp5}"); // konkatenacja

            //var path = @"c:\users\s18239\desktop"; 
            //var newperson = new person { firstname = "maciek" };    // nie potrzeba konstruktora, od razu można przypisać wartości

            var url = args.Length > 0 ? args[0] : "https://www.pja.edu.pl";
            // var httpClient = new HttpClient();

            // httpClient.Dispose(); // zablokowanie zasobu
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync(url))
                {  // async oznacza, że kod będzie wykonany asynchronicznie
                   // await poprzedza wykonanie metody asynchronicznie, żeby nie było błędu trzeba bd wrzucić do Maint'a słowo async i Task

                    if (response.IsSuccessStatusCode)              // kod 200  oznacza, że wszystko jest ok, czyli tutaj to znacza "jeśli response to 200
                    {
                        var htmlContent = await response.Content.ReadAsStringAsync();
                        var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                        var matches = regex.Matches(htmlContent);

                        foreach (var match in matches)
                        {
                            Console.WriteLine(match.ToString());
                        }
                    }
                }
            }
        }
        // todo zrobić zadanie 4 i 5
    }
}
