using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using PruebaAutenticador2.Handlers;
using PruebaAutenticador2.Services;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Configuración de autenticación sin redirección automática
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
.EnableTokenAcquisitionToCallDownstreamApi()
.AddInMemoryTokenCaches();

builder.Services.Configure<OpenIdConnectOptions>(
    OpenIdConnectDefaults.AuthenticationScheme,
    options =>
    {
        options.Events.OnSignedOutCallbackRedirect = context =>
        {
            context.Response.Redirect("/");
            context.HandleResponse();
            return Task.CompletedTask;
        };
    });


builder.Services.AddScoped<EmailService>();
builder.Services.AddSingleton<AuthStateService>();
builder.Services.AddScoped<JwtAuthorizationHandler>();
builder.Services.AddScoped<TokenStorageService>();
builder.Services.AddScoped<TokenWatcherService>();


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

builder.Services.AddHttpClient<EventosCalendarioService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<JwtAuthorizationHandler>();



builder.Services.AddControllersWithViews()
    .AddMicrosoftIdentityUI();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons()
    .AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();  

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
