using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hw1_The_Exercise_App_G.Canos{
    public class CalorieBurner{
        public string inFile; // The input file path and name
        public string[] rows = new string[0]; // These are the raw rows from file
        List<Exercise> excerData = new List<Exercise>(); // THese are Raw Rows converted into Exercise
        public CalorieBurner(string inFile){
            this.inFile = inFile;
        }
        public void getRowsFromFile(){ 
            // ToDo: Get all input data and set rows;
            // Sets the rows variable

            try {
                rows = File.ReadAllLines(inFile);
            }
            catch (Exception e) {
                Console.WriteLine("Error when opening file");
                Console.WriteLine(e.Message);
            }

        }
        public void SetExerciseRecords(){
            //ToDo: Convert this.rows into this.exerData rows
            List<Exercise> eData = new List<Exercise>();
            //this.excerData = eData;

            foreach (String row in rows) { 
                string[] toks = row.Split(',');
                DateTime dt;
                string exType;
                decimal time;
                decimal speed;

                try {
                    dt = DateTime.ParseExact(toks[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                }

                catch(Exception e) { throw new ArgumentException("dt incorrect"); }

                try { exType = toks[1]; }
                catch (Exception e) { throw new ArgumentException("exType incorrect"); }

                try { time = decimal.Parse(toks[2]); }

                catch (Exception e) { throw new ArgumentException("time incorrect"); }

                try { speed = decimal.Parse(toks[3]); }
                catch (Exception e){ throw new ArgumentException("speed incorrect"); }

                eData.Add(new Exercise(dt, exType, time, speed));
            }
            this.excerData = eData;
            Console.WriteLine("Welcome to Calorie Burner Exercise App");
            Console.WriteLine("Would you like to calculate your calories burned Walking, Biking, or Total for the day?");


        }
        public decimal getWalkingCalories(DateTime inDate){
            // ToDo: Return the total calories walking for input date
            //  Use these speeds to calculate calories:
            //      Calories Per Mile Speed
            //      a. 100       2.5 or more,
            //      b. 125         3 or more,
            //      c.  90        less than 2.5
            // Returns: the total calories burned for that day for walking
            decimal cals = 0.0m;
            decimal milesNum = 0.0m;
            int anotherExcerFound = 0;
            decimal addCals = 0.0m;
            for (int i = 0; i < excerData.Count(); i++) {
                if (excerData[i].dt.Equals(inDate))
                {
                    if (excerData[i].exType.Equals("Walking"))
                    {
                        if (anotherExcerFound > 0)
                        {
                            addCals = cals;
                        }
                        milesNum = excerData[i].speed;
                        if (milesNum >= 2.5m && milesNum <= 2.9m)
                        {
                            if (excerData[i].time == 30)
                            {
                                cals = 100.0m / 2;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }
                            else if (excerData[i].time == 40)
                            {
                                cals = 100.0m / 1.5m;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }
                            else
                            {
                                cals = 100.0m;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }

                        }
                        else if (milesNum >= 3)
                        {
                            if (excerData[i].time == 30)
                            {
                                cals = 125.0m / 2;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }
                            else if (excerData[i].time == 40)
                            {
                                cals = 125.0m / 1.5m;
                                cals = cals + addCals;
                                anotherExcerFound++;

                            }
                            else if (milesNum < 2.5m)
                            {
                                cals = 125.0m;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }
                        }
                        else if (milesNum < 2.5m)
                        {
                            if (excerData[i].time == 30)
                            {
                                cals = 90.0m / 2;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }
                            else if (excerData[i].time == 40)
                            {
                                cals = 90.0m / 1.5m;
                                cals = cals + addCals;
                                anotherExcerFound++;

                            }
                            else
                            {
                                cals = 90.0m;
                                cals = cals + addCals;
                                anotherExcerFound++;
                            }
                        }

                    }

                }
                else {
                    Console.WriteLine("bad date{0}", inDate.ToString());
                }
            }
            return cals;
        }
        public decimal getBikingCalories(DateTime dateTime){
            // ToDo: Return the total calories walking for input date
            //  Use these speeds to calculate calories:
            //  Speed              Calories Per Mile
            //  Light < 10 MPH      30 
            //  Moderate 10-13.9    45 
            //  Vigorous 14-19.9  55 Calories Per Mile
            // Racing >=20 65.4 - Calories Per Mile
            decimal cals = 0.0m;
            decimal milesBiked = 0.0m;
            int plusExcerCtr = 0;
            decimal plusCals = 0.0m;
            for (int i = 0; i < excerData.Count(); i++) {
                if (excerData[i].dt.Equals(dateTime)) {
                    if (excerData[i].exType.Equals("Biking")) {
                        if (plusExcerCtr > 0) {
                            plusCals = cals;
                        }
                        milesBiked = excerData[i].speed;
                        if (milesBiked < 10) {
                            cals = milesBiked * 30;
                            cals= cals + plusCals;
                            plusExcerCtr++;
                        }
                        else if (milesBiked >= 10 && milesBiked <= 13.9m) {
                            cals = milesBiked * 45;
                            cals = cals + plusCals;
                            plusExcerCtr++;
                        }
                        else if (milesBiked >= 14 && milesBiked <= 19.9m) {
                            cals = milesBiked * 55;
                            cals = cals + plusCals;
                            plusExcerCtr++;
                        }
                        else if (milesBiked >= 20){
                            cals = milesBiked * 65.4m;
                            cals = cals + plusCals;
                            plusExcerCtr++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("bad date{0}", dateTime.ToString());
                }

            }
            return cals;
        }
    }

}
