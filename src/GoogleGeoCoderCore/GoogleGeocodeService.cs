using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace GoogleGeoCoderCore
{
    public class GoogleGeocodeService
    {
        public async Task<Location> GeocodeLocation(string address)
        {
            //Set default values
            var location = new Location {Latitude = 0, Longitude = 0};

            try
            {
                var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

                using (var client = new HttpClient())
                {
                    var request = await client.GetAsync(requestUri);
                    var content = await request.Content.ReadAsStringAsync();
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(content);

                    //We have data!
                    location.Latitude = double.Parse(xmlDoc.SelectSingleNode("//geometry/location/lat").InnerText, NumberFormatInfo.InvariantInfo);
                    location.Longitude = double.Parse(xmlDoc.SelectSingleNode("//geometry/location/lng").InnerText, NumberFormatInfo.InvariantInfo);
                    
                    //Let's return that data
                    return location;
                }
            }
            catch (Exception)
            {
                //Return default values
                return location;
            }
        }
    }
}
