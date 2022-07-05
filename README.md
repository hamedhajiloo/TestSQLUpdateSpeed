# TestSQLUpdateSpeed

## Simple update

```
await using var db = new MyDbContext();
    var test = await db.Tests.Where(c => c.Id == 1).FirstOrDefaultAsync();
    test.Text += $"something,";
    await db.SaveChangesAsync();
}
```

## update with ``write``

```
UPDATE Tests
SET Text.WRITE('something', NULL, NULL)
WHERE Id = 1;
```

### Result

The second method is much faster than the first method and there is a very high probability that the replacement will not be done and Append will be done.

The result of a test show that second way was 100 times faster

![image](https://user-images.githubusercontent.com/45947371/177378668-d4548d61-bc44-4021-950a-d22173dd7f77.png)

