namespace Core_Proje_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Controller'lar? ekle
            builder.Services.AddControllers();

            // Swagger servislerini ekle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Swagger UI ayarlar?
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Proje API V1");
                    c.RoutePrefix = string.Empty; // root adresinden aç
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Root adresi bo?sa Swagger'a yönlendir
            app.MapGet("/", () => Results.Redirect("/swagger"));

            app.Run();
        }
    }
}
