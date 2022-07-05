using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestSQLUpdateSpeed;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

await Show();
//var sw1 = Stopwatch.StartNew();
//await Updatea1();
//sw1?.Stop();

//Console.WriteLine($"update 1: {sw1.ElapsedMilliseconds / 1000}");

//Console.ReadKey();


async Task Show()
{
    await using var db = new MyDbContext();
    var test = await db.Tests.Where(c => c.Id == 1).FirstOrDefaultAsync();
    Console.WriteLine(test.Text);
}

async Task Updatea1()
{
    await using var db = new MyDbContext();
    var test = await db.Tests.Where(c => c.Id == 1).FirstOrDefaultAsync();
    test.Text += $"{DateTimeOffset.Now.ToString("ddHHmmss")}";
    await db.SaveChangesAsync();
}


async Task Updatea2()
{
   
}


