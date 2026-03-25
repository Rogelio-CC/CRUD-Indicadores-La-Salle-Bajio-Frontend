// Importaciones necesarias para el funcionamiento del servicio.
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using PruebaAutenticador2.Handlers;
using PruebaAutenticador2.Services;
using Radzen;

//Lectura local del archivo .env (no es necesario en entorno de producción).
//DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

// Se configura el esquema de autenticación y sin redirección automática:
// - DefaultScheme: "Cookies" para mantener la sesión del usuario.
// - DefaultChallengeScheme: OpenIdConnect para redirigir a Azure AD cuando no hay sesión.
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
// Se añade autenticación con Microsoft Identity Platform (Azure AD). Los parámetros se leen de la sección "AzureAd" del archivo appsettings.json o .env.
.AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
// Habilita la adquisición de tokens para llamar a APIs downstream (Microsoft Graph u otras).
.EnableTokenAcquisitionToCallDownstreamApi()
// Almacena los tokens en memoria (para pruebas; en producción se recomienda cache distribuido).
.AddInMemoryTokenCaches();

// Personalización del comportamiento de OpenIdConnect:
// Se maneja el evento de cierre de sesión para redirigir a la página principal ("/") en lugar de la página predeterminada de Azure AD.
builder.Services.Configure<OpenIdConnectOptions>(
    OpenIdConnectDefaults.AuthenticationScheme,
    options =>
    {
        options.Events.OnSignedOutCallbackRedirect = context =>
        {
            context.Response.Redirect("/");
            context.HandleResponse(); // Evita que el middleware continúe con el comportamiento por defecto.
            return Task.CompletedTask;
        };
    });

// EmailService: Servicio para envío de correos electrónicos.
builder.Services.AddScoped<EmailService>();

// AuthStateService: Mantiene el estado de autenticación en la aplicación.
builder.Services.AddSingleton<AuthStateService>();

// JwtAuthorizationHandler: DelegatingHandler que agrega automáticamente el token JWT a las peticiones HTTP salientes.
builder.Services.AddScoped<JwtAuthorizationHandler>();

// TokenStorageService: Gestiona el almacenamiento seguro de tokens.
builder.Services.AddScoped<TokenStorageService>();

// TokenWatcherService: Supervisa la validez del token y refresca automáticamente.
builder.Services.AddScoped<TokenWatcherService>();

// Cada servicio API se registra con HttpClient propio, todos apuntan a la misma URL base definida en "ApiBaseUrl" del appsettings.json.
// Se añade el JwtAuthorizationHandler para inyectar el token de autenticación en cada petición, ayudando a autorizar las rutas desde API.
builder.Services.AddHttpClient<AuthApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
});

builder.Services.AddHttpClient<RoleApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<DirectrizApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<UsuarioApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<FacultadApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<PeriodoEscolarApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<CarreraApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<IndicadorApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<EvidenciaApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<GrupoIndicadoresApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<ComentarioApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<EstrategiaApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<ActividadApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddHttpClient<ArchivoPoliticasApiService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();

builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI(); // Añade UI de autenticación.
builder.Services.AddRazorPages(); // Soporte para Razor Pages (usado en _Host.cshtml y Error.cshtml).
// AddServerSideBlazor: Habilita Blazor Server.
// AddMicrosoftIdentityConsentHandler: Maneja el consentimiento de autenticación en Blazor.
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true; // Hace que los cambios de propiedades se propaguen inmediatamente.
    })
    .AddBootstrap5Providers()   // Tema Bootstrap 5.
    .AddFontAwesomeIcons()      // Iconos FontAwesome.
    .AddRadzenComponents();     // Componentes Radzen.Blazor.

var app = builder.Build(); // aquí se empieza la constucción de la aplicación.

if (!app.Environment.IsDevelopment())
{
    // Cambiar esta página por alguna otra personalizada.
    app.UseExceptionHandler("/usuario-no-encontrado");
    // HSTS: obliga a conexiones HTTPS durante 30 días (ajustable).
    app.UseHsts();
}

// Autenticación y autorización se deben de usar para el corrcto funcionamiento de la aplicación.
app.UseAuthentication();
app.UseAuthorization();

// Redirección automática a HTTPS.
app.UseHttpsRedirection();

// Permite archivos estáticos (wwwroot).
app.UseStaticFiles();

// Enrutamiento: debe ir después de UseStaticFiles y antes de mapear endpoints.
app.UseRouting();

// Controladores API.
app.MapControllers();

// Hub de SignalR para Blazor Server.
app.MapBlazorHub();

// Página de fallback: cualquier ruta no manejada redirige a _Host.cshtml, que es el punto de entrada de Blazor (Server).
app.MapFallbackToPage("/_Host");

// Inicio de la aplicación.
app.Run();
