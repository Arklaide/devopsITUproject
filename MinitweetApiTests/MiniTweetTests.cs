using Xunit;
using Microsoft.EntityFrameworkCore;
using MInitweetApi.Models;

namespace MinitweetApiTests;

public class MinitweetApiTests
{
public readonly DbContextOptions<DatabaseContext> dbContextOptions;

    public MinitweetApiTests()
    {
         dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options;
    }

    [Fact]
    public void RegisterUser()
    {
        // Arrange
        var dbContext = new DatabaseContext(dbContextOptions);
        var userRepository = new UserRepository(dbContext);
        var user = new Userdto { username = "test", email = "test@mail.com", pwd = "test" };

        // Act
        var res = userRepository.registerUser(user); 

        // Assert
        Assert.True(res);
    }
}