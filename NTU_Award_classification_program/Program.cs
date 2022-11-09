using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTU_Award_classification_program
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> moduleName = new List<string>();

            List<int> moduleResult = new List<int>();

            bool additionalResult = true;

            String resultQuestion;

            String moduleOffered;

            const double distinction = 16;
            const double distinctionBoundary = 12.5;
            const double commendation = 12.4;
            const double commendationBoundary = 9.5;
            const double pass = 9.4;
            const double passBoundary = 6.5;
            const double fail = 6.4;

            string award;


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n Welcome to the NTU Degree Award Classification Program");
            Console.ResetColor();


           

            while (additionalResult) {

                Console.Write("\n Kindly enter your module name, should be minimum 10 characters ");

                moduleOffered = Console.ReadLine();

                if (moduleOffered.Length < 10) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n Incorrect module length deteched!!!: \n The supplied module name must be minimum of 8 characters, please correct it and try again!! ");
                    Console.ResetColor();
                    break;
                }

                moduleName.Add(moduleOffered);

                Console.Write("\n Kindly enter your module Grade point Result. This could a number between 0 and 16!: ");

                VerifyResultPoint(Console.ReadLine(), moduleResult);

                Console.Write("\n Do you have more result to provide? Select Y for yes or N for No: ");
                resultQuestion = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n ----------------------------------------------------------------------- ");
                Console.ResetColor();


                if (resultQuestion == "y")
                {
                    additionalResult = true;
                }
                else {
                    additionalResult = false;
                }
            }

            CreateStudentDictionaryFromList(moduleName, moduleResult);


            

            Console.WriteLine($"\n Your degree award received classification is: {AwardGenerator(moduleResult[0])}");

            Console.ReadKey();

            

        }


        static void CollectResultInfo(List<String> name, List<int> result) {

            Console.WriteLine("\n Kindly enter your module name: ");

            name.Add(Console.ReadLine());

            Console.WriteLine("\n Kindly enter your module Grade point Result. This could a number between 0 and 16!: ");

            result.Add(Convert.ToInt32(Console.ReadLine()));
        }

        static int VerifyResultPoint(String resultGrade, List<int> result) {

            int verifiedGrade;

            if (resultGrade.Contains("."))
            {
                int locationOfPeriod = resultGrade.IndexOf(".");

                int nextDigit = locationOfPeriod + 1;

                //Console.WriteLine($"\n digit after period is: {resultGrade[nextDigit]} ");

                if (Convert.ToInt32(resultGrade[nextDigit]) >= 5) {

                    double newResultGradeDouble = Convert.ToDouble(resultGrade);

                    newResultGradeDouble = Math.Round(newResultGradeDouble);

                    resultGrade = newResultGradeDouble.ToString();

                    //Console.WriteLine($"\n digit after rounding to double 1 decimal and concerting back to string is: {resultGrade} ");


                }

                resultGrade = resultGrade.Substring(0, locationOfPeriod);

                //Console.WriteLine($"\n New whole number generated from double is: {resultGrade} ");
            }


            if ( int.TryParse(resultGrade, out verifiedGrade) )
            {

                if (verifiedGrade >= 0 && verifiedGrade <= 16)
                {
                    result.Add(verifiedGrade);
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n The number you supplied is out of range, please provide a valid number!! ");
                    Console.ResetColor();
                }
            }
            else {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n what you supplied is not a number, please check again!!! ");
                Console.ResetColor();

            }

            return verifiedGrade;
        }

        static void CheckAndPrintList(List<String> names, List<int> results) {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t\t\t\t \n Module Names ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n ************************************************************************************************* ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            for (var name = 0; name < names.Count; name++) {
    
                Console.WriteLine($"\t\t\t\t \n ({name + 1}). {names[name]} ");
            
            }
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\t\t\t\t \n Module Results ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n ************************************************************************************************* ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            for (var result = 0; result < results.Count; result++)
            {


                Console.WriteLine($"\t\t\t\t \n ({result + 1}). {results[result]} ");

            }
            Console.ResetColor();
        }


        static void CreateStudentDictionary(String moduleName, int moduleResult) {

            Dictionary<String, int> studentRecord = new Dictionary<string, int>();

            List<Dictionary<String, int>> students = new List<Dictionary<string, int>>();

            studentRecord.Add(moduleName, moduleResult);  //create dictionary

            students.Add(studentRecord); //add each dictionary into a List

            Console.WriteLine($"\n How many entries are in student list?: {students.Count}");

            Console.WriteLine($"\n How many entries are in studenRecord dictionary?: {studentRecord.Count}");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ************************************************************************************************* ");
            Console.ResetColor();

            Console.WriteLine("\n STUDENT RECORD");
            if (students.Count > 0) {

                for (var record = 0; record < students.Count; record++) {

                    foreach (KeyValuePair<String, int> dict in students[record])
                    {

                        Console.WriteLine($"\nModules Offered \n {dict.Key}: Module Result ->{dict.Value}");

                    }


                }

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n ************************************************************************************************* ");
            Console.ResetColor();


        }


        static void CreateStudentDictionaryFromList(List<String> modules, List<int> results) {

            Dictionary<String, int> student = new Dictionary<string, int>();

            int module;
            int result;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ................................................................................. ");
            Console.ResetColor();
            for (module = 0; module < modules.Count; module++) {

                for (result = 0; result < results.Count; result++) {

                    if (module == result) {

                        student.Add(modules[result], results[result]);
          
                    }
                }

            }

            if (student.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n MODULES                                                              GRADE POINT");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n ................................................................................. ");
                Console.ResetColor();


                Console.ForegroundColor = ConsoleColor.Green;
                /*foreach (KeyValuePair<String, int> record in student)
                {

                    Console.WriteLine($"\n {student.Count}. {(record.Key).Substring(0, 8)}.....................................................................{record.Value}");


                }*/

                for (var record = 0; record < student.Count; record++) {

                    KeyValuePair<String, int> studentRecord = student.ElementAt(record);

                    Console.WriteLine($"\n {record + 1}. {(studentRecord.Key).Substring(0, 10)}.................................................................{studentRecord.Value}");

                }
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n ................................................................................. ");
            Console.ResetColor();

        }


        static string AwardGenerator(int gradePoint) {

            double gradePointDouble = Convert.ToDouble(gradePoint);

            string awardReceived;

            const double distinction = 16;
            const double distinctionBoundary = 12.5;
            const double commendation = 12.4;
            const double commendationBoundary = 9.5;
            const double pass = 9.4;
            const double passBoundary = 6.5;
            const double fail = 6.4;

            if (gradePointDouble >= distinctionBoundary && gradePointDouble <= distinction)
            {

                awardReceived = "Distinction";
            }
            else if (gradePointDouble >= commendationBoundary && gradePointDouble <= commendation)
            {

                awardReceived = "Commendation";
            }
            else if (gradePointDouble >= passBoundary && gradePointDouble <= pass)
            {

                awardReceived = "Commendation";
            }
            else {

                awardReceived = "Fail";

            }

            return awardReceived;
        
        }

    }
}
