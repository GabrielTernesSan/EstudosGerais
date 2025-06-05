using JornadaMilhas.API.DTO.Auth;
using System.Net.Http.Json;

namespace JornadaMilhas.Integration.Test.API
{
    public class JornadaMilhas_AuthTest
    {
        [Fact]
        public async Task POST_Efetua_Login_Com_Sucesso()
        {
            //Arrange
            var app = new JornadaMilhasWebApplicationFactory();

            var user = new UserDTO { Email = "tester@email.com", Password = "Senha123@" };

            using var client = app.CreateClient();

            //Act
            var resultado = await client.PostAsJsonAsync("/auth-login", user);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, resultado.StatusCode);
        }

        [Fact]
        public async Task POST_Login_Falha_User_E_Senha_Invalidos()
        {
            //Arrange
            var app = new JornadaMilhasWebApplicationFactory();

            var user = new UserDTO { Email = "gabriel@", Password = "123" };

            using var client = app.CreateClient();

            //Act
            var resultado = await client.PostAsJsonAsync("/auth-login", user);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, resultado.StatusCode);
        }
    }
}