
public static class GeoLocationHelper
{
    private static readonly Random Random = new();

    public static (double Latitude, double Longitude) GenerateRandomCoordinates()
    {
        double latitude = Random.NextDouble() * 180 - 90; // Range: -90 to 90
        double longitude = Random.NextDouble() * 360 - 180; // Range: -180 to 180
        return (latitude, longitude);
    }
}