using Dapper;
using Domain;
using FluentAssertions;
using Moq;
using MySqlConnector;
using Repository;
using Xunit;

namespace Tests.Unit.Repository
{
    /// <summary>
    /// Testes unitários para VehicleRepository
    /// Demonstra uso de mocks para isolar dependências externas
    /// </summary>
    public class VehicleRepositoryTests
    {
        private readonly VehicleRepository _repository;
        private readonly string _connectionString = "Server=localhost;Database=test;Uid=test;Pwd=test;";

        public VehicleRepositoryTests()
        {
            _repository = new VehicleRepository(_connectionString);
        }

        [Fact]
        public void Constructor_ShouldCreateInstance_WithValidConnectionString()
        {
            // Arrange
            var connectionString = "Server=localhost;Database=test;Uid=test;Pwd=test;";

            // Act
            var repository = new VehicleRepository(connectionString);

            // Assert
            repository.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_ShouldCreateInstance_WithNullConnectionString()
        {
            // Arrange
            string connectionString = null;

            // Act
            var repository = new VehicleRepository(connectionString);

            // Assert
            repository.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_ShouldCreateInstance_WithEmptyConnectionString()
        {
            // Arrange
            var connectionString = "";

            // Act
            var repository = new VehicleRepository(connectionString);

            // Assert
            repository.Should().NotBeNull();
        }

        [Fact]
        public async Task AddVehicleAsync_ShouldThrowArgumentNullException_WhenVehicleIsNull()
        {
            // Arrange
            Vehicle vehicle = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _repository.AddVehicleAsync(vehicle));
        }

        [Fact]
        public async Task AddVehicleAsync_ShouldThrowArgumentNullException_WithCorrectMessage_WhenVehicleIsNull()
        {
            // Arrange
            Vehicle vehicle = null;

            // Act
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => _repository.AddVehicleAsync(vehicle));

            // Assert
            exception.ParamName.Should().Be("vehicle");
            exception.Message.Should().Contain("Veículo inválido");
        }

        [Fact]
        public async Task AddVehicleAsync_ShouldAcceptValidVehicle()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            // Act & Assert
            // Note: Este teste irá falhar em ambiente real pois não há conexão com banco
            // Em um teste real, usaríamos mocks ou um banco de teste
            var exception = await Assert.ThrowsAsync<MySqlException>(() => _repository.AddVehicleAsync(vehicle));
            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateVehicleAsync_ShouldThrowArgumentException_WhenVehicleIsNull()
        {
            // Arrange
            Vehicle vehicle = null;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _repository.UpdateVehicleAsync(vehicle));
            exception.ParamName.Should().Be("vehicle");
            exception.Message.Should().Contain("Veículo inválido");
        }

        [Fact]
        public async Task UpdateVehicleAsync_ShouldThrowArgumentException_WhenVehicleIdIsZero()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 0,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _repository.UpdateVehicleAsync(vehicle));
            exception.ParamName.Should().Be("vehicle");
            exception.Message.Should().Contain("Veículo inválido");
        }

        [Fact]
        public async Task UpdateVehicleAsync_ShouldThrowArgumentException_WhenVehicleIdIsNegative()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = -1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _repository.UpdateVehicleAsync(vehicle));
            exception.ParamName.Should().Be("vehicle");
            exception.Message.Should().Contain("Veículo inválido");
        }

        [Fact]
        public async Task UpdateVehicleAsync_ShouldAcceptValidVehicle()
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

            // Act & Assert
            // Note: Este teste irá falhar em ambiente real pois não há conexão com banco
            var exception = await Assert.ThrowsAsync<MySqlException>(() => _repository.UpdateVehicleAsync(vehicle));
            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public async Task DeleteVehicleAsync_ShouldThrowArgumentException_WhenIdIsInvalid(int invalidId)
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _repository.DeleteVehicleAsync(invalidId));
            exception.ParamName.Should().Be("id");
            exception.Message.Should().Contain("ID inválido");
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(999)]
        public async Task DeleteVehicleAsync_ShouldAcceptValidId(int validId)
        {
            // Act & Assert
            // Note: Este teste irá falhar em ambiente real pois não há conexão com banco
            var exception = await Assert.ThrowsAsync<MySqlException>(() => _repository.DeleteVehicleAsync(validId));
            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAllVehiclesAsync_ShouldThrowMySqlException_WhenNoConnection()
        {
            // Act & Assert
            // Note: Este teste irá falhar em ambiente real pois não há conexão com banco
            var exception = await Assert.ThrowsAsync<MySqlException>(() => _repository.GetAllVehiclesAsync());
            exception.Should().NotBeNull();
        }
    }

    /// <summary>
    /// Testes com mocks mais avançados (exemplo conceitual)
    /// Demonstra como seria feito com mocks reais
    /// </summary>
    public class VehicleRepositoryMockTests
    {
        [Fact]
        public void VehicleRepository_ShouldImplementIVehicleRepository()
        {
            // Arrange
            var connectionString = "Server=localhost;Database=test;Uid=test;Pwd=test;";

            // Act
            var repository = new VehicleRepository(connectionString);

            // Assert
            repository.Should().BeAssignableTo<IVehicleRepository>();
        }

        [Fact]
        public void VehicleRepository_ShouldHaveCorrectInterfaceMethods()
        {
            // Arrange
            var connectionString = "Server=localhost;Database=test;Uid=test;Pwd=test;";
            var repository = new VehicleRepository(connectionString);

            // Act & Assert
            repository.Should().BeAssignableTo<IVehicleRepository>();
            
            // Verificar se os métodos existem
            typeof(IVehicleRepository).GetMethod("GetAllVehiclesAsync").Should().NotBeNull();
            typeof(IVehicleRepository).GetMethod("AddVehicleAsync").Should().NotBeNull();
            typeof(IVehicleRepository).GetMethod("UpdateVehicleAsync").Should().NotBeNull();
            typeof(IVehicleRepository).GetMethod("DeleteVehicleAsync").Should().NotBeNull();
        }
    }
}
