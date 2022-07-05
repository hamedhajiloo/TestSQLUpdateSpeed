using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestSQLUpdateSpeed;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



var sw1 = Stopwatch.StartNew();
await Update1();
sw1?.Stop();

Console.WriteLine($"update 1: {sw1.ElapsedMilliseconds}");


var sw2 = Stopwatch.StartNew();
await Update2();
sw2?.Stop();

Console.WriteLine($"update 2: {sw2.ElapsedMilliseconds}");

await Show();

Console.ReadKey();


async Task Show()
{
    await using var db = new MyDbContext();
    var test = await db.Tests.Where(c => c.Id == 1).FirstOrDefaultAsync();
    Console.WriteLine(test.Text);
}

async Task Update1()
{
    await using var db = new MyDbContext();
    var test = await db.Tests.Where(c => c.Id == 1).FirstOrDefaultAsync();
    for (int i = 0; i < 10000; i++)
    {
        test.Text += $"update1 {DateTimeOffset.Now.ToString("ddHHmmss")}";
        await db.SaveChangesAsync(); 
    }
}


async Task Update2()
{
    await using var db = new MyDbContext();
    for (int i = 0; i < 10000; i++)
    {
        db.Database.ExecuteSqlRaw("exec AppendText @text={0}", $"update2 {DateTimeOffset.Now.ToString("ddHHmmss")},"); 
    }
}


