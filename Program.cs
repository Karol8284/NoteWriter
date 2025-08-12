using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using NoteWriter;
using NoteWriter.Logic;
using TG.Blazor.IndexedDB;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// indexdb

//builder.Services.Add(option =>
//{
//    dbStore.DatabaseName = "NoteWriterDB";
//    dbStore.Version = 1;
//    dbStore.StoreNames = new[] { "notes" };
//});

//builder.Services.AddDbContext<NotesDbContext>(options =>
//{
//    options.UseSqlite("Data Source=notes.db");
//});


builder.Services.AddIndexedDB(dbStore =>
{
    dbStore.DbName = "NoteWriterDB";
    dbStore.Version = 1;

    dbStore.Stores.Add(new StoreSchema
    {
        Name = "notes",
        PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = true },
        Indexes = new List<IndexSpec>
        {
            //new IndexSpec { Name = "path", Unique=true},
            new IndexSpec { Name = "title", Unique=false},
            new IndexSpec { Name = "text", Unique=false},
            new IndexSpec { Name = "size", Unique=false},
        }

    });
});


await builder.Build().RunAsync();
