namespace DnSocial.Api.Registrars
{
    public class SwaggerRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();

            //Configuracion de versiones de los controladores swagger
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
