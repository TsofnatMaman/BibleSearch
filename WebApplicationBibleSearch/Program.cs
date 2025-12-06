var builder = WebApplication.CreateBuilder(args);

// הוספת שירותים ל-API
builder.Services.AddControllers();

// הגדרת CORS - מאפשר חיבור מכל מקור
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// הוספת Swagger עבור תיעוד API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// שימוש ב-Swagger רק בסביבה של פיתוח (Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// שימוש ב-CORS - איפשרנו לכל המקורות גישה
app.UseCors("AllowAll");

// כל הבקשות ינותבו ל-HTTPS
app.UseHttpsRedirection();

// אישור הגישה (למשל על ידי JWT או אחר)
app.UseAuthorization();

// מפה את ה-Controllers (הנתיבים שקשורים ל-API)
app.MapControllers();

// הרץ את היישום
app.Run();
