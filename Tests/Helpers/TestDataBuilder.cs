using Domain;

namespace Tests.Helpers
{
    /// <summary>
    /// Builder pattern para criar dados de teste
    /// Facilita a criação de objetos para testes
    /// </summary>
    public class VehicleTestDataBuilder
    {
        private Vehicle _vehicle;

        public VehicleTestDataBuilder()
        {
            _vehicle = new Vehicle();
        }

        public VehicleTestDataBuilder WithId(int id)
        {
            _vehicle.Id = id;
            return this;
        }

        public VehicleTestDataBuilder WithBrand(string brand)
        {
            _vehicle.Brand = brand;
            return this;
        }

        public VehicleTestDataBuilder WithModel(string model)
        {
            _vehicle.Model = model;
            return this;
        }

        public VehicleTestDataBuilder WithYear(int year)
        {
            _vehicle.Year = year;
            return this;
        }

        public VehicleTestDataBuilder WithPlate(string plate)
        {
            _vehicle.Plate = plate;
            return this;
        }

        public VehicleTestDataBuilder WithColor(string color)
        {
            _vehicle.Color = color;
            return this;
        }

        public VehicleTestDataBuilder WithToyotaCorolla()
        {
            _vehicle.Brand = "Toyota";
            _vehicle.Model = "Corolla";
            _vehicle.Year = 2023;
            _vehicle.Plate = "ABC-1234";
            _vehicle.Color = "Branco";
            return this;
        }

        public VehicleTestDataBuilder WithHondaCivic()
        {
            _vehicle.Brand = "Honda";
            _vehicle.Model = "Civic";
            _vehicle.Year = 2024;
            _vehicle.Plate = "XYZ-5678";
            _vehicle.Color = "Preto";
            return this;
        }

        public VehicleTestDataBuilder WithFordFocus()
        {
            _vehicle.Brand = "Ford";
            _vehicle.Model = "Focus";
            _vehicle.Year = 2022;
            _vehicle.Plate = "DEF-9012";
            _vehicle.Color = "Azul";
            return this;
        }

        public Vehicle Build()
        {
            return _vehicle;
        }

        public static VehicleTestDataBuilder Create()
        {
            return new VehicleTestDataBuilder();
        }

        public static Vehicle CreateValidVehicle()
        {
            return Create()
                .WithId(1)
                .WithToyotaCorolla()
                .Build();
        }

        public static Vehicle CreateInvalidVehicle()
        {
            return Create()
                .WithId(0)
                .WithBrand("")
                .WithModel("")
                .WithYear(0)
                .WithPlate("")
                .WithColor("")
                .Build();
        }

        public static IEnumerable<Vehicle> CreateMultipleVehicles()
        {
            return new List<Vehicle>
            {
                Create().WithId(1).WithToyotaCorolla().Build(),
                Create().WithId(2).WithHondaCivic().Build(),
                Create().WithId(3).WithFordFocus().Build()
            };
        }
    }

    /// <summary>
    /// Classe utilitária para dados de teste
    /// </summary>
    public static class TestDataHelper
    {
        public static class ConnectionStrings
        {
            public const string ValidMySql = "Server=localhost;Database=test;Uid=test;Pwd=test;";
            public const string ValidRedis = "localhost:6379";
            public const string InvalidConnection = "invalid-connection-string";
        }

        public static class VehicleData
        {
            public static Vehicle ToyotaCorolla => new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            public static Vehicle HondaCivic => new Vehicle
            {
                Id = 2,
                Brand = "Honda",
                Model = "Civic",
                Year = 2024,
                Plate = "XYZ-5678",
                Color = "Preto"
            };

            public static Vehicle FordFocus => new Vehicle
            {
                Id = 3,
                Brand = "Ford",
                Model = "Focus",
                Year = 2022,
                Plate = "DEF-9012",
                Color = "Azul"
            };

            public static IEnumerable<Vehicle> AllVehicles => new List<Vehicle>
            {
                ToyotaCorolla,
                HondaCivic,
                FordFocus
            };
        }

        public static class CacheKeys
        {
            public const string VehiclePrefix = "vehicle:";
            public const string VehicleList = "vehicles:list";
            public const string VehicleCount = "vehicles:count";
            
            public static string GetVehicleKey(int id) => $"{VehiclePrefix}{id}";
            public static string GetVehicleListKey(int page, int pageSize) => $"{VehicleList}:page:{page}:size:{pageSize}";
        }

        public static class TestConstants
        {
            public const int DefaultTimeout = 5000;
            public const int DefaultCacheExpiryMinutes = 30;
            public const int DefaultPageSize = 10;
            public const int DefaultPage = 1;
        }
    }
}
