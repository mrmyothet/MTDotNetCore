using MTDotNetCore.ConsoleAppRefitExample;

Console.WriteLine("Hello Refit");

RefitExample refitExample = new RefitExample("https://localhost:7289");

await refitExample.ReadAsync();

//await refitExample.EditAsync(1);
//await refitExample.EditAsync(100);

//await refitExample.CreateAsync("title", "author", "content");

//await refitExample.UpdateAsync(4018, "Update Title", "Update Author", "Update Content");
//await refitExample.EditAsync(4018);