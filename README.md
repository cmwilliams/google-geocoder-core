[![Build Status](https://travis-ci.org/cmwilliams/google-geocoder-core.svg?branch=master)](https://travis-ci.org/cmwilliams/google-geocoder-core)

# Google Geocoder for .NET Core
A simple wrapper for the Google geocoding service that's compatible with .NET Core. The library returns an instance of a Location class
with the following properties: Latitude and Longitude. Default values for Latitude and Longitude is 0.


## Install

   * nuget
   * PM> Install-Package GoogleGeoCoderCore

## Dependencies
* .NETStandard 1.6
* NETStandard.Library (>= 1.6.0)
* System.Xml.XmlDocument (>= 4.3.0)
* System.Xml.XPath.XmlDocument (>= 4.3.0)
* System.Net.Http (>= 4.3.0)

## Usage

	   using GoogleGeoCoderCore;
  
       public static async Task<Location> GetLocation(string address)
        {
            var geocoder = new GoogleGeocodeService();
            var result = await geocoder.GeocodeLocation(address);
            return result;
        }


        public static void Main(string[] args)
        {
            var location = GetLocation("Atlanta, GA");
            Console.WriteLine(location.Result.Latitude);
            Console.WriteLine(location.Result.Longitude);
            Console.ReadLine();
        }

    
## Testing

Complete test class included. 
