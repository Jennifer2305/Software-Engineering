using SWE_webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using SWE_webapi;


var app = Startup.InitializeApp(args);
app.Run();
