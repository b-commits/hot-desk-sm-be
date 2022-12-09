using HotDesk.API.Entities;
using HotDesk.API.Services.ReservationsService;

namespace HotDesk.Tests;

using System.Threading.Tasks;
using HotDesk.API.Controllers;
using HotDesk.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class ReservationsControllerTest
{
    private readonly ReservationsController _reservationsController;
    private readonly Mock<IReservationService> _mockReservationService =
        new Mock<IReservationService>();
    private readonly Mock<IDeskService> _mockDeskService = new Mock<IDeskService>();

    public ReservationsControllerTest()
    {
        _reservationsController = new ReservationsController(
            _mockReservationService.Object,
            _mockDeskService.Object
        );
    }

    [Fact]
    public async Task GetReservations_On_Success_Returns_200_With_Users()
    {
        // Arrange
        _mockReservationService
            .Setup(service => service.GetReservationsAsync())
            .ReturnsAsync(new List<Reservation>());

        // Act
        var result = (OkObjectResult)await _reservationsController.GetReservations();

        // Assert
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<List<Reservation>>(result.Value);
    }

    [Fact]
    public async Task GetReservationById_If_Not_Found_Returns_404()
    {
        // Arrange
        _mockReservationService
            .Setup(service => service.GetReservationByIdAsync("2934"))
            .ReturnsAsync((Reservation)null);

        // Act
        var result = (NotFoundResult)await _reservationsController.GetReservationById("2934");

        // Assert
        Assert.Equal(404, result.StatusCode);
    }
}
