using VisitedPlaces.Store.Shared.Models;

namespace VisitedPlaces.Store.JsonFileDatabase.UnitTest
{
    public class JsonFileDatabaseServiceUnitTest
    {
        public static User user_1 = new User(Guid.Parse("0be1412b-7cc3-4120-9931-88cabbbf4f74"), "Jane Doe");
        public static User user_2 = new User(Guid.Parse("4af002aa-6aec-49e2-acd0-3689cb0a656c"), "John Doe");
        public static User user_3 = new User(Guid.Parse("85dde8b0-2374-403c-af3b-ebc63c2af429"), "Sue Storm");

        public static Place place_1 = new Place(Guid.Parse("feb286a1-6954-4a8e-a64d-9567972ca6eb"), "Sweden");
        public static Place place_2 = new Place(Guid.Parse("c67dd607-d4c6-4615-bae4-50d1d43cc3dc"), "Finland");
        public static Place place_3 = new Place(Guid.Parse("b8445f81-9a83-49e6-acca-de7b87c60065"), "Norway");

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
        public async Task LoadVisitedplaces_User1()
        {
            var sut = new JsonFileDatabaseService();

            var places = await sut.GetVisitedPlaces(user_1.Id);

            Assert.NotNull(places);
            Assert.NotEmpty(places);
            Assert.Single(places);

            Assert.Contains(place_2, places);
        }

        [Fact]
        public async Task LoadVisitedplaces_User2()
        {
            var sut = new JsonFileDatabaseService();

            var places = await sut.GetVisitedPlaces(user_2.Id);

            Assert.NotNull(places);
            Assert.NotEmpty(places);
            Assert.Equal(2, places.Count());

            Assert.Contains(place_1, places);
            Assert.Contains(place_2, places);
        }

        [Fact]
        public async Task LoadVisitedplaces_User3()
        {
            var sut = new JsonFileDatabaseService();

            var places = await sut.GetVisitedPlaces(user_3.Id);

            Assert.NotNull(places);
            Assert.Empty(places);
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

        [Fact]
        public async Task LoadVisitors_Place1()
        {
            var sut = new JsonFileDatabaseService();

            var users = await sut.GetVisitors(place_1.Id);

            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.Single(users);

            Assert.Contains(user_2, users);
        }

        [Fact]
        public async Task LoadVisitors_Place2()
        {
            var sut = new JsonFileDatabaseService();

            var users = await sut.GetVisitors(place_2.Id);

            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.Equal(2, users.Count());

            Assert.Contains(user_1, users);
            Assert.Contains(user_2, users);
        }

        [Fact]
        public async Task LoadVisitors_Place3()
        {
            var sut = new JsonFileDatabaseService();

            var users = await sut.GetVisitors(place_3.Id);

            Assert.NotNull(users);
            Assert.Empty(users);
        }
    }
}