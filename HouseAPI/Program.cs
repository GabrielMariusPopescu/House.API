var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSingleton<HouseRepository>();
builder.Services.AddSingleton<BidRepository>();

var app = builder.Build();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/houses", async (HouseRepository repo) =>
{
    await Task.Delay(2000);
    var list = repo.GetAll();

    return list;
});

app.MapPost("/api/houses", async (HouseRepository repo, House house) =>
{
    await Task.Delay(2000);
    repo.Add(house);
    return house;
});

app.MapGet("/api/bids/{houseId}", async (BidRepository repo, int houseId) =>
{
    await Task.Delay(2000);
    return repo.GetBids(houseId);
});

app.MapPost("/api/bids", async (BidRepository repo, Bid bid) =>
{
    await Task.Delay(2000);
    repo.Add(bid);
    return bid;
});
app.Run();