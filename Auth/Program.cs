using Auth.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Auth.Models;
using Auth.Controllers;
using Auth.Areas.Identity.Pages.MedicalCard;
using Auth.Areas.Identity.Pages.ClientMedic;

var builder = WebApplication.CreateBuilder(args);

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NBaF5cXmZCekx3QXxbf1x0ZFNMY1VbRn9PMyBoS35RckVnWXhedndcRGlYWERw");

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<AppointmentsController>();

builder.Services.AddDbContext<ApplicationDBContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<DoctorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<CommentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.MapPost("/Identity/MedicalCard/FillnfoWord/AddInfoFirstTab", (HttpContext context) =>
{
    var typeOfInvestigation = context.Request.Form["typeOfInvestigation"];
    var results = context.Request.Form["results"];
    var referenceRanges = context.Request.Form["referenceRanges"];
    var interpretation = context.Request.Form["interpretation"];
    var extraInformation = context.Request.Form["extraInformation"];
    var id = context.Request.Form["id"];
    var iddoctor = context.Request.Form["iddoctor"];

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var hostingEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDBContext>();

        var model = new FillnfoWordModel(hostingEnvironment, dbContext);
        model.OnPostAddInfoFirstTab(id, iddoctor, typeOfInvestigation, results, referenceRanges, interpretation, extraInformation);
    }
    return Task.CompletedTask;
});

app.MapPost("/Identity/MedicalCard/FillnfoWord/AddInfoSecondTab", (HttpContext context) =>
{
    var medicationame = context.Request.Form["medicationame"];
    var dosage = context.Request.Form["dosage"];
    var frequencyofadministration = context.Request.Form["frequencyofadministration"];
    var durationofadministration = context.Request.Form["durationofadministration"];
    var extrainformation = context.Request.Form["extraInformation"];
    var id = context.Request.Form["id"];
    var iddoctor = context.Request.Form["iddoctor"];

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var hostingEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDBContext>();

        var model = new FillnfoWordModel(hostingEnvironment, dbContext);
        model.OnPostAddInfoSecondTab(id, iddoctor, medicationame, dosage, frequencyofadministration, durationofadministration, extrainformation);
    }
    return Task.CompletedTask;
});


app.MapPost("/Identity/ClientMedic/DoctorInfo/AddComment", (HttpContext context) =>
{
    var text = context.Request.Form["text"];
    var id = context.Request.Form["id"];
    var iddoctor = context.Request.Form["iddoctor"];
    var rating = context.Request.Form["rating"];

    int temp = 6 - Convert.ToInt32(rating);

    rating = Convert.ToString(temp);

    using (var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;
        var hostingEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        var dbContext = serviceProvider.GetRequiredService<ApplicationDBContext>();
        var contextcomment = serviceProvider.GetRequiredService<CommentDbContext>();

        var model = new DoctorInfoModel(hostingEnvironment, dbContext, contextcomment);
        model.AddComment(id, iddoctor, text, rating);
    }

    // Выполним перенаправление на нужную страницу
    context.Response.Redirect($"/Identity/ClientMedic/DoctorInfo?id={iddoctor}");
    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
