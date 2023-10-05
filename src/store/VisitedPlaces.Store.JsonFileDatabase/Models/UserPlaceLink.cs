namespace VisitedPlaces.Store.JsonFileDatabase.Models;

public class UserPlaceLink
{
    public IDictionary<Guid, UserPlaceLinkData> Links { get; set; } = new Dictionary<Guid, UserPlaceLinkData>();
}

public class UserPlaceLinkData
{
    public Guid User { get; set; }
    public IEnumerable<Guid> Places { get; set; } = new Guid[0];
}

/*
{
  "a748aa60-f257-4874-8217-1137b9d3e5ac": {
    "User": "0be1412b-7cc3-4120-9931-88cabbbf4f74",
    "Places": [
      "c67dd607-d4c6-4615-bae4-50d1d43cc3dc"
    ]
  },
  "12167472-8b49-435a-ab65-5eb86fb6e611": {
    "User": "4af002aa-6aec-49e2-acd0-3689cb0a656c",
    "Places": [
      "c67dd607-d4c6-4615-bae4-50d1d43cc3dc",
      "feb286a1-6954-4a8e-a64d-9567972ca6eb"
    ]
  }
}
*/
