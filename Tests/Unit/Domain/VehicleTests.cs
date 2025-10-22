using Domain;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Domain
{
    /// <summary>
    /// Testes unitários para a classe Vehicle
    /// Demonstra testes básicos de propriedades e validações
    /// </summary>
    public class VehicleTests
    {
        [Fact]
        public void Vehicle_ShouldCreateInstance_WithValidProperties()
        {
            // Arrange
            var id = 1;
            var brand = "Toyota";
            var model = "Corolla";
            var year = 2023;
            var plate = "ABC-1234";
            var color = "Branco";

            // Act
            var vehicle = new Vehicle
            {
                Id = id,
                Brand = brand,
                Model = model,
                Year = year,
                Plate = plate,
                Color = color
            };

            // Assert
            vehicle.Should().NotBeNull();
            vehicle.Id.Should().Be(id);
            vehicle.Brand.Should().Be(brand);
            vehicle.Model.Should().Be(model);
            vehicle.Year.Should().Be(year);
            vehicle.Plate.Should().Be(plate);
            vehicle.Color.Should().Be(color);
        }

        [Fact]
        public void Vehicle_ShouldAllowEmptyStrings_ForStringProperties()
        {
            // Arrange & Act
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "",
                Model = "",
                Year = 2023,
                Plate = "",
                Color = ""
            };

            // Assert
            vehicle.Brand.Should().Be("");
            vehicle.Model.Should().Be("");
            vehicle.Plate.Should().Be("");
            vehicle.Color.Should().Be("");
        }

        [Fact]
        public void Vehicle_ShouldAllowNullStrings_ForStringProperties()
        {
            // Arrange & Act
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = null,
                Model = null,
                Year = 2023,
                Plate = null,
                Color = null
            };

            // Assert
            vehicle.Brand.Should().BeNull();
            vehicle.Model.Should().BeNull();
            vehicle.Plate.Should().BeNull();
            vehicle.Color.Should().BeNull();
        }

        [Theory]
        [InlineData(1900)]
        [InlineData(2000)]
        [InlineData(2023)]
        [InlineData(2030)]
        public void Vehicle_ShouldAcceptValidYears(int year)
        {
            // Arrange & Act
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "Test",
                Model = "Test",
                Year = year,
                Plate = "TEST-1234",
                Color = "Test"
            };

            // Assert
            vehicle.Year.Should().Be(year);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Vehicle_ShouldAcceptNegativeAndZeroIds(int id)
        {
            // Arrange & Act
            var vehicle = new Vehicle
            {
                Id = id,
                Brand = "Test",
                Model = "Test",
                Year = 2023,
                Plate = "TEST-1234",
                Color = "Test"
            };

            // Assert
            vehicle.Id.Should().Be(id);
        }

        [Fact]
        public void Vehicle_ShouldBeMutable_AfterCreation()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            // Act
            vehicle.Brand = "Honda";
            vehicle.Model = "Civic";
            vehicle.Year = 2024;
            vehicle.Plate = "XYZ-5678";
            vehicle.Color = "Preto";

            // Assert
            vehicle.Brand.Should().Be("Honda");
            vehicle.Model.Should().Be("Civic");
            vehicle.Year.Should().Be(2024);
            vehicle.Plate.Should().Be("XYZ-5678");
            vehicle.Color.Should().Be("Preto");
        }

        [Fact]
        public void Vehicle_ShouldCreateMultipleInstances_WithDifferentValues()
        {
            // Arrange & Act
            var vehicle1 = new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            var vehicle2 = new Vehicle
            {
                Id = 2,
                Brand = "Honda",
                Model = "Civic",
                Year = 2024,
                Plate = "XYZ-5678",
                Color = "Preto"
            };

            // Assert
            vehicle1.Should().NotBeSameAs(vehicle2);
            vehicle1.Id.Should().NotBe(vehicle2.Id);
            vehicle1.Brand.Should().NotBe(vehicle2.Brand);
            vehicle1.Model.Should().NotBe(vehicle2.Model);
            vehicle1.Year.Should().NotBe(vehicle2.Year);
            vehicle1.Plate.Should().NotBe(vehicle2.Plate);
            vehicle1.Color.Should().NotBe(vehicle2.Color);
        }
    }
}
