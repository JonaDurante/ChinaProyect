using Moq;
using StudioAdminData.Interfaces;
using StudioAdminData.Services;
using System.Diagnostics;
using Xunit;

namespace StudioAdminData.Test
{
    public class ActivityServiceTest
    {
        [Fact]
        public void GetAllAsyncTest()
        {
            // Arrange
            //var mockCommonServices = new Mock<ICommonServices<Activity>>();
            //var activities = new List<Activity>
            //{
            //    // Define aquí tus datos de actividades simulados para las pruebas
            //};

            //mockCommonServices
            //    .Setup(s => s.GetAllAsync())
            //    .ReturnsAsync(activities);

            //// Crea una instancia real de ActivityService y pasa el mock como dependencia
            //var activityService = new ActivityService(null, null);

            //// Act
            //var result = activityService.GetAllAsync();

            // Assert
            // Verifica que el resultado sea el esperado
            // Puedes realizar aserciones sobre `result` aquí

        }
    }
}
