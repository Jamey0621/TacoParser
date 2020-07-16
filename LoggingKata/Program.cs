using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.ExceptionServices;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");
            
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS
            
            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tacoBellOne = new Tacobell();
            ITrackable tacoBellTwo = new Tacobell();
            double dist = 0;
          

            

           


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for (var i = 0; i < locations.Length; i++)
            {
                //done
                var corA = new GeoCoordinate();
                var locA = locations[i];
                // Create a new corA Coordinate  with your locA's lat and long
                corA.Longitude = locA.Location.Longitude;
                corA.Latitude = locA.Location.Latitude;
                // nested loop to get the second location
                
              
                for (var a = 0; a < locations.Length; a++)
                {
                    
                    // create locB
                    var locB = locations[a];
                    var corb = new GeoCoordinate();
                    
                    corb.Longitude = locB.Location.Longitude;
                    corb.Latitude = locB.Location.Latitude;
                    
                                if(corA.GetDistanceTo(corb)> dist)
                                    {
                                       dist = corA.GetDistanceTo(corb);
                                       tacoBellOne = locA;
                                       tacoBellTwo = locB;
                                       
                                    }
                                                  
                }     //     ^^^^^^
                      //     ||||||

                // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

                // Create a new Coordinate with your locB's lat and long

                // Now, compare the two using `.GetDistanceTo()`, which returns a double
                
                  

                // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            }
            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

            logger.LogInfo($"The distance between {tacoBellOne.Name} and {tacoBellTwo.Name} is {dist} and its the furthest 2 TacoBells! ");
           

        }
    }
}
