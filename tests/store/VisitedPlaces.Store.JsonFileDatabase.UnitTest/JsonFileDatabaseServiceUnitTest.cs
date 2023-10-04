using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.JsonFileDatabase.UnitTest
{
    public class JsonFileDatabaseServiceUnitTest
    {
        public static User user_1 = new User(Guid.Parse("0be1412b-7cc3-4120-9931-88cabbbf4f74"), "Jane Doe");
        public static User user_2 = new User(Guid.Parse("4af002aa-6aec-49e2-acd0-3689cb0a656c"), "John Doe");
        public static User user_3 = new User(Guid.Parse("85dde8b0-2374-403c-af3b-ebc63c2af429"), "Sue Storm");

        public static Place place_1 = new Place(Guid.Parse("feb286a1-6954-4a8e-a64d-9567972ca6eb"), "Sweden");
        public static Place place_2 = new Place(Guid.Parse("85dde8b0-2374-403c-af3b-ebc63c2af429"), "Finland");

        [Fact]
        public async Task LoadUsers()
        {
            var sut = new JsonFileDatabaseService();
            
            var users = await sut.GetUsers();

            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.Equal(3, users.Count());

            Assert.Contains(user_1, users);
            Assert.Contains(user_2, users);
            Assert.Contains(user_3, users);
        }

        [Fact]
        public async Task LoadPlaces()
        {
            var sut = new JsonFileDatabaseService();

            var places = await sut.GetPlaces();

            Assert.NotNull(places);
            Assert.NotEmpty(places);
            Assert.Equal(2, places.Count());

            Assert.Contains(place_1, places);
            Assert.Contains(place_2, places);
        }
    }
}