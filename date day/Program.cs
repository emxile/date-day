using System;
using System.Globalization;

namespace date_day
{
    class Program
    {
        static string[] dayOfWeek = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        static int[] osForMonth = { 0, 3, 28, 14, 4, 9, 6, 11, 8, 5, 10, 7, 12, 4, 29 };
        static int[] osForYear = { 2, 0, 5, 3 };
        



        static string output;

        static void Main(string[] args)
        {
            int year = 0;
            int month = 0;
            int day = 0;


            while(getDate(ref year, ref month, ref day))
            {
         



                //Console.WriteLine(LeapYear);
                whatDay(year, day, month);
                Console.WriteLine($"The date: {day}/{month}/{year} was a {output}");

            }
         

                
                

               


            
            Console.ReadLine();


        }
        /// <summary>
        /// either return a valid date in the parameters or return false advising the caller to exit 
        /// </summary>
        /// <param name="year">this will carry a valid year</param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        private static bool getDate(ref int year, ref int month, ref int day)
        {
            string txInput;
            DateTime dt;
            
            Console.WriteLine("Please enter the date in the format yyyy-mm-dd or blank to stop.");
            txInput = Console.ReadLine();
            if (txInput == "") return false;

            if(DateTime.TryParseExact(txInput,
                                   "yyyy-MM-dd",
                                   CultureInfo.InvariantCulture,
                                   DateTimeStyles.None,
                                   out dt))
            {
                year = dt.Year;
                month = dt.Month;
                day = dt.Day;

                return true;
            }
            else {
                Console.WriteLine("Not a valid date. Are you sure you have the right format? Please try again");
                
                return getDate(ref year, ref month, ref day);
            }


        
        }

       

        public static string whatDay(int year, int day, int month)
        {
            int dayIndex = 0;
            int lastTwo = year % 100;
            bool LeapYear = year % 4 == 0;
            if (LeapYear && (month < 3))
            {
                month = (month == 1) ? 13 : 14;
                
            }

            //after doomsday
            while((day-7) > osForMonth[month])
            {
                day -= 7;
            }
            dayIndex += (day - osForMonth[month]) 
                + (osForYear[(year / 100) % 4]) //figuring out the code for the year
                + ((lastTwo / 12) //dividing last two digits of year by 12
                + lastTwo % 12)  // taking remainder of previous step
                + ((lastTwo % 12) / 4); //dividing remainder by 4
            //code += (newDay - months[month]);
            //code += years[(year/100)%4];
            //code += lastTwo / 12;
            //code += lastTwo % 12;
            //code += (lastTwo % 12) / 4;
            while(dayIndex < 0)
            {
                dayIndex += 7;
            }
            while (dayIndex > 6)
            {
                dayIndex -= 7;
            }
            output = dayOfWeek[dayIndex];
            return output;
        }
    }
}
